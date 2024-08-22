using Common.Application;
using DigiMenu.Domain.PageSettingAgg;

namespace DigiMenu.Application.PageSettings.Create
{
    public class CreatePageSettingCommandHandler : IBaseCommandHandler<CreatePageSettingCommand>
    {
        private readonly IPageSettingRepository _pageSettingRepository;

        public CreatePageSettingCommandHandler(IPageSettingRepository pageSettingRepository)
        {
            _pageSettingRepository = pageSettingRepository;
        }

        public async Task<OperationResult> Handle(CreatePageSettingCommand request, CancellationToken cancellationToken)
        {
            var pageSetting = new PageSetting(request.pageTitle, request.bGImageName, request.logoImageName, request.websiteAddress, 
                request.socialTitle, request.socialAddress, request.telephone, request.address);
            await _pageSettingRepository.AddAsync(pageSetting);
            await _pageSettingRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
