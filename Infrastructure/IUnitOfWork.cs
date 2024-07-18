using RepositoryLayer.Interfaces;

namespace RepositoryLayer
{
    public interface IUnitOfWork
    {
        IPetRepository PetRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IUserRepository UserRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        ISpaPackageRepository SpaPackageRepository { get; }
        ITransactionRepository TransactionRepository { get; }

        Task<int> SaveChangeAsync();
    }
}