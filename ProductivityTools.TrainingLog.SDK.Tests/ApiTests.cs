using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductivityTools.TrainingLog.Contract;
using System;

namespace ProductivityTools.TrainingLog.SDK.Tests
{
    [TestClass]
    public class ApiTests
    {
        private string ApiAdress = "https://localhost:5001";
        [TestMethod]
        public void PostTraining()
        {
            Training training = new Training();
            training.Application = "SDK";
            training.Account = "SDK1";
            training.Sport = TrainingType.Aerobics;
            training.Name = "Name";
            training.Source = "SdkSource";
            training.Duration = 3600;
            training.Start = DateTime.Parse("2021.01.01 12:00:00");
            training.End = DateTime.Parse("2021.01.01 13:00:00");
            training.Distance = 1;
            training.Calories = 6;
            training.AverageSpeed = 11;
            training.ExternalIdList = new System.Collections.Generic.Dictionary<string, string>();
            //training.Pictures=//

            TrainingLog trainingLog = new TrainingLog(ApiAdress);
            trainingLog.PostTraining(training);

            var trainingList = trainingLog.TrainingList("SDK1");
            Assert.IsTrue(trainingList.Count > 0);
        }

        [TestMethod]
        public void ListOfTrainingsFromDate()
        {
            TrainingLog trainingLog = new TrainingLog(ApiAdress);
            var trainings=trainingLog.TrainingList("SDK1", DateTime.Now.AddYears(-1));
        }
    }
}
