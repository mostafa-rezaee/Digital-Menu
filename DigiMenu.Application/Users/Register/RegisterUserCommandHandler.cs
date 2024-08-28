using Common.Application;
using DigiMenu.Domain.UserAgg;
using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Domain.UserAgg.Services;

namespace DigiMenu.Application.Users.Register
{
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _domainUseService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService domainUseService)
        {
            _userRepository = userRepository;
            _domainUseService = domainUseService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.username, request.password, _domainUseService);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
