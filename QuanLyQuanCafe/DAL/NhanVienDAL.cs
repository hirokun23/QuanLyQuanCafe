using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVien> GetAll()
        {
            List<NhanVien> list = new List<NhanVien>();

            using (var conn = DB.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new NhanVien
                    {
                        MaNV = (int)r["MaNV"],
                        TenNV = r["TenNV"].ToString(),
                        SDT = r["SDT"].ToString(),
                        DiaChi = r["DiaChi"].ToString(),
                        GioiTinh = r["GioiTinh"].ToString(),
                        NgaySinh = (System.DateTime)r["NgaySinh"],
                        VaiTro = r["VaiTro"].ToString(),
                        Luong = (decimal)r["Luong"],
                        TaiKhoan = r["TaiKhoan"].ToString(),
                        MatKhau = r["MatKhau"].ToString()
                    });
                }
            }

            return list;
        }

        public void Insert(NhanVien nv)
        {
            using (var conn = DB.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO NhanVien 
                VALUES (@ten,@sdt,@dc,@gt,@ns,@vt,@luong,@tk,@mk)", conn);

                cmd.Parameters.AddWithValue("@ten", nv.TenNV);
                cmd.Parameters.AddWithValue("@sdt", nv.SDT);
                cmd.Parameters.AddWithValue("@dc", nv.DiaChi);
                cmd.Parameters.AddWithValue("@gt", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@ns", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@vt", nv.VaiTro);
                cmd.Parameters.AddWithValue("@luong", nv.Luong);
                cmd.Parameters.AddWithValue("@tk", nv.TaiKhoan);
                cmd.Parameters.AddWithValue("@mk", nv.MatKhau);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DB.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM NhanVien WHERE MaNV=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}