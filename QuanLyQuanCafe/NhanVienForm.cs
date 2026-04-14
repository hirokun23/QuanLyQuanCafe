
using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class NhanVienForm : Form
    {
        int rowIndex = -1;

        public NhanVienForm()
        {
            InitializeComponent();
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            // Tạo cột cho bảng
            dgvNhanVien.ColumnCount = 6;
            dgvNhanVien.Columns[0].Name = "Tên NV";
            dgvNhanVien.Columns[1].Name = "Ngày sinh";
            dgvNhanVien.Columns[2].Name = "SĐT";
            dgvNhanVien.Columns[3].Name = "Địa chỉ";
            dgvNhanVien.Columns[4].Name = "Chức vụ";
            dgvNhanVien.Columns[5].Name = "Lương";

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            dgvNhanVien.Rows.Add(
                 txtTenNV.Text,
                 dtNgaySinh.Value.ToShortDateString(),
                 txtSDT.Text,
                 txtDiaChi.Text,
                 txtChucVu.Text,
                 txtLuong.Text
             );

            ClearForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[rowIndex];

                txtTenNV.Text = row.Cells[0].Value.ToString();
                dtNgaySinh.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                txtSDT.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                txtChucVu.Text = row.Cells[4].Value.ToString();
                txtLuong.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                dgvNhanVien.Rows.RemoveAt(rowIndex);
                ClearForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu dữ liệu (demo, chưa có SQL)");
        }
        void ClearForm()
        {
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
            cbGioiTinh.SelectedIndex = -1;
        }
    }
}