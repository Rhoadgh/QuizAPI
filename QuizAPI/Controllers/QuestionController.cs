#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Context;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuestionController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var random5Qns = await (_context.Questions
                 .Select(x => new
                 {
                     QnId = x.Id,
                     QnInWords = x.QnInWords,
                     ImageName = x.ImageName,
                     Option1 = x.Option1,
                     Option2 = x.Option2,
                     Option3 = x.Option3,
                     Option4 = x.Option4

                 })
                 .OrderBy(y => Guid.NewGuid())
                 .Take(5)
                 ).ToListAsync();

            return Ok(random5Qns);
        }


        // GET: api/Question/GetQuestionByCategory
        [HttpGet]
        [Route("GetQuestionByCategory")]
        public async Task<ActionResult<Question>> GetQuestionByCategory(int categoryId)
        {
            var questions = _context.Questions.Where(a => a.CategoryID == categoryId);
            var random5Qns = await (questions
                 .Select(x => new
                 {
                     QnId = x.Id,
                     QnInWords = x.QnInWords,
                     ImageName = x.ImageName,
                     Option1 = x.Option1,
                     Option2 = x.Option2,
                     Option3 = x.Option3,
                     Option4 = x.Option4
                 })
                 .OrderBy(y => Guid.NewGuid())
                 .Take(5)
                 ).ToListAsync();

            if (questions == null)
            {
                return NotFound();
            }


            return Ok(random5Qns);
        }

        //// PUT: api/Question/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuestion(int id, Question question)
        //{
        //    if (id != question.QnId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(question).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Question/GetAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Question>> RetrieveAnswers(int[] qnIds)
        {
            var answers = await (_context.Questions
                .Where(x => qnIds.Contains(x.Id))
                .Select(y => new
                {
                    QnId = y.Id,
                    QnInWords = y.QnInWords,
                    ImageName = y.ImageName,
                    Option1 = y.Option1,
                    Option2 = y.Option2,
                    Option3 = y.Option3,
                    Option4 = y.Option4,
                    Answer = y.Answer
                })).ToListAsync();
            return Ok(answers);
        }

        //// DELETE: api/Question/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuestion(int id)
        //{
        //    var question = await _context.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Questions.Remove(question);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
