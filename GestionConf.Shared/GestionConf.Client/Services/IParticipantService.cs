using GestionConf.Shared.Models;

namespace GestionConf.Client.Services
{
    public interface IParticipantService
    {
        Task<List<Participant>> GetAllParticipants();
        Task<Participant> GetParticipantById(int id);
        Task<Participant> AddParticipant(Participant participant);
        Task<bool> DeleteParticipant(int id);
        void UpdateParticipant(Participant participant);
        void DeleteParticipant(Task<Participant> participantToDelete);
    }
}
