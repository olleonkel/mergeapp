using System.Collections.Generic;
using MergeApp.Models;
using Xunit;

namespace MergeAppTests
{
    public class IntervalTests
    {
        [Fact]
        public void Merge2Intervals()
        {
            //Arrange
            var firstInterval = new Interval
            {
                Start = 14,
                End = 34
            };

            var secondInterval = new Interval
            {
                Start = 5,
                End = 17
            };

            // Act
            var mergedInterval = firstInterval.MergeWith(secondInterval);

            //Assert
            Assert.True(mergedInterval.Start == 5);
            Assert.True(mergedInterval.End == 34);
        }

        [Fact]
        public void MergeListOfIntervals()
        {
            //Arrange
            var interval2 = new Interval
            {
                Start = 2,
                End = 19
            };
            var interval3 = new Interval
            {
                Start = 14,
                End = 23
            };
            var interval4 = new Interval
            {
                Start = 4,
                End = 8
            };

            var intervalListToMergeWith = new List<Interval> {interval2, interval3, interval4};
            var intervalToMerge = new Interval {Start = 22, End = 28};

            //Act
            var mergeInterval = intervalToMerge.MergeWithIntervalList(intervalListToMergeWith);

            //Assert
            Assert.True(mergeInterval.Start == 2);
            Assert.True(mergeInterval.End == 28);
        }

        [Theory]
        [MemberData(nameof(GetIntervalData))]
        public void CheckIf2GivenIntervalsOverlap(Interval firstInterval, Interval secondInterval,
            bool expectedIntervalsOverlapResult)
        {
            //Act
            var intervalsOverlap = firstInterval.OverlapsWith(secondInterval);
            
            //Assert
            Assert.True(intervalsOverlap == expectedIntervalsOverlapResult);
        }

        // generate intervals helper
        public static IEnumerable<object[]> GetIntervalData =>
            new List<object[]>
            {
                new object[] {new Interval {Start = 12, End = 17}, new Interval {Start = 15, End = 19}, true},
                new object[] {new Interval {Start = 0, End = 19}, new Interval {Start = 2, End = 7}, true},
                new object[] {new Interval{Start = 23, End = 33}, new Interval{Start = 1, End=7}, false},
                new object[] {new Interval{Start=23, End = 33}, new Interval{Start = 20, End = 23}, false},
            };
    }
}