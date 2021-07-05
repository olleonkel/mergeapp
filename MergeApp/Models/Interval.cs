using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MergeApp.Models
{
    public record Interval
    {
        [StartSmallerThanEnd]
        [Required]
        [Display(Name="Start")]
        public int Start { get; init; }

        [Required]
        [Display(Name="End")]
        public int End { get; init; }

        /// <summary>
        /// determines and overlap of the instance interval and the provided interval
        /// </summary>
        /// <param name="interval"></param>
        /// <returns>:boolean - specifying whether there is an overlap between the provided interval and the instance interval </returns>
        public bool OverlapsWith(Interval interval)
        {
            return interval.End > Start;
        }

        /// <summary>
        ///  merges the instance interval with one given interval and returns one single merged interval
        /// </summary>
        /// <param name="interval">the interval to be merged with the instance interval</param>
        /// <returns>interval, merged from the instance interval and the given interval</returns>
        public Interval MergeWith(Interval interval)
        {
            return new()
            {
                Start = Start < interval.Start ? Start : interval.Start,
                End = End >= interval.End ? End : interval.End
            };
        }

        /// <summary>
        /// merges the interval of the instance with a given list of intervals and returns one single merged interval
        /// </summary>
        /// <param name="intervalList"> list of intervals to merge with the instance interval</param>
        /// <returns>interval, merged from the instance interval and the given intervalList</returns>
        public Interval MergeWithIntervalList(List<Interval> intervalList)
        {
            intervalList.Add(this);
            var lowestStart = intervalList.Min(it => it.Start);
            var highestEnd = intervalList.Max(it => it.End);

            return new Interval
            {
                Start = lowestStart,
                End = highestEnd
            };
        }
    }

    /// <summary>
    /// Annotation for model validation to guarantee true intervals, checks whether start is smaller than end or equal,
    /// will cause the controller to return 400 status and malfunctioned model validation hint
    /// </summary>
    public class StartSmallerThanEnd : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var interval = (Interval) validationContext.ObjectInstance;
            return (interval.Start < interval.End)
                ? ValidationResult.Success
                : new ValidationResult(
                    $"no interval defined, start {interval.Start} is equal or bigger than end {interval.End}");
        }
    }
}
