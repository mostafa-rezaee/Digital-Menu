using Common.NetCore;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Api.ViewModels.PageSetting;
using DigiMenu.Application.PageSettings.Create;
using DigiMenu.Application.PageSettings.Edit;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Presentation.Facade.PageSettings;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Query.PageSettings.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    
    public class PageSettingController : BaseApiController
    {
        private readonly IPageSettingFacade _pageSettingFacade;

        public PageSettingController(IPageSettingFacade pageSettingFacade)
        {
            this._pageSettingFacade = pageSettingFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<PageSettingDto?>> GetPageSetting()
        {
            var result = await _pageSettingFacade.GetPageSettings();
            return QueryResult(result);
        }


        [HttpPost]
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManagePageSettings)]
        public async Task<ApiResult> CreatePageSetting([FromForm] CreatePageSettingModel command)
        {
            var result = await _pageSettingFacade.Create(new CreatePageSettingCommand(
                command.PageTitle, command.BackgroundImageFile, command.LogoImageFile, command.WebsiteAddress, 
                command.SocialTitle, command.SocialAddress, command.Telephone, command.Address));
            return CommandResult(result);
        }

        [HttpPut]
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManagePageSettings)]
        public async Task<ApiResult> EditPageSetting([FromForm] EditPageSettingModel command)
        {
            var result = await _pageSettingFacade.Edit(new EditPageSettingCommand(
                command.Id, command.PageTitle, command.BackgroundImageFile, command.LogoImageFile, command.WebsiteAddress,
                command.SocialTitle, command.SocialAddress, command.Telephone, command.Address));
            return CommandResult(result);
        }
    }
}
