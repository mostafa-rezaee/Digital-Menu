using Common.Application;
using Common.Application.Utilities.File.Services;
using Common.Domain.Exceptions;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.PageSettingAgg;

namespace DigiMenu.Application.PageSettings.Create
{
    public class CreatePageSettingCommandHandler : IBaseCommandHandler<CreatePageSettingCommand>
    {
        private readonly IPageSettingRepository _pageSettingRepository;
        private readonly IFileService _fileService;

        public CreatePageSettingCommandHandler(IPageSettingRepository pageSettingRepository, IFileService fileService)
        {
            _pageSettingRepository = pageSettingRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreatePageSettingCommand request, CancellationToken cancellationToken)
        {
            var hasRecord = await _pageSettingRepository.HasRecordAsync();
            if (hasRecord)
            {
                throw new InvalidDomainDataException("تنظیمات منو قبلا ثبت شده است. لطفا در صورت نیاز ویرایش کنید");
            }

            var backgroundImageName = await _fileService.SaveFileAndGenerateName(request.backgroundImage, Directories.PageImage);
            var logoImageName = await _fileService.SaveFileAndGenerateName(request.logoImage, Directories.PageImage);
            var pageSetting = new PageSetting(request.pageTitle, backgroundImageName, logoImageName, request.websiteAddress, 
                request.socialTitle, request.socialAddress, request.telephone, request.address);
            await _pageSettingRepository.AddAsync(pageSetting);
            await _pageSettingRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
