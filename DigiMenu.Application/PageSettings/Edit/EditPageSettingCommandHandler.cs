using Common.Application;
using DigiMenu.Domain.PageSettingAgg;

namespace DigiMenu.Application.PageSettings.Edit
{
    public class EditPageSettingCommandHandler : IBaseCommandHandler<EditPageSettingCommand>
    {
        private readonly IPageSettingRepository _pageSettingRepository;

        public EditPageSettingCommandHandler(IPageSettingRepository pageSettingRepository)
        {
            _pageSettingRepository = pageSettingRepository;
        }

        public async Task<OperationResult> Handle(EditPageSettingCommand request, CancellationToken cancellationToken)
        {
            var pageSettings = await _pageSettingRepository.GetAllAsync();
            var pageSetting = pageSettings.FirstOrDefault();
            if (pageSetting == null)
            {
                return OperationResult.NotFound();
            }
            pageSetting.Edit(request.pageTitle, request.bGImageName, request.logoImageName, request.websiteAddress,
                request.socialTitle, request.socialAddress, request.telephone, request.address);
            await _pageSettingRepository.SaveAsync();
            return OperationResult.Success();

        }
    }
}
