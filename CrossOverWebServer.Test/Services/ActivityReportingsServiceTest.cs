using CrossOverWebServer.Services;
using CrossOverWebServer.Store;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace CrossOverWebServer.Test.Services
{
    class ActivityReportingsServiceTest
    {
        [Test]
        public void GetRecentActivitiesSumTestReturnStoreValue()
        {
            //Arrange
            var expectedLearnMorePageActvity = 500;
            var expectedNoPageActivity = 0;
            var storeMoq = new Mock<ActivityReportingsStore>();
            var loggerMoq = new Mock<ILogger>();
            storeMoq.Setup(moq => moq.GetRecentActivitiesSum("learn_more_page")).Returns(500);
            storeMoq.Setup(moq => moq.GetRecentActivitiesSum("no_page")).Returns(0);
            var activity = new ActivityReportingsService(storeMoq.Object, loggerMoq.Object);

            //Act
            var actualLearnMorePageActvity = activity.GetRecentActivitiesSum("learn_more_page");
            var actualNoPageActivity = activity.GetRecentActivitiesSum("no_page");

            //Assert
            Assert.AreEqual(expectedLearnMorePageActvity, actualLearnMorePageActvity);
            Assert.AreEqual(expectedNoPageActivity, actualNoPageActivity);
        }

        
        [Test]
        public void GetRecentActivitiesSumTestLogsAndThrowExceptionWhenStoreThrows()
        {
            //Arrange
            var storeMoq = new Mock<ActivityReportingsStore>();
            var loggerMoq = new Mock<ILogger>();
            storeMoq.Setup(moq => moq.GetRecentActivitiesSum("learn_more_page")).Throws<Exception>();
            var activity = new ActivityReportingsService(storeMoq.Object, loggerMoq.Object);

            //Act & Asset
            Assert.Throws<Exception>(() => activity.GetRecentActivitiesSum("learn_more_page"));
        }
    }
}
