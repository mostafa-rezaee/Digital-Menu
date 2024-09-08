using Common.Application;
using DigiMenu.Domain.UserAgg.Repositories;

namespace DigiMenu.Application.Users.RemoveToken
{
    public class RemoveUserTokenCommanHandler : IBaseCommandHandler<RemoveUserTokenComman>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserTokenCommanHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(RemoveUserTokenComman request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTrackingAsync(request.userId);
            if (user == null) return OperationResult.NotFound();
            user.RemoveUserToken(request.tokenId);
            await _userRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
