using System.Collections.Generic;
using MergeApp.Models;
using MergeApp.Service;
using Xunit;

namespace MergeAppTests
{
    public class MergeServiceTests
    {
        [Fact]
        public void MergeTest_Expect2RemainingIntervals()
        {
            // create interval list
            var interval1 = new Interval
            {
                Start = 25,
                End = 30
            };
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

            var inputIntervals = new List<Interval> {interval1, interval2, interval3, interval4};
            var mergeService = new MergeService(inputIntervals);

            //Act
            var mergedIntervals = mergeService.MergeIntervals();

            //Assert
            Assert.True(mergedIntervals.Count == 2);
            Assert.True(mergedIntervals[0].Start == 2 && mergedIntervals[0].End == 23);
            Assert.True(mergedIntervals[1].Start == 25 && mergedIntervals[1].End == 30);
        }

        [Fact]
        public void MergeTest_Expect3RemainingIntervals()
        {
            // create interval list
            var interval1 = new Interval
            {
                Start = 12,
                End = 15
            };
            var interval2 = new Interval
            {
                Start = 2,
                End = 4
            };
            var interval3 = new Interval
            {
                Start = 1,
                End = 3
            };
            var interval4 = new Interval
            {
                Start = 14,
                End = 16
            };

            var interval5 = new Interval
            {
                Start = 5,
                End = 7
            };

            var inputIntervals = new List<Interval> {interval1, interval2, interval3, interval4, interval5};
            var mergeService = new MergeService(inputIntervals);

            //Act
            var mergedIntervals = mergeService.MergeIntervals();

            //Assert
            Assert.True(mergedIntervals.Count == 3);
            Assert.True(mergedIntervals[0].Start == 1 && mergedIntervals[0].End == 4);
            Assert.True(mergedIntervals[1].Start == 5 && mergedIntervals[1].End == 7);
            Assert.True(mergedIntervals[2].Start == 12 && mergedIntervals[2].End == 16);
        }
    }
}
