using RepositoryLayer.Interfaces;

namespace RepositoryLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetSpaManagementDbContext _context;
        private readonly IPetRepository _petRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;

        //private readonly IServiceRepository _serviceRepository;
        //private readonly IPackageServiceRepository _packageRepository;
        private readonly ISpaPackageRepository _spaPackageRepository;

        //private readonly IWeightRepository _weightRepository;

        public UnitOfWork(PetSpaManagementDbContext context
            , IPetRepository petRepository
            , IAppointmentRepository appointmentRepository
            , IUserRepository userRepository
            , IPaymentRepository paymentRepository
       //, IUserRepository userRepository, IServiceRepository serviceRepository, IPackageServiceRepository packageRepository
       , ISpaPackageRepository spaPackageRepository
       //, IWeightRepository weightRepository
       )
        {
            _context = context;
            _petRepository = petRepository;
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            //_serviceRepository = serviceRepository;
            //_packageRepository = packageRepository;
            _spaPackageRepository = spaPackageRepository;
            //_weightRepository = weightRepository;
        }

        public IPetRepository PetRepository => _petRepository;

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;

        public IUserRepository UserRepository => _userRepository;

        public IPaymentRepository PaymentRepository => _paymentRepository;

        public ISpaPackageRepository SpaPackageRepository => _spaPackageRepository;

        public Task<int> SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}