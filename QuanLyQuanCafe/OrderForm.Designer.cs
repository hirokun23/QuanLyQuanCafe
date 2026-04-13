namespace QuanLyQuanCafe
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboStaff = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtExtra = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();

            // ================= LEFT - BÀN =================
            this.flowLayoutPanelTable.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanelTable.Size = new System.Drawing.Size(700, 500);
            this.flowLayoutPanelTable.AutoScroll = true;

            // ================= RIGHT PANEL =================
            this.panelRight.Location = new System.Drawing.Point(720, 10);
            this.panelRight.Size = new System.Drawing.Size(350, 500);
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Title
            this.lblTitle.Text = "Chi tiết hóa đơn";
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            // Combo khách hàng
            this.cboCustomer.Location = new System.Drawing.Point(10, 50);
            this.cboCustomer.Size = new System.Drawing.Size(300, 25);
            this.cboCustomer.Text = "Khách hàng";

            // Combo nhân viên
            this.cboStaff.Location = new System.Drawing.Point(10, 90);
            this.cboStaff.Size = new System.Drawing.Size(300, 25);
            this.cboStaff.Text = "Nhân viên";

            // Button
            this.btnAdd.Text = "Chọn món";
            this.btnAdd.BackColor = System.Drawing.Color.Green;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 130);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);

            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.BackColor = System.Drawing.Color.Orange;
            this.btnEdit.Location = new System.Drawing.Point(110, 130);
            this.btnEdit.Size = new System.Drawing.Size(90, 30);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(210, 130);
            this.btnDelete.Size = new System.Drawing.Size(90, 30);

            // DataGridView
            this.dgvBill.Location = new System.Drawing.Point(10, 170);
            this.dgvBill.Size = new System.Drawing.Size(320, 200);
            this.dgvBill.ColumnCount = 4;
            this.dgvBill.Columns[0].Name = "STT";
            this.dgvBill.Columns[1].Name = "Thực đơn";
            this.dgvBill.Columns[2].Name = "Đơn giá";
            this.dgvBill.Columns[3].Name = "SL";

            // Giảm giá
            this.txtDiscount.Location = new System.Drawing.Point(10, 380);
            this.txtDiscount.Size = new System.Drawing.Size(150, 22);
            this.txtDiscount.Text = "0";

            // Phụ thu
            this.txtExtra.Location = new System.Drawing.Point(180, 380);
            this.txtExtra.Size = new System.Drawing.Size(150, 22);
            this.txtExtra.Text = "0";

            // Thành tiền
            this.txtTotal.Location = new System.Drawing.Point(10, 420);
            this.txtTotal.Size = new System.Drawing.Size(320, 25);
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Text = "0";

            // Button thanh toán
            this.btnPay.Text = "Yêu cầu thanh toán";
            this.btnPay.BackColor = System.Drawing.Color.Blue;
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(10, 460);
            this.btnPay.Size = new System.Drawing.Size(150, 30);

            // Button hủy
            this.btnCancel.Text = "Hủy hóa đơn";
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(180, 460);
            this.btnCancel.Size = new System.Drawing.Size(150, 30);

            // Add control vào panel phải
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Controls.Add(this.cboCustomer);
            this.panelRight.Controls.Add(this.cboStaff);
            this.panelRight.Controls.Add(this.btnAdd);
            this.panelRight.Controls.Add(this.btnEdit);
            this.panelRight.Controls.Add(this.btnDelete);
            this.panelRight.Controls.Add(this.dgvBill);
            this.panelRight.Controls.Add(this.txtDiscount);
            this.panelRight.Controls.Add(this.txtExtra);
            this.panelRight.Controls.Add(this.txtTotal);
            this.panelRight.Controls.Add(this.btnPay);
            this.panelRight.Controls.Add(this.btnCancel);

            // Add vào form
            this.Controls.Add(this.flowLayoutPanelTable);
            this.Controls.Add(this.panelRight);

            // Form
            this.Text = "Quản lý quán cà phê";
            this.ClientSize = new System.Drawing.Size(1100, 550);

            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTable;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboStaff;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtExtra;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
    }
}