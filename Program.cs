namespace BasicMarketCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Market Kasa Simülasyonu v1.0";
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("------------- MARKET SİSTEMİNE HOŞ GELDİNİZ ------------");
            Console.WriteLine("--------------------------------------------------------");
            Console.ResetColor();

            int urunAdedi = 0;

            //veri girişleri
            while (true)
            {
                try
                {
                    Console.Write("\nKaç adet ürün gireceksiniz? ");
                    urunAdedi = int.Parse(Console.ReadLine());
                    if (urunAdedi <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hata: Lütfen en az 1 adet ürün giriniz.");
                        Console.ResetColor();
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hata: Lütfen sadece tam sayı (rakam) giriniz!");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hata: Çok büyük bir sayı girdiniz!");
                    Console.ResetColor();
                }
            }

            double[] urunFiyatlari = new double[urunAdedi];
            double toplamFiyat = 0;

            for (int i = 0; i < urunAdedi; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{i + 1}. ürünün fiyatını giriniz: ");
                Console.ResetColor();

                try
                {
                    double girilenFiyat = double.Parse(Console.ReadLine());

                    if (girilenFiyat < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hata: Fiyat negatif olamaz. Lütfen tekrar deneyin !");
                        Console.ResetColor();
                        i--;
                        continue;
                    }

                    urunFiyatlari[i] = girilenFiyat;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hata: Lütfen Sayı Giriniz !!!");
                    Console.ResetColor();
                    i--;
                }
            }

            //alışveriş özeti ve hesaplamalar

            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("----------- ALIŞVERİŞ ÖZETİ -----------");
            Console.ResetColor();

            for (int i = 0; i < urunFiyatlari.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Ürün Fiyatı: {urunFiyatlari[i]} TL");
                toplamFiyat += urunFiyatlari[i];
            }

            const double kdvOrani = 0.20;
            double kdvTutari = toplamFiyat * kdvOrani;
            double kdvliToplam = toplamFiyat + kdvTutari;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();

            Console.WriteLine("Toplam Ürün Sayısı: " + urunAdedi);
            Console.WriteLine($"Ara Toplam         : {toplamFiyat:f2} TL");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"KDV (%20)          : {kdvTutari:F2} TL");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"GENEL TOPLAM       : {kdvliToplam:F2} TL");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();

            //en pahali en ucuz ürünler
            double enPahali = urunFiyatlari[0];
            double enUcuz = urunFiyatlari[0];

            for (int i = 1; i < urunFiyatlari.Length; i++)
            {
                if (urunFiyatlari[i] > enPahali) enPahali = urunFiyatlari[i];
                if (urunFiyatlari[i] < enUcuz) enUcuz = urunFiyatlari[i];
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("En Pahalı Ürün     : " + enPahali + " TL");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("En Ucuz Ürün       : " + enUcuz + " TL");
            Console.ResetColor();

            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
