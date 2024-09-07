using Common.NetCore;
using DigiMenu.Application.PageSettings.Create;
using DigiMenu.Application.PageSettings.Edit;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Presentation.Facade.PageSettings;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Query.PageSettings.DTO;
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

        [HttpGet]
        public async Task<ApiResult<PageSettingDto?>> GetPageSetting()
        {
            var result = await _pageSettingFacade.GetPageSettings();
            return QueryResult(result);
        }


        [HttpPost]
        public async Task<ApiResult> CreatePageSetting([FromForm] CreatePageSettingCommand command)
        {
            var result = await _pageSettingFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditPageSetting([FromForm] EditPageSettingCommand command)
        {
            var result = await _pageSettingFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
