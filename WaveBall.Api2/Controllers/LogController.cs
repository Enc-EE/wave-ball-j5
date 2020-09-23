using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WaveBall.Api2.Models;
using WaveBall.Data;

namespace WaveBall.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly WaveBallContext _context;

        public LogController(WaveBallContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogs()
        {
            return await _context.LogEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogEntry>> GetLog(long id)
        {
            var logEntry = await _context.LogEntries.FindAsync(id);

            if (logEntry == null)
            {
                return NotFound();
            }

            return logEntry;
        }

        [HttpPut]
        public async Task<IActionResult> PutLog(Log log)
        {
            if (string.IsNullOrEmpty(log.Message))
            {
                return BadRequest("Message is empty.");
            }

            var app = _context.Apps.FirstOrDefault(x => x.AppGuid == log.AppGuid);
            if (app == null)
            {
                return BadRequest("App does not exist.");
            }

            var logEntry = new LogEntry()
            {
                AppId = app.AppId,
                CreatedAt = log.CreatedAt,
                Level = log.Level ?? "Info",
                Message = log.Message,
            };

            _context.LogEntries.Add(logEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
