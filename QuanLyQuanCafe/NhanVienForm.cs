using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class NhanVienForm : Form
    {
        // Chuỗi kết nối của bạn
        string connStr = @"Data Source=DESKTOP-DJ9DDFC\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True";

        // BƯỚC QUAN TRỌNG: Đưa DataAdapter và DataTable ra ngoài khai báo toàn cục 
        // để nút Save và hàm Tìm Kiếm có thể dùng chung
        SqlDataAdapter da;
        DataTable dt;

        public NhanVienForm()
        {
            InitializeComponent();
        }

        // 1. HÀM TẢI DỮ LIỆU TỪ SQL LÊN DATAGRIDVIEW
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(connStr);

            // Dùng DataAdapter (chiếc xe tải) để chở dữ liệu từ DB đổ vào DataTable (nhà bếp)
            da = new SqlDataAdapter("SELECT * FROM NhanVien", conn);

            // TRỢ LÝ TỰ ĐỘNG TẠO LỆNH THÊM/XÓA/SỬA CHO NÚT SAVE
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            dt = new DataTable();
            da.Fill(dt);

            // Xóa các cột (Column1, Column2...) bạn lỡ tạo tay trong Designer 
            // để tránh bị nhân đôi cột khi DataTable tự động map dữ liệu lên
            dgvNhanVien.Columns.Clear();

            // Gán dữ liệu cho DataGridView tự động hiển thị
            dgvNhanVien.DataSource = dt;
        }

        // 2. KHI MỞ FORM LÊN -> GỌI HÀM TẢI DỮ LIỆU
        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // 3. THÊM NHÂN VIÊN
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLuong.Text.Trim(), out int luong))
            {
                MessageBox.Show("Lương phải là số!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"INSERT INTO NhanVien (TenNV, NgaySinh, SDT, GioiTinh, DiaChi, ChucVu, Luong) 
                                 VALUES (@ten, @ngay, @sdt, @gt, @dc, @cv, @luong)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@ngay", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@gt", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cv", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@luong", luong);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã thêm thành công!");
            ClearForm();
            LoadData(); // Thêm xong gọi hàm Load lại để DataGridView tự cập nhật
        }

        // 4. CLICK VÀO LƯỚI ĐỂ ĐỔ DỮ LIỆU LÊN TEXTBOX
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Dùng Tên Cột từ SQL để map chính xác dữ liệu vào textbox
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                dtNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                cbGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtLuong.Text = row.Cells["Luong"].Value.ToString();
            }
        }

        // 5. SỬA NHÂN VIÊN
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLuong.Text.Trim(), out int luong)) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"UPDATE NhanVien SET NgaySinh=@ngay, SDT=@sdt, GioiTinh=@gt, 
                                 DiaChi=@dc, ChucVu=@cv, Luong=@luong WHERE TenNV=@ten";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text); // Khóa tìm kiếm
                cmd.Parameters.AddWithValue("@ngay", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@gt", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@cv", txtChucVu.Text);
                cmd.Parameters.AddWithValue("@luong", luong);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã cập nhật thành công!");
            ClearForm();
            LoadData(); // Cập nhật lại lưới
        }

        // 6. XÓA NHÂN VIÊN
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa cho chuyên nghiệp
            DialogResult dtResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dtResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM NhanVien WHERE TenNV=@ten";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", txtTenNV.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xóa thành công!");
                ClearForm();
                LoadData();
            }
        }

        // 7. TÌM KIẾM NHÂN VIÊN
        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM NhanVien WHERE TenNV LIKE @tuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuKhoa", "%" + keyword + "%");

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                dgvNhanVien.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                    LoadData(); // Tải lại danh sách nếu không tìm thấy
                }
            }
        }

        // 8. NÚT LƯU ĐỒNG BỘ TOÀN BỘ THAY ĐỔI TRÊN LƯỚI LÊN SQL
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết thúc việc edit trên lưới (nếu người dùng đang gõ dở dang)
                dgvNhanVien.EndEdit();

                // Lấy những thay đổi trên DataTable (Thêm/Sửa/Xóa) đẩy về SQL
                if (da != null && dt != null)
                {
                    da.Update(dt);
                    MessageBox.Show("Đã lưu toàn bộ thay đổi vào CSDL thành công!", "Thông báo");
                    LoadData(); // Tải lại cho chắc chắn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: \n" + ex.Message, "Lỗi");
            }
        }

        // 9. HÀM XÓA TRẮNG FORM
        private void ClearForm()
        {
            txtTenNV.Clear();
            txtSDT.Clear();
            cbGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
        }
    }
}