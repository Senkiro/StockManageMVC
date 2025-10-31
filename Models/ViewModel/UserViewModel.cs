using System.ComponentModel.DataAnnotations;

namespace StockManageMVC.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu ko đc để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
