using CrossOverWebServer.Models;

namespace CrossOverWebServer.Services
{
    public interface IActivityReportingsService
    {
        int GetRecentActivitiesSum(string key);
        void AddActivity(ActivityReportings activityReportings);
    }
}
