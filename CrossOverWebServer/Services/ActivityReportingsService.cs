using CrossOverWebServer.Models;
using CrossOverWebServer.Store;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace CrossOverWebServer.Services
{
    public class ActivityReportingsService : IActivityReportingsService
    {
        private readonly ActivityReportingsStore activityReportingsStore;
        private readonly ILogger logger;

        public ActivityReportingsService(ActivityReportingsStore activityReportingsStore, ILogger logger)
        {
            this.activityReportingsStore = activityReportingsStore;
            this.logger = logger;
        }

        public int GetRecentActivitiesSum(string key)
        {
            try
            {
                logger.LogInformation($"Get recent activity called with following key: {key}");
                return activityReportingsStore.GetRecentActivitiesSum(key);
            }
            catch (Exception ex)
            {
                logger.LogError($"Get recent activity failed with following error: {ex.ToString()}");
                throw;
            }
        }

        public void AddActivity(ActivityReportings activityReportings)
        {
            try
            {
                logger.LogInformation($"Add  activity called with following data: {JsonConvert.SerializeObject(activityReportings)}");
                activityReportingsStore.AddActivity(activityReportings);
            }
            catch (Exception ex)
            {
                logger.LogError($"Add activity failed with following error: {ex.ToString()}");
                throw;
            }
        }
    }
}
