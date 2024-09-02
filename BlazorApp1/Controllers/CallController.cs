using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly CallService _callService;

        public CallController(CallService callService)
        {
            _callService = callService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCall([FromBody] Call call)
        {
            if (call == null)
            {
                return BadRequest("Call data is invalid.");
            }

            await _callService.AddCallAsync(call);
            return CreatedAtAction(nameof(GetCallById), new { id = call.CallId }, call);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateCalls([FromBody] IEnumerable<Call> calls)
        {
            if (calls == null || !calls.Any())
            {
                return BadRequest("Calls data is invalid.");
            }

            await _callService.AddCallsAsync(calls);
            return Ok("Calls added successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCallById(int id)
        {
            var call = await _callService.GetCallByIdAsync(id);
            if (call == null)
            {
                return NotFound($"Call with ID {id} not found.");
            }

            return Ok(call);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCalls()
        {
            var calls = await _callService.GetAllCallsAsync();
            return Ok(calls);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCall(int id, [FromBody] Call updatedCall)
        {
            if (updatedCall == null || updatedCall.CallId != id)
            {
                return BadRequest("Call data is invalid.");
            }

            var call = await _callService.GetCallByIdAsync(id);
            if (call == null)
            {
                return NotFound($"Call with ID {id} not found.");
            }

            await _callService.UpdateCallAsync(updatedCall);
            return Ok("Call updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCall(int id)
        {
            var call = await _callService.GetCallByIdAsync(id);
            if (call == null)
            {
                return NotFound($"Call with ID {id} not found.");
            }

            await _callService.RemoveCallAsync(call);
            return Ok("Call deleted successfully.");
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountCalls()
        {
            var count = await _callService.CountCallsAsync();
            return Ok(count);
        }
    }
}
