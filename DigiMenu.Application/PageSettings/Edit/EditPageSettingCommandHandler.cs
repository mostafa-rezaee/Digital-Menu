using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.PageSettingAgg;
using Microsoft.AspNetCore.Http;

namespace DigiMenu.Application.PageSettings.Edit
{
    public class EditPageSettingCommandHandler : IBaseCommandHandler<EditPageSettingCommand>
    {
        private readonly IPageSettingRepository _pageSettingRepository;
        private readonly IFileService _fileService;

        public EditPageSettingCommandHandler(IPageSettingRepository pageSettingRepository, IFileService fileService)
        {
            _pageSettingRepository = pageSettingRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditPageSettingCommand request, CancellationToken cancellationToken)
        {
            var pageSetting = await _pageSettingRepository.GetTrackingAsync(request.id);
            if (pageSetting == null)
            {
                return OperationResult.NotFound();
            }
            pageSetting.Edit(request.pageTitle, request.websiteAddress, request.socialTitle, request.socialAddress, 
                request.telephone, request.address);

            var oldBackgroundImage = pageSetting.BackgroundImageName;
            var oldLogoImage = pageSetting.LogoImageName;
            if (request.backgroundImage != null)
            {
                var backImageName = await _fileService.SaveFileAndGenerateName(request.backgroundImage, Directories.PageImage);
                pageSetting.SetBackgroundImage(backImageName);
            }
            if (request.logoImage != null)
            {
                var logoImageName = await _fileService.SaveFileAndGenerateName(request.logoImage, Directories.PageImage);
                pageSetting.SetLogoImage(logoImageName);
            }
            await _pageSettingRepository.SaveAsync();
            RemoveOldBackgroundImage(request.backgroundImage,  oldBackgroundImage);
            RemoveOldLogoImage(request.logoImage, oldLogoImage);
            return OperationResult.Success();

        }

        private void RemoveOldLogoImage(IFormFile? logoImage, string oldLogoImage)
        {
            if (logoImage != null)
            {
                _fileService.DeleteFile(Directories.PageImage, oldLogoImage);

            }
        }

        private void RemoveOldBackgroundImage(IFormFile? backgroundImage, string oldBackgroundImage)
        {
            if (backgroundImage != null)
            {
                _fileService.DeleteFile(Directories.PageImage, oldBackgroundImage);
            }

        }
    }
}
