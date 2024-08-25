using Common.Application;
using Microsoft.AspNetCore.Http;

namespace DigiMenu.Application.PageSettings.Create
{
    public record CreatePageSettingCommand(string pageTitle, IFormFile backgroundImage, IFormFile logoImage, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address) : IBaseCommand;
}
