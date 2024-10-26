﻿using Common.Application;
using Common.Application.Utilities.File.Services;
using Common.Application.Utilities.Security;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.UserAgg;
using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Domain.UserAgg.Services;
using Microsoft.AspNetCore.Http;

namespace DigiMenu.Application.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _domainUseService;
        private readonly IFileService _fileService;

        public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService domainUseService, IFileService fileService)
        {
            _userRepository = userRepository;
            _domainUseService = domainUseService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTrackingAsync(request.Id);
            if (user == null) return OperationResult.NotFound();

            user.Edit(request.FirstName, request.LastName, request.Username, request.IsActive, _domainUseService);
            var oldAvatarImage = user.AvatarName;
            if (request.Avatar != null)
            {
                var avatarImageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.AvatarImage);
                user.SetAvatarImage(avatarImageName);

            }
            DeleteOldAvatarImage(request.Avatar, oldAvatarImage);

            await _userRepository.SaveAsync();

            return OperationResult.Success();
        }

        private void DeleteOldAvatarImage(IFormFile? avatarImage, string oldImageName)
        {
            if (avatarImage == null || oldImageName == "avatar.png") 
                return;

            _fileService.DeleteFile(Directories.AvatarImage, oldImageName);
        }
    }
}
