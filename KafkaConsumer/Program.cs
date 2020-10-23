using Confluent.Kafka;
using System;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                GroupId = "test-cg-jan",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("testjantopic");
                var readOneResult = consumer.Consume();
                Console.WriteLine(readOneResult.Message.Value);
            }
        }    
    }
}
