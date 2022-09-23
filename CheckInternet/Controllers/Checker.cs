using CheckInternet.Entities;
using CheckInternet.PublishVersions.Commands.UpdatePublishVersion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckInternet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Checker : ApiControllerBase
    {
        private readonly ILogger<Checker> _logger;

        public Checker(ILogger<Checker> logger)
        {
            _logger = logger;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVersion(int id, UpdatePublishVersionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}