using Domain.Entities;

namespace ServiceLayer.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<Appointment> CreateNewAppointment(Appointment appointment);
        Task<string> UpdateAppoiment(Appointment appointment);
        Task<string> DeleteAppoiment(int Id);
        Task<List<Appointment>> GetPetSitterAppointments();
        Task<string> PetSitterUpdateAppoiment(Appointment appointment);
        Task<List<Appointment>> GetAppointmentsByUserId(int id);
        Task<List<Appointment>> GetAllAppointmentAsync();
        Task<string> UpdateAppointmentStatusAsync(int appointmentId, string status);
        Task<List<Appointment>> GetAppointmentsByPetSitterId(int petSitterId);
    }
}