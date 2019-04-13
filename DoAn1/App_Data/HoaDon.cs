using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1.App_Data
{
    public class HoaDon
    {
        [Key]
        public int id { get; set; }
        public string TinhTrang { get; set; }
        public int TongTien { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SDTGiaoHang { get; set; }
        public string GhiChu { get; set; }
        public string NgayLapHD { get; set; }
        public string NgayHenGiaoHang { get; set; }
        public bool isDeleted { get; set; }
        public string idGioHang { get; set; }
        public GioHang GioHang { get; set; }
    }
}
