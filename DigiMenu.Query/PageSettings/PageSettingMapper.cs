using DigiMenu.Domain.PageSettingAgg;
using DigiMenu.Query.PageSettings.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.PageSettings
{
    public static class PageSettingMapper
    {
        public static PageSettingDto Map(this PageSetting? pageSetting)
        {
            if (pageSetting == null) return null;
            return new PageSettingDto
            {
                PageTitle = pageSetting.PageTitle,
                BackgroundImageName = pageSetting.BackgroundImageName,
                LogoImageName = pageSetting.LogoImageName,
                SocialTitle = pageSetting.SocialTitle,
                SocialAddress = pageSetting.SocialAddress,
                Telephone = pageSetting.Telephone,
                Address = pageSetting.Address,
                WebsiteAddress = pageSetting.WebsiteAddress,
                Id = pageSetting.Id,
                CreateDate = pageSetting.CreateDate,
            };
        }
    }
}
