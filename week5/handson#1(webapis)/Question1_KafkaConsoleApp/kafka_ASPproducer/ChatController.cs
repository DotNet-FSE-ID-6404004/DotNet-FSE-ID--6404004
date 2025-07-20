using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly KafkaProducerService _kafkaProducer;

        public ChatController(KafkaProducerService kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.User) || string.IsNullOrWhiteSpace(message.Message))
                return BadRequest("User and Message cannot be empty.");

            await _kafkaProducer.SendMessageAsync(message);
            return Ok("Message sent to Kafka.");
        }
    }
}
