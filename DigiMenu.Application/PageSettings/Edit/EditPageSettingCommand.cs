using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.PageSettings.Edit
{
    public record EditPageSettingCommand(long id, string pageTitle, IFormFile? backgroundImage, IFormFile? logoImage, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address) : IBaseCommand;
}
