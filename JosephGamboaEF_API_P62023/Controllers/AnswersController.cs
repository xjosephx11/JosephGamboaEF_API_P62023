using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JosephGamboaEF_API_P62023.Models;
using JosephGamboaEF_API_P62023.Attributes;

namespace JosephGamboaEF_API_P62023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Apikey]
    public class AnswersController : ControllerBase
    {
        private readonly AnswersDBContext _context;

        public AnswersController(AnswersDBContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {
          if (_context.Answers == null)
          {
              return NotFound();
          }
            return await _context.Answers.ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(long id)
        {
          if (_context.Answers == null)
          {
              return NotFound();
          }
            var answer = await _context.Answers.FindAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(long id, Answer answer)
        {
            if (id != answer.AnswerId)
            {
                return BadRequest();
            }

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
          if (_context.Answers == null)
          {
              return Problem("Entity set 'AnswersDBContext.Answers'  is null.");
          }
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswer", new { id = answer.AnswerId }, answer);
        }

        

        private bool AnswerExists(long id)
        {
            return (_context.Answers?.Any(e => e.AnswerId == id)).GetValueOrDefault();
        }
    }
}
