using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class NhanVienForm : Form
    {
        NhanVienBUS bus = new NhanVienBUS();
        int idSelected = -1;

        public NhanVienForm()
        {
            InitializeComponent();
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            dgvNhanVien.Rows.Clear();

            foreach (var nv in bus.GetAll())
            {
                dgvNhanVien.Rows.Add(
                    nv.MaNV,
                    nv.TenNV,
                    nv.SDT,
                    nv.DiaChi,
                    nv.GioiTinh,
                    nv.NgaySinh.ToString("dd/MM/yyyy"),
                    nv.VaiTro,
                    nv.Luong,
                    nv.TaiKhoan,
                    nv.MatKhau
                );
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            bus.Insert(new NhanVien
            {
                TenNV = lblTenNV.Text,
                SDT = lblSDT.Text,
                DiaChi = lblDiaChi.Text,
                GioiTinh = lblGioiTinh.Text,
                NgaySinh = dtpNgaySinh.Value,
                VaiTro = txtVaiTro.Text,
                Luong = decimal.Parse(txtLuong.Text),
                TaiKhoan = txtMatKhau.Text,
                MatKhau = txtMatKhau.Text
            });

            LoadData();
        }

        // ================= SEARCH (QUAY VỀ BUS HOẶC DAL SAU) =================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();

            dgvNhanVien.Rows.Clear();

            foreach (var nv in bus.GetAll())
            {
                if (nv.TenNV.Contains(key))
                {
                    dgvNhanVien.Rows.Add(
                        nv.MaNV,
                        nv.TenNV,
                        nv.SDT,
                        nv.DiaChi,
                        nv.GioiTinh,
                        nv.NgaySinh.ToString("dd/MM/yyyy"),
                        nv.VaiTro,
                        nv.Luong,
                        nv.TaiKhoan,
                        nv.MatKhau
                    );
                }
            }
        }

        // ================= CLICK ROW =================
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idSelected = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value);

            lblTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
            lblDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            lblGioiTinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells[5].Value);
            txtVaiTro.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtLuong.Text = dgvNhanVien.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idSelected == -1) return;

            bus.Delete(idSelected);
            LoadData();
        }
    }
}