using Common.Application;
using DigiMenu.Application.PageSettings.Create;
using DigiMenu.Application.PageSettings.Edit;
using DigiMenu.Query.PageSettings.DTO;
using DigiMenu.Query.PageSettings.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.PageSettings
{
    public interface IPageSettingFacade
    {
        //Commands
        Task<OperationResult> Create(CreatePageSettingCommand command);
        Task<OperationResult> Edit(EditPageSettingCommand command);


        //Queries
        Task<PageSettingDto?> GetPageSettings();
    }
}
