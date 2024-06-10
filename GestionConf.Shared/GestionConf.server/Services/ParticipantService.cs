using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionConf.server.Data;
//using GestionConf.server.Models;
using GestionConf.Shared.Models;

namespace GestionConf.server.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly GestionConfDbContext _dbContext;

        public ParticipantService(GestionConfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Participant>> GetAllParticipants()
        {
            return await _dbContext.Participants.ToListAsync();
        }

        public async Task<Participant> GetParticipantById(int id)
        {
            return await _dbContext.Participants.FindAsync(id);
        }

        public async Task<Participant> AddParticipant(Participant participant)
        {
            _dbContext.Participants.Add(participant);
            await _dbContext.SaveChangesAsync();
            return participant;
        }

        public async Task<Participant> UpdateParticipant(int id, Participant participant)
        {
            var existingParticipant = await _dbContext.Participants.FindAsync(id);
            if (existingParticipant == null)
            {
                return null;
            }

            existingParticipant.Nom = participant.Nom;
            existingParticipant.Email = participant.Email;
            // Update other fields as necessary

            _dbContext.Participants.Update(existingParticipant);
            await _dbContext.SaveChangesAsync();
            return existingParticipant;
        }

        public async Task<bool> DeleteParticipant(int id)
        {
            var participant = await _dbContext.Participants.FindAsync(id);
            if (participant == null)
            {
                return false;
            }

            _dbContext.Participants.Remove(participant);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateParticipant(Participant participant)
        {
            throw new NotImplementedException();
        }

        public void DeleteParticipant(Task<Participant> participantToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
