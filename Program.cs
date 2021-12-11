using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            kisiler.Add(new Kisi("bambam","ak","2546"));
            kisiler.Add(new Kisi("badem","dgr","3421"));
            kisiler.Add(new Kisi("sakız","ytg","1111"));
            kisiler.Add(new Kisi("beyaz","sdde","4444"));
            kisiler.Add(new Kisi("merve","kouh","9999"));

            Islemler islemler = new Islemler(kisiler);
            
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
                Console.WriteLine("********************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
            
                int islem = Convert.ToInt16(Console.ReadLine());

                switch (islem)
                {
                    case 1:
                        {
                            Console.Write(" Lütfen isim giriniz:");
                            string ad = Console.ReadLine();
                            Console.Write(" Lütfen soyisim giriniz:");
                            string soyad = Console.ReadLine();
                            Console.Write(" Lütfen telefon no giriniz:");
                            string telNo = Console.ReadLine();
                            Kisi geciciKisi = new Kisi(ad,soyad,telNo);

                            kisiler.Add(geciciKisi);

                            Console.WriteLine("Kayıt işlemi gerçekleştirildi.");

                            break;
                        }
                    
                }
         
        }
    }

    struct Kisi
    {     
        public string isim;
        public string soyisim;
        public string telefon;

        public Kisi(string isim, string soyisim, string telefon)
        {
            this.isim = isim;
            this.soyisim = soyisim;
            this.telefon = telefon;
        }     
    }

    class Islemler
    {
        List<Kisi> kisiler = new List<Kisi>();

        public Islemler(List<Kisi> kisiler)
        {
            this.kisiler = kisiler;
        }

        void kisiGoruntule(Kisi kisi)
        {
            Console.WriteLine("İsim: " + kisi.isim);
            Console.WriteLine("Soyisim: " + kisi.soyisim);
            Console.WriteLine("Telefon numarası: " + kisi.telefon);
            Console.WriteLine();
        }


    }
}
