using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class fNhanVien : Form
    {
        string idLogin;
        private Font font = new Font("Segoe UI", 12, FontStyle.Bold);
        private Font fontSub = new Font("Segoe UI", 10, FontStyle.Regular);
        public int CornerRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
        public float BorderThickness { get; set; } = 0.5f;
        private Image[] avatars = new Image[5];
        private Point posThongTinPanel = new Point(3, 265);
        private Point posThemNhanVienPanel = new Point(730, 0);
        private int CongViecOrCaNhan = 1;
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
       
        bool _isAdmin;
        public fNhanVien(string idLogin)
        {
            InitializeComponent();

            panelThongTinCongViec.Location = posThongTinPanel;
            panelThongTinCaNhan.Location = posThongTinPanel;
            panelThongTinCaNhan.Visible = false;

            panelThemNhanVien.Location = posThemNhanVienPanel;
            panelThemNhanVien.Visible = false;

            panelBangXepHang.Visible = false;
            panelBangXepHang.Location = new Point(40, 22);

            ImportAvatar();


            this.idLogin = idLogin;

            if (idLogin.Contains("MNV"))
            {

                _isAdmin = false;
            }
            if (idLogin.Contains("QL"))
            {
                lblChucVu.Text = "Quản lý";
                _isAdmin = true;
            }

            dtpNgayBatDau.ValueChanged += (s, ev) =>
            {
                txtNgayBatDau.Text = dtpNgayBatDau.Value.ToString("dddd, dd/MM/yyyy");
            };
            SetupDataGridView();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                dgvNhanVien.Rows[0].Selected = true;
                dgvNhanVien_CellClick(dgvNhanVien, new DataGridViewCellEventArgs(0, 0));
            }
        }
        private void HienThiDSNhaVien()
        {
            List<NhanVienDTO> listNhanVien = _nhanVienBLL.LayDSNhanVien();
            ThemDuLieuPhuTung(listNhanVien);
        }
        private void ThemDuLieuPhuTung(List<NhanVienDTO> listNhanVien)
        {
            dgvNhanVien.Rows.Clear();

            foreach (var x in listNhanVien)
            {
                string _chucVu = "";
                if (x.MaNhanVien.Contains("MNV")){ 
                   lblChucVu.Text = _chucVu = "Nhân viên"; 
                }
                if (x.MaNhanVien.Contains("QL")) { 
                    lblChucVu.Text = _chucVu = "Quản lý"; 
                }
                dgvNhanVien.Rows.Add(x.MaNhanVien, x.GioiTinh, _chucVu, x.NgayBatDau.ToString("dd/MM/yyyy"));
            }
        }
        private void ImportAvatar()
        {
            avatars[0] = Properties.Resources.Avatar;
            avatars[1] = Properties.Resources.Avatar_1_;
            avatars[2] = Properties.Resources.Avatar_2_;
            avatars[3] = Properties.Resources.Avatar_3_;
            avatars[4] = Properties.Resources.Avatar_4_;
        }


        private void SetupDataGridView()
        {

            /*dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;*/
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.GridColor = SystemColors.Window;
            /*            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = dgvNhanVien.BackColor;
                        dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = dgvNhanVien.ForeColor;*/

            dgvNhanVien.DefaultCellStyle.SelectionBackColor = dgvNhanVien.DefaultCellStyle.BackColor;
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = dgvNhanVien.DefaultCellStyle.ForeColor;

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvNhanVien.Columns["TenNV"].FillWeight = 40;
            dgvNhanVien.Columns["NgayBatDau"].FillWeight = 40;
            dgvNhanVien.Columns["ChucVu"].FillWeight = 30;
            dgvNhanVien.Columns["GioiTinh"].FillWeight = 20;


            dgvNhanVien.RowTemplate.Height = 60;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.ColumnHeadersHeight = 60;


            HienThiDSNhaVien();

            dgvBXH.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvBXH.GridColor = SystemColors.Window;
            dgvBXH.EnableHeadersVisualStyles = false;
            dgvBXH.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
            dgvBXH.ColumnHeadersDefaultCellStyle.ForeColor = dgvBXH.ForeColor;

            dgvBXH.DefaultCellStyle.SelectionBackColor = dgvBXH.DefaultCellStyle.BackColor;
            dgvBXH.DefaultCellStyle.SelectionForeColor = dgvBXH.DefaultCellStyle.ForeColor;

            dgvBXH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn actionsColumn = new DataGridViewButtonColumn();
            actionsColumn.Name = "Actions";
            actionsColumn.HeaderText = "";
            actionsColumn.Text = "...";
            actionsColumn.UseColumnTextForButtonValue = true;
            dgvBXH.Columns.Add(actionsColumn);

            dgvBXH.Columns["ThuHang"].FillWeight = 10;
            dgvBXH.Columns["TenNhanVien"].FillWeight = 20;
            dgvBXH.Columns["MaNhanVien"].FillWeight = 15;
            dgvBXH.Columns["DiaChi"].FillWeight = 20;
            dgvBXH.Columns["YeuCau"].FillWeight = 15;
            dgvBXH.Columns["TongDoanhThu"].FillWeight = 15;
            dgvBXH.Columns["Actions"].FillWeight = 5;

            dgvBXH.RowTemplate.Height = 60;
            dgvBXH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBXH.ColumnHeadersHeight = 60;

            dgvBXH.Rows.Add("1", "Nguyễn Văn A", "NV001", "Hà Nội", "Yêu cầu 1", "1000000");
            dgvBXH.Rows.Add("2", "Trần Thị B", "NV002", "Hồ Chí Minh", "Yêu cầu 2", "1500000");
            dgvBXH.Rows.Add("3", "Phạm Văn C", "NV003", "Đà Nẵng", "Yêu cầu 3", "1200000");
            dgvBXH.Rows.Add("4", "Lê Thị D", "NV004", "Hải Phòng", "Yêu cầu 4", "1300000");
            dgvBXH.Rows.Add("5", "Hoàng Văn E", "NV005", "Cần Thơ", "Yêu cầu 5", "900000");
            dgvBXH.Rows.Add("6", "Đinh Thị F", "NV006", "Nha Trang", "Yêu cầu 6", "1100000");
            dgvBXH.Rows.Add("7", "Vũ Văn G", "NV007", "Huế", "Yêu cầu 7", "1700000");
            dgvBXH.Rows.Add("8", "Bùi Thị H", "NV008", "Quảng Ninh", "Yêu cầu 8", "950000");
            dgvBXH.Rows.Add("9", "Phan Văn I", "NV009", "Bình Dương", "Yêu cầu 9", "1250000");
            dgvBXH.Rows.Add("10", "Ngô Thị J", "NV010", "Bắc Giang", "Yêu cầu 10", "1400000");
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (dgvNhanVien.Columns[e.ColumnIndex].Name == "Luong")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }*/
        }

        private void dgvNhanVien_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Cuộn lên
                if (dgvNhanVien.FirstDisplayedScrollingRowIndex > 0)
                {
                    dgvNhanVien.FirstDisplayedScrollingRowIndex--;
                }
            }
            else if (e.Delta < 0)
            {
                // Cuộn xuống
                if (dgvNhanVien.FirstDisplayedScrollingRowIndex < dgvNhanVien.RowCount - 1)
                {
                    dgvNhanVien.FirstDisplayedScrollingRowIndex++;
                }
            }
        }


        private void dgvNhanVien_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                string cellValue = e.Value?.ToString() ?? string.Empty;
                if (cellValue != string.Empty)
                {
                    Rectangle rect = e.CellBounds;
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, rect.X, rect.Y + 15);
                }
            }
        }
        // 1 là cá nhân , 2 là công việc
        private void lblThongTin_Click(object sender, EventArgs e)
        {
            if(CongViecOrCaNhan == 1)
            {
                if (!_isAdmin && nhanVienChon != idLogin)
                {
                    MessageBox.Show("Bạn không xem được thông tin người khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblThongTin.Text = "Thông tin công việc";

                panelThongTinCaNhan.Visible = true;
                panelThongTinCongViec.Visible = false;

                CongViecOrCaNhan = 2;
            }
            else
            {
                
                lblThongTin.Text = "Thông tin cá nhân";

                panelThongTinCongViec.Visible = true;
                panelThongTinCaNhan.Visible = false;

                CongViecOrCaNhan = 1;
            }
        }

        private void lblBangXepHang_Click(object sender, EventArgs e)
        {
            panelBangXepHang.Visible = true;

            panel1.Visible = false;
            panelThongTin.Visible = false;
            panelThemNhanVien.Visible = false;
        }

        private void lblDanhSachNV_Click(object sender, EventArgs e)
        {
            panelBangXepHang.Visible = false;

            panel1.Visible = true;
            panelThongTin.Visible = true;
            panelThemNhanVien.Visible = false;
        }

        private void lblThemNhanVien_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Empty;
            txtNgaySinh.Text = string.Empty;
            rbtnNam.Checked = false;
            rbtnNu.Checked = false;
            txtDiaChi.Text = string.Empty;
            txtNgayBatDau.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtMa.Text = string.Empty;
            panelThemNhanVien.Visible = true;
            panelThongTin.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panelThongTin.Visible = true;
            panelThemNhanVien.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = DateTime.Parse(txtNgaySinh.Text);
            string diaChi = txtDiaChi.Text;
            string sdt = txtSoDienThoai.Text;
            DateTime ngayBatDau = DateTime.Parse(txtNgayBatDau.Text); 
            string trinhDo = combTrinhDo.Text;
            string ma = txtMa.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string gioiTinh = rbtnNam.Checked ? "Nam" : "Nữ";
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(trinhDo))
            {
                MessageBox.Show("Vui lòng chọn trình độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbtnNam.Checked && !rbtnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool themNv = _nhanVienBLL.ThemNhanVien(new NhanVienDTO(ma, hoTen, ngaySinh, trinhDo, gioiTinh, diaChi, soDienThoai, ngayBatDau));
            if (themNv)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblThemNhanVien_Click(sender, e);
            }
        }


        private void picAddImage_Click(object sender, EventArgs e)
        {

        }

        private void DrawRoundedPanel(Panel panel, int radius, Color borderColor, float borderThickness, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                g.DrawPath(pen, path);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel3, 15, BorderColor, BorderThickness, e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel4, 15, BorderColor, BorderThickness, e);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel5, 15, BorderColor, BorderThickness, e);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel6, 15, BorderColor, BorderThickness, e);
        }


        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel8, 15, BorderColor, BorderThickness, e);
        }


        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel10, 15, BorderColor, BorderThickness, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel2, 15, BorderColor, BorderThickness, e);
        }

        private void dgvBXH_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                string cellValue = e.Value?.ToString() ?? string.Empty;
                if (cellValue != string.Empty)
                {
                    Rectangle rect = e.CellBounds;
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, rect.X, rect.Y + 15);
                }
            }
        }

        private void dgvBXH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBXH.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRectangle = dgvBXH.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                cmsNhanVien.Show(dgvBXH, cellRectangle.Left, cellRectangle.Bottom - 20);
            }
        }
        string nhanVienChon;
        
        // hàm chọn thông tin theo hàng
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.White;
                }

                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightBlue;

                string maChon = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                nhanVienChon = maChon;

                lblTenNhanVien.Text = _nhanVienBLL.TimNhanVienTheoMa(maChon);
                 
                lblNgaySinh.Text = _nhanVienBLL.TimNgaySinh(maChon);
                lblDiaChi.Text = _nhanVienBLL.TimDiaChi(maChon);
                if (maChon.Contains("MNV"))
                {
                    lblVaiTro.Text = lblChucVu.Text  = "Nhân viên";
                }
                if (maChon.Contains("QL"))
                {
                    lblVaiTro.Text = lblChucVu.Text = "Quản lý";
                }
                lblSoDienThoai.Text = _nhanVienBLL.TimSoDienThoai(maChon);
                lblNgayBatDau.Text = _nhanVienBLL.TimNgayBatDau(maChon);

                lblLuong.Text = (int.Parse(_nhanVienBLL.TimTrinhDoTheoMa(maChon).Substring(2)) * 10000000).ToString("N0") + " VND";

                Random rand = new Random();
                lblCap1.Text = (rand.NextDouble() * 100).ToString("F2") + "%";
                lblCap2.Text = (rand.NextDouble() * 100).ToString("F2") + "%";
                lblCap3.Text = (rand.NextDouble() * 100).ToString("F2") + "%";
            }
        }


    }
}
