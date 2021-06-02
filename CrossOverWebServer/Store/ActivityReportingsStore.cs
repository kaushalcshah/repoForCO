using CrossOverWebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossOverWebServer.Store
{

    public class ActivityReportingsStore
    {
        public static IList<ActivityReportings> reportings = new List<ActivityReportings>();

        public virtual int GetRecentActivitiesSum(string key)
        {
            var valueSum = reportings.Where(act => act.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)
                                                 && DateTime.Compare(act.ActivityReportTime.AddHours(12), DateTime.UtcNow) >= 0)
                                     .Sum(rep => rep.ActivityValue);
            return valueSum;
        }

        public virtual void AddActivity(ActivityReportings activityReportings)
        {
            reportings.Add(activityReportings);
        }

    }


}
