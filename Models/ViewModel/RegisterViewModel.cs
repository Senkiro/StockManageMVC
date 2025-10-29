using System.ComponentModel.DataAnnotations;

namespace StockManageMVC.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email ko hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
