using Common.Application;
using DigiMenu.Domain.UserAgg.Repositories;

namespace DigiMenu.Application.Users.AddToken
{
    public class AddUserTokenCommandHandler : IBaseCommandHandler<AddUserTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTrackingAsync(request.userId);
            if (user == null) return OperationResult.NotFound();
            user.AddUserToken(request.hashJwtToken, request.hashRefreshToken, request.tokenExpireDate, request.refreshTokenExpireDate, request.device);
            await _userRepository.SaveAsync();
            return OperationResult.Success();
        }
    }

}
