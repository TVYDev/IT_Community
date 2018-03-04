using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace CommunityWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "អ៊ីម៉ែល")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "ឈ្មោះ")]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name = "រូបភាព")]
        public string ImgFromExternal { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "ចងចាំសំរាប់browserនេះ?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "អ៊ីម៉ែល")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "ឈ្មោះ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់")]
        public string Password { get; set; }

        [Display(Name = "ចងចាំសំរាប់browserនេះ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        
        [Required]
        [Display(Name = "ឈ្មោះ")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "អ៊ីម៉ែល")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "បញ្ចាក់ លេខសំងាត់")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "រូបភាព")]
        public string ImgUrl { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "អ៊ីម៉ែល")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "លេខសំងាត់")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "បញ្ចាក់ លេខសំងាត់")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "អ៊ីម៉ែល")]
        public string Email { get; set; }
    }
}
