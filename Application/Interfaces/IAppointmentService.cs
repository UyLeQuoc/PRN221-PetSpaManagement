using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Task<bool> CancelAppoimentById(int Id);
    }
}