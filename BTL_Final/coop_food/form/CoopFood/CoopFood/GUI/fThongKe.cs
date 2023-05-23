using CoopFood.DAO;
using CoopFood.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();

            cbDieuKienLoc.Text = "Năm";
            _ = FillChart();
        }

        private async Task FillChart()
        {
            foreach (var series in chartDoanhthu.Series)
                series.Points.Clear();

            foreach (var series in chartLuongNhanVien.Series)
                series.Points.Clear();

            var duLieuDoanhThu = await HoaDonDAO.Instance.LayDuLieuBaoCaoDoanhThu();
            var duLieuLuong = await NhanVienDAO.Instance.LayDuLieuLuongNhanVien();

            switch (cbDieuKienLoc.SelectedText)
            {
                case "Năm":
                    FillChartByYear(duLieuDoanhThu, duLieuLuong);
                    break;
                case "Quý":
                    FillChartByQuater(duLieuDoanhThu, duLieuLuong);
                    break;
                default:
                    FillChartByYear(duLieuDoanhThu, duLieuLuong);
                    break;
            }
        }

        private void FillChartByYear(List<ThongKeDoanhThu> duLieuDoanhThu, List<ThongKeLuongNhanVien> duLieuLuong)
        {
            var groupDoanhThuMonth = duLieuDoanhThu.GroupBy(x => x.NgayMua.Month).ToList();
            var groupLuongMonth = duLieuLuong.GroupBy(x => x.NgayVaoLam.Month).ToList();

            for (int i = 0; i < 12; i++)
            {
                var doanhThuThang = groupDoanhThuMonth.Find(x => x.Key == i + 1);

                if (doanhThuThang != null)
                    chartDoanhthu.Series["VND"].Points.AddXY($"T{i + 1}", doanhThuThang.Sum(x => x.TongTien));
                else
                    chartDoanhthu.Series["VND"].Points.AddXY($"T{i + 1}", 0);


                var luongThang = groupLuongMonth.Find(x => x.Key == i + 1);

                if (luongThang != null)
                    chartLuongNhanVien.Series["VND"].Points.AddXY($"T{i + 1}", luongThang.Sum(x => x.MucLuong));
                else
                    chartLuongNhanVien.Series["VND"].Points.AddXY($"T{i + 1}", 0);
            }
        }

        private void FillChartByQuater(List<ThongKeDoanhThu> duLieuDoanhThu, List<ThongKeLuongNhanVien> duLieuLuong)
        {
            var groupDoanhThu = duLieuDoanhThu.GroupBy(item => ((item.NgayMua.Month - 1) / 3)).ToList(); ;

            var groupLuong = duLieuLuong.GroupBy(item => ((item.NgayVaoLam.Month - 1) / 3)).ToList();

            for (int i = 0; i < 4; i++)
            {
                var doanhThuQuy = groupDoanhThu.Find(x => x.Key == i);

                if (doanhThuQuy != null)
                    chartDoanhthu.Series["VND"].Points.AddXY($"Q{i + 1}", doanhThuQuy.Sum(x => x.TongTien));
                else
                    chartDoanhthu.Series["VND"].Points.AddXY($"Q{i + 1}", 0);


                var luongQuy = groupLuong.Find(x => x.Key == i);

                if (luongQuy != null)
                    chartLuongNhanVien.Series["VND"].Points.AddXY($"Q{i + 1}", luongQuy.Sum(x => x.MucLuong));
                else
                    chartLuongNhanVien.Series["VND"].Points.AddXY($"Q{i + 1}", 0);
            }
        }

        private async void cbDieuKienLoc_DropDownClosed(object sender, EventArgs e) => await FillChart();
    }
}
