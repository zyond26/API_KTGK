using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodsAPI.Models
{
    [Table("Goods")]
    public class HangHoa
    {
        [Key]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Mã hàng hóa phải có đúng 9 ký tự.")]
        public string MaHangHoa { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string TenHangHoa { get; set; }

        public int SoLuong { get; set; }

        public string? GhiChu { get; set; }
    }
}
