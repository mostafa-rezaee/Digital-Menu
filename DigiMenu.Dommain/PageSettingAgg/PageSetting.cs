using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.PageSettingAgg
{
    public class PageSetting : AggregateRoot
    {
        public PageSetting(string pageTitle, string bGImageName, string logoImageName, string websiteAddress, 
                string socialTitle, string socialAddress, string telephone, string address)
        {
            PageTitle = pageTitle;
            BGImageName = bGImageName;
            LogoImageName = logoImageName;
            WebsiteAddress = websiteAddress;
            SocialTitle = socialTitle;
            SocialAddress = socialAddress;
            Telephone = telephone;
            Address = address;
        }

        public string PageTitle { get; private set; }
        public string BGImageName { get; private set; }
        public string LogoImageName{ get; private set; }
        public string WebsiteAddress { get; private set; }
        public string SocialTitle { get; private set; }
        public string SocialAddress { get; private set; }
        public string Telephone { get; private set; }
        public string Address { get; private set; }

        public void Edit(string pageTitle, string bGImageName, string logoImageName, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address)
        {
            PageTitle = pageTitle;
            BGImageName = bGImageName;
            LogoImageName = logoImageName;
            WebsiteAddress = websiteAddress;
            SocialTitle = socialTitle;
            SocialAddress = socialAddress;
            Telephone = telephone;
            Address = address;
        }


    }
}
