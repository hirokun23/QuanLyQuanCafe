using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class NhanVienForm : Form
    {
        string connStr = @"Data Source=DESKTOP-DJ9DDFC\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True";
        int rowIndex = -1;

        public NhanVienForm()
        {
            InitializeComponent();
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            // ❌ KHÔNG set ColumnCount nữa (vì bạn đã tạo trong Designer)

            // ❌ KHÔNG add Items nữa (Designer đã có Nam/Nữ rồi)
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int luong;

            if (!int.TryParse(txtLuong.Text.Trim(), out luong))
            {
                MessageBox.Show("Lương phải là số!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO NhanVien
                (TenNV, NgaySinh, SDT, GioiTinh, DiaChi, ChucVu, Luong)
                VALUES (@ten, @ngay, @sdt, @gt, @dc, @cv, @luong)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@ngay", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@gt", cbGioiTinh.SelectedItem != null ? cbGioiTinh.SelectedItem.ToString() : "");
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cv", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@luong", luong);

                cmd.ExecuteNonQuery();
            }

            dgvNhanVien.Rows.Add(
                txtTenNV.Text,
                dtNgaySinh.Value.ToShortDateString(),
                txtSDT.Text,
                cbGioiTinh.Text,
                txtDiaChi.Text,
                txtChucVu.Text,
                luong
            );

            ClearForm();
            MessageBox.Show("Đã lưu SQL!");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[rowIndex];

            txtTenNV.Text = row.Cells[1].Value?.ToString();
            dtNgaySinh.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            txtSDT.Text = row.Cells[3].Value?.ToString();

            // ✔ FIX đúng index
            cbGioiTinh.Text = row.Cells[4].Value?.ToString();
            txtDiaChi.Text = row.Cells[5].Value?.ToString();
            txtChucVu.Text = row.Cells[6].Value?.ToString();
            txtLuong.Text = row.Cells[7].Value?.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
                return;
            }

            string ten = dgvNhanVien.Rows[rowIndex].Cells[0].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM NhanVien WHERE TenNV=@ten";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", ten);

                cmd.ExecuteNonQuery();
            }

            dgvNhanVien.Rows.RemoveAt(rowIndex);
            ClearForm();
            rowIndex = -1;

            MessageBox.Show("Đã xóa SQL!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Chọn nhân viên để sửa!");
                return;
            }

            string oldTen = dgvNhanVien.Rows[rowIndex].Cells[0].Value.ToString();

            int luong;
            if (!int.TryParse(txtLuong.Text.Trim(), out luong))
            {
                MessageBox.Show("Lương phải là số!");
                return;
            }

            DataGridViewRow row = dgvNhanVien.Rows[rowIndex];

            row.Cells[0].Value = txtTenNV.Text;
            row.Cells[1].Value = dtNgaySinh.Value.ToShortDateString();
            row.Cells[2].Value = txtSDT.Text;
            row.Cells[3].Value = cbGioiTinh.Text;
            row.Cells[4].Value = txtDiaChi.Text;
            row.Cells[5].Value = txtChucVu.Text;
            row.Cells[6].Value = luong;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE NhanVien SET
                TenNV=@ten,
                NgaySinh=@ngay,
                SDT=@sdt,
                GioiTinh=@gt,
                DiaChi=@dc,
                ChucVu=@cv,
                Luong=@luong
                WHERE TenNV=@oldTen";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@ngay", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@gt", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cv", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@luong", luong);
                cmd.Parameters.AddWithValue("@oldTen", oldTen);

                cmd.ExecuteNonQuery();
            }

            ClearForm();
            rowIndex = -1;

            MessageBox.Show("Đã cập nhật SQL!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu dữ liệu (demo, chưa có SQL)");
        }

        void ClearForm()
        {
            txtTenNV.Clear();
            txtSDT.Clear();
            cbGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string ten = row.Cells[0].Value.ToString().ToLower();

                    if (ten.Contains(keyword))
                    {
                        dgvNhanVien.ClearSelection();
                        row.Selected = true;
                        dgvNhanVien.CurrentCell = row.Cells[0];
                        dgvNhanVien.FirstDisplayedScrollingRowIndex = row.Index;
                        return;
                    }
                }
            }

            MessageBox.Show("Không tìm thấy nhân viên!");
        }
    }
}