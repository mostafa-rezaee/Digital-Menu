using Common.Application;

namespace DigiMenu.Application.PageSettings.Create
{
    public record CreatePageSettingCommand(string pageTitle, string bGImageName, string logoImageName, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address) : IBaseCommand;
}
