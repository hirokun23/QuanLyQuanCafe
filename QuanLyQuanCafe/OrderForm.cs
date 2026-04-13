using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        // ================= LOAD BÀN =================
        void LoadTable()
        {
            flowLayoutPanelTable.Controls.Clear();

            int soBan = 20;

            for (int i = 1; i <= soBan; i++)
            {
                Button btn = new Button();

                btn.Width = 80;
                btn.Height = 80;
                btn.Margin = new Padding(5);

                btn.Text = "Bàn " + i;
                btn.Tag = i;

                // giả lập trạng thái
                bool coNguoi = (i % 4 == 0);

                if (coNguoi)
                    btn.BackColor = Color.Orange;
                else
                    btn.BackColor = Color.LightBlue;

                btn.Click += Btn_Click;

                flowLayoutPanelTable.Controls.Add(btn);
            }
        }

        // ================= CLICK BÀN =================
        void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int maBan = (int)btn.Tag;

            lblTitle.Text = "Chi tiết hóa đơn - Bàn " + maBan;

            LoadBill(maBan);
        }

        // ================= LOAD HÓA ĐƠN =================
        void LoadBill(int maBan)
        {
            dgvBill.Rows.Clear();

            // giả lập dữ liệu
            dgvBill.Rows.Add("1", "Cà phê sữa", "20000", "2");
            dgvBill.Rows.Add("2", "Trà đào", "30000", "1");

            TinhTien();
        }

        // ================= TÍNH TIỀN =================
        void TinhTien()
        {
            int tong = 0;

            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    int gia = Convert.ToInt32(row.Cells[2].Value);
                    int sl = Convert.ToInt32(row.Cells[3].Value);

                    tong += gia * sl;
                }
            }

            int giam = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : Convert.ToInt32(txtDiscount.Text);
            int phuthu = string.IsNullOrEmpty(txtExtra.Text) ? 0 : Convert.ToInt32(txtExtra.Text);

            int thanhTien = tong - giam + phuthu;

            txtTotal.Text = thanhTien.ToString();
        }

        // ================= NÚT =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Add("3", "Bạc xỉu", "25000", "1");
            TinhTien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                dgvBill.Rows.RemoveAt(dgvBill.SelectedRows[0].Index);
                TinhTien();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán thành công!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvBill.Rows.Clear();
            txtTotal.Text = "0";
        }
    }
}