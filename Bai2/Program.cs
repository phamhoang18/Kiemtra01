using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AutoSpeed
{
    public abstract class PhuongTien
    {
        private string _maPT = "PT000";
        private string _tenHang = string.Empty;
        private int _namSanXuat;
        private decimal _giaGoc;

        public string MaPT
        {
            get => _maPT;
            set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value.Trim();
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");
                _tenHang = value.Trim();
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");
                _namSanXuat = value;
            }
        }

        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                _giaGoc = value;
            }
        }

        protected PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        public abstract decimal TinhGiaLanBanh();

        public virtual string GetInfo()
        {
            return $"Mã: {MaPT} | Hãng: {TenHang} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }

    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                _dungTichDongCo = value;
            }
        }

        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc,
                   int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                decimal truocBa = GiaGoc * 0.12m;   
                decimal ttdb = GiaGoc * 0.30m;   
                return GiaGoc + truocBa + ttdb;
            }
            return GiaGoc + GiaGoc * 0.10m;        
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Số chỗ: {SoChoNgoi} | Dung tích động cơ: {DungTichDongCo} L";
        }
    }

    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xylanh phải lớn hơn 0!");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            decimal tyLeTruocBa = DungTichXylanh < 175 ? 0.02m : 0.05m;
            return GiaGoc + GiaGoc * tyLeTruocBa;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Dung tích xylanh: {DungTichXylanh} cc";
        }
    }

    public class QuanLyPhuongTien
    {
        private readonly List<PhuongTien> _ds = new List<PhuongTien>();

        public IReadOnlyList<PhuongTien> DanhSach => _ds;

        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt == null) throw new ArgumentNullException(nameof(pt));
            _ds.Add(pt);
        }

        public void DisplayAll()
        {
            if (_ds.Count == 0)
            {
                Console.WriteLine("(Danh sách trống)");
                return;
            }
            foreach (PhuongTien pt in _ds)
            {
                Console.WriteLine(pt.GetInfo());
                Console.WriteLine($"   => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        public PhuongTien FindMaxGiaLanBanh()
        {
            if (_ds.Count == 0) return null;
            return _ds.OrderByDescending(p => p.TinhGiaLanBanh()).First();
        }

        public List<PhuongTien> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<PhuongTien>(_ds);
            return _ds.Where(p => p.TenHang.IndexOf(keyword.Trim(), StringComparison.OrdinalIgnoreCase) >= 0)
                      .ToList();
        }
    }

    internal static class Program
    {
        private static readonly QuanLyPhuongTien ql = new QuanLyPhuongTien();

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("========== QUẢN LÝ PHƯƠNG TIỆN - AUTOSPEED ==========");
                Console.WriteLine("1. Thêm Ô tô");
                Console.WriteLine("2. Thêm Xe máy");
                Console.WriteLine("3. Hiển thị tất cả phương tiện (kèm giá lăn bánh)");
                Console.WriteLine("4. Tìm phương tiện có giá lăn bánh cao nhất");
                Console.WriteLine("5. Tìm theo tên hãng");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                choice = choice == null ? "" : choice.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ThemOTo(); break;
                    case "2": ThemXeMay(); break;
                    case "3": ql.DisplayAll(); break;
                    case "4": TimMax(); break;
                    case "5": TimTheoTen(); break;
                    case "0": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
                Console.WriteLine();
            }
        }

        // ---------- Các chức năng ----------
        private static void ThemOTo()
        {
            Console.WriteLine("--- Nhập thông tin Ô tô ---");
            string ma = ReadString("Mã PT (để trống = PT000): ");
            string hang = ReadString("Tên hãng: ");
            int nam = ReadInt("Năm sản xuất: ");
            decimal gia = ReadDecimal("Giá gốc (VNĐ): ");
            int soCho = ReadInt("Số chỗ ngồi: ");
            double dungTich = ReadDouble("Dung tích động cơ (L): ");

            try
            {
                var oto = new OTo(ma, hang, nam, gia, soCho, dungTich);
                ql.AddPhuongTien(oto);
                Console.WriteLine("=> Đã thêm Ô tô. Giá lăn bánh: " + oto.TinhGiaLanBanh().ToString("N0") + " VNĐ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("=> LỖI: " + ex.Message);
                Console.WriteLine("=> Không cho tạo đối tượng.");
            }
        }

        private static void ThemXeMay()
        {
            Console.WriteLine("--- Nhập thông tin Xe máy ---");
            string ma = ReadString("Mã PT (để trống = PT000): ");
            string hang = ReadString("Tên hãng: ");
            int nam = ReadInt("Năm sản xuất: ");
            decimal gia = ReadDecimal("Giá gốc (VNĐ): ");
            int cc = ReadInt("Dung tích xylanh (cc): ");

            try
            {
                var xm = new XeMay(ma, hang, nam, gia, cc);
                ql.AddPhuongTien(xm);
                Console.WriteLine("=> Đã thêm Xe máy. Giá lăn bánh: " + xm.TinhGiaLanBanh().ToString("N0") + " VNĐ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("=> LỖI: " + ex.Message);
                Console.WriteLine("=> Không cho tạo đối tượng.");
            }
        }

        private static void TimMax()
        {
            PhuongTien max = ql.FindMaxGiaLanBanh();
            if (max == null)
            {
                Console.WriteLine("Danh sách trống, chưa có phương tiện nào.");
                return;
            }
            Console.WriteLine("Phương tiện có giá lăn bánh cao nhất:");
            Console.WriteLine(max.GetInfo());
            Console.WriteLine("   => Giá lăn bánh: " + max.TinhGiaLanBanh().ToString("N0") + " VNĐ");
        }

        private static void TimTheoTen()
        {
            string keyword = ReadString("Nhập tên hãng cần tìm: ");
            var kq = ql.SearchByName(keyword);
            if (kq.Count == 0)
            {
                Console.WriteLine("Không tìm thấy phương tiện nào.");
                return;
            }
            foreach (PhuongTien pt in kq)
            {
                Console.WriteLine(pt.GetInfo());
                Console.WriteLine("   => Giá lăn bánh: " + pt.TinhGiaLanBanh().ToString("N0") + " VNĐ");
            }
        }

        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            return s == null ? "" : s;
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int v;
                if (int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out v))
                    return v;
                Console.WriteLine("   Vui lòng nhập một số nguyên hợp lệ!");
            }
        }

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                decimal v;
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out v))
                    return v;
                Console.WriteLine("   Vui lòng nhập một số hợp lệ (ví dụ 1000000000)!");
            }
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                s = s == null ? "" : s.Replace(',', '.');
                double v;
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out v))
                    return v;
                Console.WriteLine("   Vui lòng nhập một số hợp lệ (ví dụ 2.5)!");
            }
        }
    }
}