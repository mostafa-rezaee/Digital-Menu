using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Common.Application.Validation;

namespace DigiMenu.Api.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [DisplayName("نصویر دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile Image { get; set; }


        [DisplayName("مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        public SeoDataViewModel SeoData { get; set; }
    }

    public class EditCategoryViewModel
    {
        public long Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [DisplayName("نصویر دسته بندی")]
        [FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile? Image { get; set; }


        [DisplayName("مخفی نباشد؟")]
        public bool IsVisible { get; set; }

        public SeoDataViewModel SeoData { get; set; }
    }
}
