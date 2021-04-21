using ProductivityTools.SimpleHttpPostClient;
using ProductivityTools.TrainingLog.Contract;
using System;
using System.Collections.Generic;

namespace ProductivityTools.TrainingLog.SDK
{
    public class TrainingLog
    {
        private HttpPostClient Client { get; set; }

        public TrainingLog(string trainingLogAddress)
        {
            Client = new HttpPostClient(true);
            Client.SetBaseUrl(trainingLogAddress);
        }

        public void PostTraining(Training training)
        {
            var result2 = Client.PostAsync<object>("Training", "Add", training).Result;
            Console.WriteLine(result2);
        }

        public List<Training> TrainingList(string account)
        {
            var result2 = Client.PostAsync<List<Training>>("Training", "List", account).Result;
            return result2;
        }
    }
}
