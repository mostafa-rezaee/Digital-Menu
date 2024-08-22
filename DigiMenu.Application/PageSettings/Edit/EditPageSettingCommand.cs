using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.PageSettings.Edit
{
    public record EditPageSettingCommand(string pageTitle, string bGImageName, string logoImageName, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address) : IBaseCommand;
}
