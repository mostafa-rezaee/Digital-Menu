using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.PageSettings.DTO
{
    public class PageSettingDto : BaseDto
    {
        public string PageTitle { get; set; }
        public string BackgroundImageName { get; set; }
        public string LogoImageName { get; set; }
        public string WebsiteAddress { get; set; }
        public string SocialTitle { get; set; }
        public string SocialAddress { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
    }
}
