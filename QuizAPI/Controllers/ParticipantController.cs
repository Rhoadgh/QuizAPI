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
    public class ParticipantController : ControllerBase
    {
        private readonly QuizDbContext _context;
        
        public ParticipantController(QuizDbContext context)
        {
            _context = context;
        }
        

        //// GET: api/Participant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            return await _context.Participants.ToListAsync();
        }

        // GET: api/Participant/GetParticipantById
        [HttpGet("GetParticipantById")]
        public async Task<ActionResult<Participant>> GetParticipantById(int id)
        {
            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participant/updateParticipant
        [HttpPut(" updateParticipant")]
        public async Task<IActionResult> UpdateParticipant(int id, _Participant pp)
        {
            if (id != pp.ParticipantId)
            {
                return BadRequest();
            }

            // get all current details of the record, then update with quiz results
            Participant participant = _context.Participants.Find(id);
            participant.Score = pp.Score;


            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participant
        [HttpPost]
        public async Task<ActionResult<Participant>> CreatParticipant(Participant participant)
        {
            var temp = _context.Participants
                .Where(x => x.Name == participant.Name
                && x.Password == participant.Password)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();
            }
            else
                participant = temp;

            return Ok(participant);
        }

        //// DELETE: api/Participant
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteParticipant(int id)
        //{
        //    var participant = await _context.Participants.FindAsync(id);
        //    if (participant == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Participants.Remove(participant);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.ParticipantId == id);
        }


    }
}
