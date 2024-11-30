using System;
using System.Collections.Generic;
using System.Linq;

namespace KTOOP
{
    class TaiKhoan
    {
        public int SoTaiKhoan { get; set; }
        public double SoDu { get; set; }

        public TaiKhoan(int soTaiKhoan, double soDu)
        {
            SoTaiKhoan = soTaiKhoan;
            SoDu = soDu;
        }

        public override string ToString()
        {
            return $"So Tai Khoan: {SoTaiKhoan}, So du: {SoDu}";
        }
    }

    class SavingAccount : TaiKhoan
    {
        public double LaiSuat { get; set; }

        public SavingAccount(int soTaiKhoan, double soDu, double laiSuat)
            : base(soTaiKhoan, soDu)
        {
            LaiSuat = laiSuat;
        }

        public override string ToString()
        {
            return $"So tai khoan: {SoTaiKhoan}, So du: {SoDu}, Lai suat: {LaiSuat * 100}%";
        }
    }

    class CheckingAccount : TaiKhoan
    {
        public SavingAccount TaiKhoanLienKet { get; set; }

        public CheckingAccount(int soTaiKhoan, double soDu, SavingAccount taiKhoanLienKet = null)
            : base(soTaiKhoan, soDu)
        {
            TaiKhoanLienKet = taiKhoanLienKet;
        }

        public override string ToString()
        {
            return $"So tai khoan: {SoTaiKhoan}, So du: {SoDu}, Lien ket: {(TaiKhoanLienKet != null ? "Co" : "Khong")}";
        }

        public bool RutTien(double soTien)
        {
            if (soTien <= SoDu)
            {
                SoDu -= soTien;
                return true;
            }
            else if (TaiKhoanLienKet != null && soTien <= SoDu + TaiKhoanLienKet.SoDu)
            {
                double thieuHut = soTien - SoDu;
                SoDu = 0;
                TaiKhoanLienKet.SoDu -= thieuHut;
                return true;
            }
            return false;
        }
    }

    class KhachHang
    {
        public string TenKhachHang { get; set; }
        public List<TaiKhoan> TaiKhoanHienCo { get; set; }

        public KhachHang(string tenKhachHang)
        {
            TenKhachHang = tenKhachHang;
            TaiKhoanHienCo = new List<TaiKhoan>();
        }

        public void ThemTaiKhoan(TaiKhoan tk)
        {
            if (TaiKhoanHienCo.Count < 4)
                TaiKhoanHienCo.Add(tk);
            else
                Console.WriteLine("Moi khach hang chi so huu 4 tai khoan");
        }

        public TaiKhoan LayTaiKhoan(int soTaiKhoan)
        {
            return TaiKhoanHienCo.FirstOrDefault(tk => tk.SoTaiKhoan == soTaiKhoan);
        }
        public void InThongTinTaiKhoan()
        {
            Console.WriteLine($"Khach hang: {TenKhachHang}");
            foreach (var tk in TaiKhoanHienCo)
            {
                Console.WriteLine(tk);
            }
            Console.WriteLine($"Tong so tk: {TaiKhoanHienCo.Count}");
        }
    }

    class NganHang
    {
        public List<KhachHang> DanhSachKhachHang { get; set; }

        public NganHang()
        {
            DanhSachKhachHang = new List<KhachHang>();
        }

        public void ThemKhachHang(KhachHang kh)
        {
            DanhSachKhachHang.Add(kh);
        }

        public KhachHang TimKiemKhachHangTheoTen(string ten)
        {
            return DanhSachKhachHang.FirstOrDefault(kh => kh.TenKhachHang == ten);
        }

        public KhachHang TimKiemKhachHangTheoSTK(int soTaiKhoan)
        {
            return DanhSachKhachHang.FirstOrDefault(kh => kh.TaiKhoanHienCo.Any(tk => tk.SoTaiKhoan == soTaiKhoan));
        }

        public void GuiTien(int soTaiKhoan, double soTien)
        {
            var kh = TimKiemKhachHangTheoSTK(soTaiKhoan);
            if (kh != null)
            {
                var tk = kh.LayTaiKhoan(soTaiKhoan);
                if (tk != null)
                {
                    tk.SoDu += soTien;
                    Console.WriteLine($"Da gui {soTien} vao tai khoan {soTaiKhoan}. So du hien tai: {tk.SoDu}");
                }
            }
            else
            {
                Console.WriteLine("Khong thay tai khoan.");
            }
        }

        public void RutTien(int soTaiKhoan, double soTien)
        {
            var kh = TimKiemKhachHangTheoSTK(soTaiKhoan);
            if (kh != null)
            {
                var tk = kh.LayTaiKhoan(soTaiKhoan);
                if (tk is CheckingAccount ca)
                {
                    if (ca.RutTien(soTien))
                        Console.WriteLine($"So du : {soTaiKhoan}: {ca.SoDu}");
                    else
                        Console.WriteLine("Khong the rut tien");
                }
                else if (tk != null && soTien <= tk.SoDu)
                {
                    tk.SoDu -= soTien;
                    Console.WriteLine($"So du : {soTaiKhoan}: {tk.SoDu}");
                }
                else
                {
                    Console.WriteLine("Khong the rut.");
                }
            }
            else
            {
                Console.WriteLine("Khong thay tai khoan.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var nganHang = new NganHang();

            var kh1 = new KhachHang("Nguyen Van A");
            var saving = new SavingAccount(101, 10000, 0.03);
            var checking = new CheckingAccount(102, 2000, saving);

            kh1.ThemTaiKhoan(saving);
            kh1.ThemTaiKhoan(checking);

            nganHang.ThemKhachHang(kh1);

            // Kiểm tra thông tin
            kh1.InThongTinTaiKhoan();

            // Gửi tiền
            nganHang.GuiTien(101, 5000);

            // Rút tiền (vượt quá số dư trong tài khoản vãng lai)
            nganHang.RutTien(102, 15000);

            // Kiểm tra lại thông tin
            kh1.InThongTinTaiKhoan();
        }
    }
}