using DigiMenu.Domain.PageSettingAgg;
using DigiMenu.Infrastracture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.PageSettingAgg
{
    internal class PageSettingRepository : BaseRepository<PageSetting>, IPageSettingRepository
    {
        public PageSettingRepository(DigiMenuContext context) : base(context)
        {
        }
    }
}
