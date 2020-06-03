using System;
using System.Net;
using System.Threading.Tasks;
using CoreTestApp.Commands.Broadcast.Create;
using CoreTestApp.Queries.Broadcast;
using CoreTestApp.Queries.Broadcast.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestApp.API.Controllers
{
    public class BroadcastController : BaseController
    {
        private readonly IMediator _mediator;
        public BroadcastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BroadcastViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateBroadcastCommand command)
        {
            var broadcastId = await _mediator.Send(command);

            return CreatedAtAction("Create", new { Id = broadcastId }, broadcastId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BroadcastViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBroadcast(Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetBroadcastQuery { BroadcastId = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
