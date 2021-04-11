using ProductivityTools.SimpleHttpPostClient;
using ProductivityTools.TrainingLog.Contract;
using System;

namespace ProductivityTools.TrainingLog.SDK
{
    public class TrainingLog
    {
        private string TrainingLogApiAddress { get; set; }

        public TrainingLog(string trainingLogAddress)
        {
            this.TrainingLogApiAddress = trainingLogAddress;
        }

        public void PostTraining(Training training)
        {
            HttpPostClient client = new HttpPostClient(true);
            client.SetBaseUrl(this.TrainingLogApiAddress);

            var result2 = client.PostAsync<object>("Training", "Add", training).Result;
            Console.WriteLine(result2);
        }
    }
}
