using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class LoginForm : Form
    {
        // Chuỗi kết nối của bạn
        private string connStr = @"Data Source=HUYLE\SQLEXPRESS2012;Initial Catalog=QLCF;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
            SetupSplitScreenUI();
            this.AcceptButton = btnLogin;
        }

        private void SetupSplitScreenUI()
        {
            // 1. Cấu hình Form (Bỏ viền, chỉnh Size)
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2. Nửa bên Trái - Khu vực quảng cáo / Banner
            Panel pnlLeft = new Panel();
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 400;
            pnlLeft.BackColor = Color.FromArgb(141, 110, 99);

            // THÊM DÒNG NÀY VÀO ĐỂ GỌI ẢNH:
            pnlLeft.BackgroundImage = Properties.Resources.anh_cafe; // Thay "anh_cafe" bằng tên ảnh của bạn

            pnlLeft.BackgroundImageLayout = ImageLayout.Stretch; // Dùng Stretch để ảnh phủ kín toàn bộ khung trái
            this.Controls.Add(pnlLeft);

            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to\nCoffee Manager";
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = true;

            // THÊM DÒNG NÀY ĐỂ XÓA CÁI CỤC MÀU NÂU XẤU XÍ ĐI:
            lblWelcome.BackColor = Color.Transparent;

            lblWelcome.Location = new Point(5, 60);
            pnlLeft.Controls.Add(lblWelcome);

            // 3. Nửa bên Phải - Đã fix lỗi che khuất (Dùng DockStyle.Right)
            Panel pnlRight = new Panel();
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Width = 400;
            pnlRight.BackColor = Color.White;
            this.Controls.Add(pnlRight);

            // Tạo nút X để thoát
            Label lblClose = new Label();
            lblClose.Text = "✕";
            lblClose.ForeColor = Color.Gray;
            lblClose.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblClose.Location = new Point(360, 10);
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += (s, e) => Application.Exit();
            lblClose.MouseEnter += (s, e) => lblClose.ForeColor = Color.Red;
            lblClose.MouseLeave += (s, e) => lblClose.ForeColor = Color.Gray;
            pnlRight.Controls.Add(lblClose);

            Label lblTitle = new Label();
            lblTitle.Text = "ĐĂNG NHẬP";
            lblTitle.ForeColor = Color.FromArgb(62, 39, 35);
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 70);
            lblTitle.AutoSize = true;
            pnlRight.Controls.Add(lblTitle);

            // 4. Kéo giãn TextBox và vẽ gạch chân
            StyleModernInput(txtUser, "Tài khoản", 160, pnlRight);
            StyleModernInput(txtPass, "Mật khẩu", 250, pnlRight);

            // ==========================================
            // THÊM CHECKBOX "NHỚ MẬT KHẨU" Ở ĐÂY
            // ==========================================
            CheckBox chkRemember = new CheckBox();
            chkRemember.Text = "Nhớ mật khẩu";
            chkRemember.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            chkRemember.ForeColor = Color.Gray;
            chkRemember.AutoSize = true;
            chkRemember.Location = new Point(47, 295); // Nằm ngay dưới ô Mật khẩu
            chkRemember.Cursor = Cursors.Hand;
            pnlRight.Controls.Add(chkRemember);

            // 5. Cấu hình Nút đăng nhập
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(121, 85, 72);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Size = new Size(280, 45);
            btnLogin.Location = new Point(50, 340); // Đẩy nút này xuống một chút nhường chỗ cho Checkbox
            btnLogin.Text = "Đăng nhập";
            btnLogin.Cursor = Cursors.Hand;
            pnlRight.Controls.Add(btnLogin);
        }

        // Hàm hỗ trợ vẽ TextBox "không viền" kiểu hiện đại
        private void StyleModernInput(TextBox tb, string placeholder, int y, Panel parent)
        {
            Label lbl = new Label();
            lbl.Text = placeholder;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lbl.ForeColor = Color.Gray;
            lbl.Location = new Point(47, y - 25);
            lbl.AutoSize = true;
            parent.Controls.Add(lbl);

            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
            tb.BorderStyle = BorderStyle.None;
            tb.Font = new Font("Segoe UI", 12F);
            tb.Location = new Point(50, y);
            tb.Size = new Size(280, 25);
            parent.Controls.Add(tb);
            tb.BringToFront();

            Panel line = new Panel();
            line.BackColor = Color.FromArgb(200, 200, 200);
            line.Size = new Size(280, 2);
            line.Location = new Point(50, y + tb.Height + 2);
            parent.Controls.Add(line);
        }

        // Logic check DB
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap=@user AND MatKhau=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUser.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        this.Hide();
                        MainForm f = new MainForm();
                        f.FormClosed += (s, args) => this.Close();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        // Cho phép cầm chuột kéo thả form
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84 && (int)m.Result == 0x1) m.Result = (IntPtr)0x2;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}