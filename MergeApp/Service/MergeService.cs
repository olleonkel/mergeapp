using System.Collections.Generic;
using System.Linq;
using MergeApp.Models;

namespace MergeApp.Service
{
    /// <summary>
    /// service for finding interval overlaps and merging intervals
    /// </summary>
    public class MergeService
    {
        private readonly List<Interval> _mergedAndNonOverlappingInvervals = new();
        public List<Interval> InputIntervals;

        public MergeService(List<Interval> inputIntervals)
        {
            InputIntervals = inputIntervals;
        }

        /// <summary>
        ///  finds overlaps in a list of intervals and merges them, filters for non-overlapping intervals
        /// </summary>
        /// <returns>list of merged and non-overlapping intervals</returns>
        public List<Interval> MergeIntervals()
        {
            //remove duplicates
            InputIntervals = InputIntervals.GroupBy(i => new {i.Start, i.End} )
                .Select(g => g.First())
                .ToList();

            //sort start descending
            InputIntervals = InputIntervals.OrderByDescending(interval => interval.Start).ToList();

            // aslong there are intervals on the input list
            while (InputIntervals.Count > 0)
            {
                var inputIntervalsIndex = InputIntervals.Count() - 1;

                // find overlapping intervals for the current interval
                var overlap = InputIntervals.Where(it =>
                    !it.Equals(InputIntervals[inputIntervalsIndex]) &&
                    it.OverlapsWith(InputIntervals[inputIntervalsIndex])).ToList();

                // merge them together with the current interval
                if (overlap.Any())
                {
                    var mergedInterval = InputIntervals[inputIntervalsIndex].MergeWithIntervalList(overlap);
                    InputIntervals = InputIntervals.Except(overlap).ToList();
                    InputIntervals.Add(mergedInterval);
                }
                // otherwise add current interval to the output list
                else
                {
                    _mergedAndNonOverlappingInvervals.Add(InputIntervals[inputIntervalsIndex]);
                    InputIntervals.Remove(InputIntervals[inputIntervalsIndex]);
                }
            }

            // return list with non-overlapping and merged intervals plus the last one the input list
            return _mergedAndNonOverlappingInvervals.OrderBy(it => it.Start).ToList();
        }
    }
}
