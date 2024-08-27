using Common.Query;
using DigiMenu.Query.PageSettings.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.PageSettings.Get
{
    public record GetPageSettingQuery : IQuery<PageSettingDto?>;
}
