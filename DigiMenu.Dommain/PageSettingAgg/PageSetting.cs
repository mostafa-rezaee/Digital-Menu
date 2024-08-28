using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.PageSettingAgg
{
    public class PageSetting : AggregateRoot
    {
        private PageSetting() { }
        public PageSetting(string pageTitle, string backroundImageName, string logoImageName, string websiteAddress, 
                string socialTitle, string socialAddress, string telephone, string address)
        {
            PageTitle = pageTitle;
            BackgroundImageName = backroundImageName;
            LogoImageName = logoImageName;
            WebsiteAddress = websiteAddress;
            SocialTitle = socialTitle;
            SocialAddress = socialAddress;
            Telephone = telephone;
            Address = address;
        }

        public string PageTitle { get; private set; }
        public string BackgroundImageName { get; private set; }
        public string LogoImageName{ get; private set; }
        public string WebsiteAddress { get; private set; }
        public string SocialTitle { get; private set; }
        public string SocialAddress { get; private set; }
        public string Telephone { get; private set; }
        public string Address { get; private set; }

        public void Edit(string pageTitle, string websiteAddress,
                string socialTitle, string socialAddress, string telephone, string address)
        {
            PageTitle = pageTitle;
            WebsiteAddress = websiteAddress;
            SocialTitle = socialTitle;
            SocialAddress = socialAddress;
            Telephone = telephone;
            Address = address;
        }

        public void SetBackgroundImage(string backgroundImage)
        {
            NullOrEmptyException.CheckNotEmpty(backgroundImage, nameof(backgroundImage));
            BackgroundImageName = backgroundImage;
        }

        public void SetLogoImage(string logoImage)
        {
            NullOrEmptyException.CheckNotEmpty(logoImage, nameof(logoImage));
            LogoImageName = logoImage;
        }


    }
}
