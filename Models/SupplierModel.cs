using System.ComponentModel.DataAnnotations;

namespace StockManageMVC.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhà cung cấp")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhà cung cấp")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập sdt nhà cung cấp")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email nhà cung cấp")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; } 
    }
}
