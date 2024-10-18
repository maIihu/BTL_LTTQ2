using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        List<NhanVienDTO> listNhanVien;
        private NhanVienBLL _nhanVienBLL;
        public fNhanVien(string idLogin)
        {
            InitializeComponent();
            _nhanVienBLL = new NhanVienBLL();
            panelThongTinCongViec.Location = posThongTinPanel;
            panelThongTinCaNhan.Location = posThongTinPanel;
            panelThongTinCaNhan.Visible = false;

            panelThemNhanVien.Location = posThemNhanVienPanel;
            panelThemNhanVien.Visible = false;

            panelBangXepHang.Visible = false;
            panelBangXepHang.Location = new Point(40, 22);

            ImportAvatar();

            SetupDataGridView();
            this.idLogin = idLogin;

            LoadDataNhanVien();

            dtpNgayBatDau.ValueChanged += (s, ev) =>
            {
                txtNgayBatDau.Text = dtpNgayBatDau.Value.ToString("dddd, dd/MM/yyyy");
            };
        }
        private void LoadDataNhanVien()
        {
            // Lấy danh sách nhân viên từ BLL
            listNhanVien = _nhanVienBLL.LayDSNhanVien();

            foreach(var item in listNhanVien)
            {
                dgvNhanVien.Rows.Add(item.TenNhanVien, item.NgayBatDau, item.LuongCoBan);
            }

            // Gán danh sách vào DataGridView
            //dgvNhanVien.DataSource = listNhanVien;
        }
        private void ImportAvatar()
        {
            avatars[0] = Properties.Resources.Avatar;
            avatars[1] = Properties.Resources.Avatar_1_;
            avatars[2] = Properties.Resources.Avatar_2_;
            avatars[3] = Properties.Resources.Avatar_3_;
            avatars[4] = Properties.Resources.Avatar_4_;
        }

        public int RandId(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
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
            dgvNhanVien.Columns["Luong"].FillWeight = 20;

            /*dgvNhanVien.Columns["Luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
*/
            dgvNhanVien.RowTemplate.Height = 60;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.ColumnHeadersHeight = 60;
            /*
            dgvNhanVien.Rows.Add("Arlene McCoy\nWorker", "Mar 1, 2022\nJoined from 235 days", "$1,546\n1 Jun 2022");
            dgvNhanVien.Rows.Add("John Doe\nManager", "Feb 15, 2021\nJoined from 600 days", "$2,345\n5 Mar 2022");
            dgvNhanVien.Rows.Add("Jane Smith\nEngineer", "Jul 10, 2020\nJoined from 800 days", "$3,250\n12 Dec 2021");
            dgvNhanVien.Rows.Add("Michael Johnson\nTechnician", "Apr 23, 2021\nJoined from 500 days", "$1,850\n10 May 2022");
            dgvNhanVien.Rows.Add("Emily Davis\nDesigner", "Oct 5, 2022\nJoined from 180 days", "$1,750\n15 Nov 2022");
            dgvNhanVien.Rows.Add("Sarah Lee\nMarketing", "Jan 10, 2023\nJoined from 90 days", "$1,400\n1 Apr 2023");
            dgvNhanVien.Rows.Add("David Brown\nHR", "Dec 15, 2021\nJoined from 400 days", "$2,100\n20 Jan 2022");
            dgvNhanVien.Rows.Add("Laura Wilson\nSales", "Jun 17, 2020\nJoined from 950 days", "$2,800\n7 Feb 2021");
            dgvNhanVien.Rows.Add("Chris White\nSupport", "Sep 3, 2022\nJoined from 200 days", "$1,500\n22 Sep 2022");
            dgvNhanVien.Rows.Add("Megan Thompson\nAnalyst", "May 25, 2021\nJoined from 480 days", "$2,050\n1 Jul 2021");
            dgvNhanVien.Rows.Add("Paul Walker\nSupervisor", "Nov 15, 2020\nJoined from 750 days", "$3,500\n25 Jan 2021");
            dgvNhanVien.Rows.Add("Sophia Martinez\nAccountant", "Dec 1, 2019\nJoined from 1000 days", "$2,900\n10 Dec 2019");
            dgvNhanVien.Rows.Add("Alexander Kim\nConsultant", "Mar 18, 2022\nJoined from 230 days", "$3,200\n15 Mar 2022");
            dgvNhanVien.Rows.Add("Olivia Hernandez\nDeveloper", "Jul 27, 2021\nJoined from 400 days", "$2,600\n22 Sep 2021");
            dgvNhanVien.Rows.Add("Benjamin Carter\nArchitect", "Jan 5, 2020\nJoined from 900 days", "$4,100\n10 Feb 2020");
            dgvNhanVien.Rows.Add("Victoria Evans\nNurse", "May 22, 2022\nJoined from 160 days", "$1,950\n1 Jun 2022");
            dgvNhanVien.Rows.Add("James Russell\nScientist", "Aug 14, 2019\nJoined from 1100 days", "$5,200\n15 Sep 2019");
            dgvNhanVien.Rows.Add("Ella Murphy\nReceptionist", "Oct 3, 2021\nJoined from 365 days", "$1,300\n20 Oct 2021");
            dgvNhanVien.Rows.Add("Henry Rodriguez\nTeacher", "Feb 25, 2021\nJoined from 600 days", "$2,450\n5 Mar 2021");
            dgvNhanVien.Rows.Add("Ava Bennett\nLawyer", "Apr 18, 2020\nJoined from 820 days", "$3,750\n22 Apr 2020");
            */

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

                if (e.ColumnIndex == dgvNhanVien.Columns["TenNV"].Index &&
                    dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value != null)
                {
                    Rectangle rect = e.CellBounds;

                    Image img = avatars[RandId(0, 5)];
                    Rectangle imgRect = new Rectangle(rect.X + 5, rect.Y + 5, 40, 40);
                    e.Graphics.DrawImage(img, imgRect);

                    string[] parts = ((string)dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value).Split('\n');
                    string p1 = parts[0];
                    //string p2 = parts[1];


                    e.Graphics.DrawString(p1, font, Brushes.Black, rect.X + 50, rect.Y + 5);
                    //e.Graphics.DrawString(p2, fontSub, Brushes.Gray, rect.X + 50, rect.Y + 25);
                }
                else if (e.ColumnIndex == dgvNhanVien.Columns["NgayBatDau"].Index &&
                    dgvNhanVien.Rows[e.RowIndex].Cells["NgayBatDau"].Value != null)
                {
                    Rectangle rect = e.CellBounds;

                    //string[] parts = ((string)dgvNhanVien.Rows[e.RowIndex].Cells["NgayBatDau"].Value).Split('\n');
                    //string p1 = parts[0];
                    //string p2 = parts[1];

                    //e.Graphics.DrawString(p1, font, Brushes.Black, rect.X, rect.Y + 5);
                    //e.Graphics.DrawString(p2, fontSub, Brushes.Gray, rect.X, rect.Y + 25);
                }
                else if (e.ColumnIndex == dgvNhanVien.Columns["Luong"].Index &&
                    dgvNhanVien.Rows[e.RowIndex].Cells["Luong"].Value != null)
                {
                    Rectangle rect = e.CellBounds;

                    //string[] parts = ((string)dgvNhanVien.Rows[e.RowIndex].Cells["Luong"].Value).Split('\n');
                    //string p1 = parts[0];
                    //string p2 = parts[1];

                    //e.Graphics.DrawString(p1, font, Brushes.Black, rect.X, rect.Y + 5);
                    //e.Graphics.DrawString(p2, fontSub, Brushes.Gray, rect.X, rect.Y + 25);
                }
            }
        }

        private void lblThongTin_Click(object sender, EventArgs e)
        {
            if(CongViecOrCaNhan == 1)
            {
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
            txtChucVu.Text = string.Empty;
            txtNgayBatDau.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtLuongCoBan.Text = string.Empty;

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

           
            // Kiểm tra dữ liệu đầu vào
           /* if (txtHoTen.Text == "") { lbWarningHoTen.Visible = true; return; }
            if (txtNgaySinh.Text == "") { lbWarningNgaySinh.Visible = true; return; }
            if (txtDiaChi.Text == "") { lbWarningDiaChi.Visible = true; return; }
            if (txtSoDienThoai.Text == "") { lbWarningSDT.Visible = true; return; }
            if (txtChucVu.Text == "") { lbWarningChucVu.Visible = true; return; }
            if (txtNgayBatDau.Text == "") { lbWarningNgayBD.Visible = true; return; }
            if (txtLuongCoBan.Text == "") { lbWarningLuong.Visible = true; return; }
           */

            // Thu thập dữ liệu từ các trường nhập liệu
            string hoTen = txtHoTen.Text;
            string ngaySinh = txtNgaySinh.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string chucVu = txtChucVu.Text;
            string ngayBatDau = txtNgayBatDau.Text;
            string luongCBStr = txtLuongCoBan.Text;

            decimal luongCoBan;

            // Kiểm tra và chuyển đổi lương cơ bản
            if (!decimal.TryParse(luongCBStr, out luongCoBan) || luongCoBan < 0)
            {
                //lbWarningLuongCB.Visible = true;
                txtLuongCoBan.Clear();
                txtLuongCoBan.Focus();
                return;
            }

            // Kiểm tra định dạng ngày sinh và ngày bắt đầu
            DateTime ngaySinhDt;
            if (!DateTime.TryParse(ngaySinh, out ngaySinhDt))
            {
                //lbWarningNgaySinh1.Visible = true;
                txtNgaySinh.Clear();
                txtNgaySinh.Focus();
                return;
            }

            DateTime ngayBatDauDt;
            if (!DateTime.TryParse(ngayBatDau, out ngayBatDauDt))
            {
                //lbWarningNgayBD1.Visible = true;
                txtNgayBatDau.Clear();
                txtNgayBatDau.Focus();
                return;
            }

            // Xóa các label cảnh báo sau khi kiểm tra thành công
            /*foreach (Control ct in panelNV.Controls)
            {
                if (ct is Label lb)
                {
                    if (lb.Name.Contains("lbWarning"))
                    {
                        lb.Visible = false;
                    }
                }
            }*/

            // Tạo đối tượng NhanVienDTO và thêm mới
            NhanVienDTO nhanVienMoi = new NhanVienDTO(
                hoTen,
                ngaySinhDt,
                diaChi,
                soDienThoai,
                chucVu,
                ngayBatDauDt,
                luongCoBan
            );

            // Gọi phương thức thêm nhân viên từ lớp BLL
            bool themNhanVien = _nhanVienBLL.ThemNhanVien(nhanVienMoi);
            if (themNhanVien)
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }

            // Xóa sạch các trường nhập liệu để chuẩn bị cho lần nhập tiếp theo
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtChucVu.Clear();
            txtNgayBatDau.Clear();
            txtLuongCoBan.Clear();

            // Cập nhật lại danh sách nhân viên
            HienThiDSNhanVien();


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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel7, 15, BorderColor, BorderThickness, e);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel8, 15, BorderColor, BorderThickness, e);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanel(panel9, 15, BorderColor, BorderThickness, e);
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
        private void HienThiDSNhanVien()
        {
            listNhanVien = _nhanVienBLL.LayDSNhanVien();

        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            HienThiDSNhanVien();
        }
    }
}
