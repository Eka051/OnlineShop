using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class Produk
    {
        public string NamaProduk;
        public double hargaProduk;
        public double hargaTotal;
        public Produk(string NamaProduk, double hargaProduk)
        {
            this.NamaProduk = NamaProduk;
            this.hargaProduk = hargaProduk;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Nama Produk : {NamaProduk}"
                + $"\nHarga Produk: {hargaProduk}");
        }

        public virtual double HargaTotal()
        {
            return hargaTotal;
        }
    }

    public class BarangElektronik : Produk
    {
        public double berat;


        public BarangElektronik(string NamaProduk, double hargaProduk, double berat) : base(NamaProduk, hargaProduk)
        {
            this.berat = berat;
        }
        public override double HargaTotal()
        {
            double ongkir = 0;
            double total = 0;
            if (berat <= 10)
            {
                ongkir = 150000;
                total = hargaProduk + ongkir;
            }
            else if (berat <= 20)
            {
                ongkir = 250000;
                total = hargaProduk + ongkir;
            }
            else if (berat > 20)
            {
                ongkir = 400000;
                total = hargaProduk + ongkir;
            }
            
            return total;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Berat barang elektronik: {berat}kg"
                + $"\nOngkir barang elektronik: {(berat <= 10 ? 15000 : (berat <= 20 ? 20000 : 30000))}"
                + $"\nTotal Harga Elektronik : {HargaTotal()}\n");
        }
    }

    public class BajuDanPakaian : Produk
    {
        public int jumlah;
        public BajuDanPakaian(string NamaProduk, double hargaProduk, int jumlah) : base(NamaProduk, hargaProduk)
        {
            this.jumlah = jumlah;
        }
        public override double HargaTotal()
        {
            return (hargaProduk * jumlah) + 25000;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Ongkir Baju dan Pakaian      : Rp.25000");
            Console.WriteLine($"Jumlah Baju dan Pakaian      : {jumlah}");
            Console.WriteLine($"Total Harga Baju dan Pakaian : {HargaTotal()}\n");
        }

    }

    public class Buku : Produk
    {
        public int jumlah;
        public Buku(string NamaProduk, double hargaProduk, int jumlah) : base(NamaProduk, hargaProduk)
        {
            this.jumlah = jumlah;
        }
        public override double HargaTotal()
        {
            return (hargaProduk * jumlah) + 15000;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Ongkir Buku : 15000");
            Console.WriteLine($"Jumlah buku : {jumlah}");
            Console.WriteLine($"Total Harga Buku : {HargaTotal()}\n");
        }
    }

    public class KeranjangBelanja
    {
        private List<Produk> daftarProduk;

        public KeranjangBelanja()
        {
            daftarProduk = new List<Produk>();
        }

        public void TambahProduk(Produk produk)
        {
            daftarProduk.Add(produk);
        }

        public double HitungTotalHarga()
        {
            double totalHarga = 0;
            foreach (var produk in daftarProduk)
            {
                totalHarga += produk.HargaTotal();
            }
            return totalHarga;
        }

        public void TampilkanDaftarProduk()
        {
            Console.WriteLine("Daftar Produk dalam Keranjang Belanja:");
            foreach (var produk in daftarProduk)
            {
                produk.GetInfo();
            }
            Console.WriteLine($"Total harga keseluruhan : {HitungTotalHarga()}");
        }
    }

}