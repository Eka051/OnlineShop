using OnlineShop;
using System;
class Program
{
    public static void Main(string[] args)
    {
        BarangElektronik elektronik = new BarangElektronik("Smart TV Xiaomi", 1500000, 25);
        BajuDanPakaian fashion = new BajuDanPakaian("Gamis", 325000, 4);
        Buku buku = new Buku("Tutorial C# - Microsoft", 250000, 2);

        KeranjangBelanja keranjang = new KeranjangBelanja();
        keranjang.TambahProduk(elektronik);
        keranjang.TambahProduk(fashion);
        keranjang.TambahProduk(buku);
        keranjang.TampilkanDaftarProduk();
        Console.ReadKey();
    }
}