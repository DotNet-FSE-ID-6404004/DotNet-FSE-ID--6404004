using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class KafkaProducerService
    {
        private readonly string _bootstrapServers;
        private readonly string _topic;

        public KafkaProducerService(IConfiguration config)
        {
            _bootstrapServers = config["Kafka:BootstrapServers"] ?? "localhost:9092";
            _topic = config["Kafka:Topic"] ?? "chat-topic";
        }

        public async Task SendMessageAsync(ChatMessage message)
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

            try
            {
                using var producer = new ProducerBuilder<Null, string>(config).Build();
                string jsonMessage = JsonSerializer.Serialize(message);

                var result = await producer.ProduceAsync(_topic, new Message<Null, string> { Value = jsonMessage });

                Console.WriteLine($" Sent to Kafka topic '{_topic}': {jsonMessage}");
            }
            catch (ProduceException<Null, string> ex)
            {
                Console.WriteLine($" Kafka produce error: {ex.Error.Reason}");
                throw;
            }
        }
    }
}
