using System.Collections.Generic;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.BUS
{
    public class NhanVienBUS
    {
        NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVien> GetAll()
        {
            return dal.GetAll();
        }

        public void Insert(NhanVien nv)
        {
            dal.Insert(nv);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }
    }
}