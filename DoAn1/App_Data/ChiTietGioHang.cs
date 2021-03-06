﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1.App_Data
{
    public class ChiTietGioHang
    {
        [Key]
        [Column(Order = 1)]
        public string IDGioHang { get; set; }
        [Key]
        [Column(Order = 2)]
        public int idSach { get; set; }

        public GioHang GioHang { get; set; }
        public Sach Sach { get; set; }

        public ChiTietGioHang(string idGioHang, int idSach)
        {
            this.IDGioHang = idGioHang;
            this.idSach = idSach;
        }
        public ChiTietGioHang() { }
    }
}
