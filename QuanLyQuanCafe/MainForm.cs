using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void LoadForm(Form f)
        {
            panelMain.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            panelMain.Controls.Add(f);
            f.Show();
        }
        private void picturelogo_Click(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
            lblTitle.Text = "Home";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderForm());
            lblTitle.Text = "Bán hàng";
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            LoadForm(new NhanVienForm());
            lblTitle.Text = "Nhân viên";
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            LoadForm(new CategoryForm());
            lblTitle.Text = "Danh mục";
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            LoadForm(new ProductForm());
            lblTitle.Text = "Sản phẩm";
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            LoadForm(new TableForm());
            lblTitle.Text = "Quản lý bàn";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportForm());
            lblTitle.Text = "Thống kê";
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            LoadForm(new SalaryForm());
            lblTitle.Text = "Lương";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
        "Bạn có muốn thoát không?",
        "Thông báo",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
