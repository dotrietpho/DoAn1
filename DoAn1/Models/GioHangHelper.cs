using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn1.App_Data;

namespace DoAn1.Models
{
    public class GioHangHelper
    {

        public bool isGioHangTonTai(string userID)
        {
            using (var db = new DbContext())
            {
                if (db.GioHang.Where(p => p.IDGioHang == userID).FirstOrDefault() == null)
                    return false;
                return true;
            }
        }
        public bool TaoGioHang(string userID)
        {
            try
            {
                using (var db = new DbContext())
                {
                    db.GioHang.Add(new GioHang(userID));
                    db.SaveChanges();
                }
                return true;
            }
            catch 
            {
                return false;             
            }
        }

        public bool ThemSanPham(int idSach,string userID)
        {
            try
            {
                using (var db = new DbContext())
                {
                    db.ChiTietGioHang.Add(new ChiTietGioHang(userID, idSach));
                    db.SaveChanges();
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public bool XoaSanPham(int idSach, string userID)
        {
            try
            {
                using (var db = new DbContext())
                {
                    var a = db.ChiTietGioHang.Where(p => p.IDGioHang == userID && p.idSach == idSach).FirstOrDefault();
                    db.ChiTietGioHang.Remove(a);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public string TongTienGioHang(string userID)
        {
            try
            {
                int total = 0;
                using (var db = new DbContext())
                {
                    var q = from p in db.ChiTietGioHang
                            where p.IDGioHang == userID
                            from sach in db.Sach
                            where sach.id == p.idSach
                            select sach;
                    
                    foreach (var item in q)
                    {
                        total += item.GiaSach;
                    }
                }
                string s = string.Format("{0}", total);
                return s;
            }
            catch 
            {
                throw;
            }
        }

        public List<Sach> ChiTietGioHang(string userID)
        {
            try
            {
                using (var db = new DbContext())
                {
                    var q = from p in db.ChiTietGioHang
                            where p.IDGioHang == userID
                            from sach in db.Sach
                            where sach.id == p.idSach
                            select sach;

                    return q.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}