﻿using Domain.Entities;
using RepositoryLayer.Commons;

namespace ServiceLayer.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointments();

        Task<Appointment> GetAppointmentById(int id);

        Task<string> CreateNewAppointment(Appointment appointment);

        Task<string> UpdateAppoiment(Appointment appointment);

        Task<string> DeleteAppoiment(int Id);

        Task<List<Appointment>> GetPetSitterAppointments(int id);

        Task<string> UpdateAppoimentStatus(Appointment appointment);

        Task<List<Appointment>> GetAppointmentsByUserId(int id);

        Task<List<Appointment>> GetAllAppointmentAsync();

        Task<bool> CancelAppoimentById(int Id);

        Task<string> UpdateAppointmentStatusAsync(int appointmentId, string status);

        Task<List<Appointment>> GetAppointmentsByPetSitterId(int petSitterId);

        Task<List<Payment>> GetPaymentsByDateRange(DateTime startDate, DateTime endDate);

        Task<List<Appointment>> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate);

        Task<Pagination<Appointment>> GetAppointmentsFiltered(string search, PaginationParameter pagination);
    }
}