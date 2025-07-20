using Confluent.Kafka;
using System;
using System.Threading.Tasks;

public class KafkaProducerConsumer
{
    private readonly string _bootstrapServers = "localhost:9092";
    private readonly string _topic = "chat-topic";
    private IProducer<Null, string> _producer;

    public KafkaProducerConsumer()
    {
        var config = new ProducerConfig { BootstrapServers = _bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task SendMessageAsync(string message)
    {
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
    }

    public void StartConsumer(Action<string> onMessageReceived)
    {
        Task.Run(() =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = Guid.NewGuid().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(_topic);

            while (true)
            {
                var result = consumer.Consume();
                onMessageReceived?.Invoke(result.Message.Value);
            }
        });
    }
}
