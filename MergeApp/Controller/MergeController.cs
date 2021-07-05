using System.Collections.Generic;
using MergeApp.Models;
using MergeApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace MergeApp.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MergeController : ControllerBase
    {
        [HttpPost]
        [Route("/merge")]
        public List<Interval> Merge(List<Interval> intervals)
        {
            var mergeService = new MergeService(inputIntervals: intervals);
            var mergedList = mergeService.MergeIntervals();
            return mergedList;
        }
    }
}