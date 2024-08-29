using Common.Application;
using Common.Application.Utilities.Security;
using DigiMenu.Domain.UserAgg;
using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Domain.UserAgg.Services;

namespace DigiMenu.Application.Users.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _domainUseService;

        public CreateUserCommandHandler(IUserRepository userRepository, IUserDomainService domainUseService)
        {
            _userRepository = userRepository;
            _domainUseService = domainUseService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = ShaHasher.Hash(request.Password);
            var user = new User(request.FirstName, request.LastName, request.Username, password, _domainUseService);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
