using System;
using Confluent.Kafka;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092", 
            GroupId = "console-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe("chat-topic"); 

        Console.WriteLine("Kafka Console Consumer started. Listening for messages...");

        try
        {
            while (true)
            {
                var result = consumer.Consume();
                Console.WriteLine($"Received: {result.Message.Value}");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Consumer cancelled.");
        }
        finally
        {
            consumer.Close();
        }
    }
}
