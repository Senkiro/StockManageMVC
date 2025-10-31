using System.ComponentModel.DataAnnotations;

namespace StockManageMVC.Models.ViewModel
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu mới nếu muốn thay đổi")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
