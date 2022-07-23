using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRR.Api;
using CRR.Models;

namespace CRR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Attachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attachment>>> GetAttachment()
        {
          if (_context.Attachment == null)
          {
              return NotFound();
          }
            return await _context.Attachment.ToListAsync();
        }

        // GET: api/Attachments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attachment>> GetAttachment(int id)
        {
          if (_context.Attachment == null)
          {
              return NotFound();
          }
            var attachment = await _context.Attachment.FindAsync(id);

            if (attachment == null)
            {
                return NotFound();
            }

            return attachment;
        }

        // PUT: api/Attachments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttachment(int id, Attachment attachment)
        {
            if (id != attachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(attachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Attachments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attachment>> PostAttachment(Attachment attachment)
        {
          if (_context.Attachment == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Attachment'  is null.");
          }
            _context.Attachment.Add(attachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttachment", new { id = attachment.Id }, attachment);
        }

        // DELETE: api/Attachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            if (_context.Attachment == null)
            {
                return NotFound();
            }
            var attachment = await _context.Attachment.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }

            _context.Attachment.Remove(attachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttachmentExists(int id)
        {
            return (_context.Attachment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
