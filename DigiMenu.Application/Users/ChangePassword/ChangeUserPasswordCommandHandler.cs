using Common.Application;
using Common.Application.Utilities.Security;
using DigiMenu.Domain.UserAgg;
using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Domain.UserAgg.Services;

namespace DigiMenu.Application.Users.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTrackingAsync(request.UserId);
            if (user == null)
                return OperationResult.NotFound("کاربر یافت نشد");

            var currentPasswordHash = ShaHasher.Hash(request.CurrentPassword);
            if (user.Password != currentPasswordHash)
            {
                return OperationResult.Error("کلمه عبور فعلی نامعتبر است");
            }

            var newPasswordHash = ShaHasher.Hash(request.Password);
            user.ChangePassword(newPasswordHash);
            await _userRepository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
