using Common.Application;
using DigiMenu.Application.PageSettings.Create;
using DigiMenu.Application.PageSettings.Edit;
using DigiMenu.Query.PageSettings.DTO;
using DigiMenu.Query.PageSettings.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.PageSettings
{
    internal class PageSettingFacade : IPageSettingFacade
    {
        private readonly IMediator mediator;

        public PageSettingFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult> Create(CreatePageSettingCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditPageSettingCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<PageSettingDto?> GetPageSettings()
        {
            return await mediator.Send(new GetPageSettingQuery());
        }
    }
}
