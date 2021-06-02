using System;
using System.Collections.Generic;
using CrossOverWebServer.Models;
using CrossOverWebServer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CrossOverWebServer.Controllers
{
    [Route("api/[controller]/{key}")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityReportingsService activityReportingsService;
        public ActivityController(IActivityReportingsService activityReportingsService)
        {
            this.activityReportingsService = activityReportingsService;
        }
        // GET: api/Activity
        [HttpGet("total")]
        public JsonResult Get(string key)
        {
            var activitySum = activityReportingsService.GetRecentActivitiesSum(key);
            var keyValuePairs = new Dictionary<string, int>
            {
                { "value", activitySum }
            };
            return new JsonResult(keyValuePairs);
        }


        // POST: api/Activity
        [HttpPost]
        public void Post(string key, [FromBody] JObject value)
        {
            var activityReportings = new ActivityReportings
            {
                Key = key,
                ActivityValue = int.Parse(value["value"].ToString()),
                ActivityReportTime = DateTime.UtcNow
            };
            activityReportingsService.AddActivity(activityReportings);
        }
    }
}
