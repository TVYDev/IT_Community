using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace CommunityWeb.Models
{
    public class UserNameChangeModel
    {
        [Required]
        [Display(Name = "ឈ្មោះថ្មី")]
        public string NewUserName { get; set; }
    }
    public class UserChangeProfileModel
    {
        [Required]
        [Display(Name = "រូបភាពថ្មី")]
        public string NewImgURL { get; set; }
    }

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "ត្រូវមានចំនួនពាក្យចាំពី{0} {2} ឡើងទៅ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់ថ្មី")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "បញ្ចាក់លេខសំងាត់ថ្មី")]
        [Compare("NewPassword", ErrorMessage = "ផ្ទៀងផ្ទាត់លេខសំងាត់ថ្មីម្ដងទៀត")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់ចាស់")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "ត្រូវមានចំនួនពាក្យចាំពី{0} {2} ឡើងទៅ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់ថ្មី")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "បញ្ចាក់លេខសំងាត់ថ្មី")]
        [Compare("NewPassword", ErrorMessage = "ផ្ទៀងផ្ទាត់លេខសំងាត់ថ្មីម្ដងទៀត")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "លេខទូរស័ព្ទ")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "កូដ")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "លេខទូរស័ព្ទ")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}