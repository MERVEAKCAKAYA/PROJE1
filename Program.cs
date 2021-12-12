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
                
            while(true)
            {
                islemler.KonsolEkran();
                try
                {
                    int islem = Convert.ToInt16(Console.ReadLine());
                    if (islem < 1 || islem > 6)
                    {
                        Console.WriteLine("\nLütfen 1-6 arası işlem seçiniz!");
                        continue;
                    }
                    else if (islem == 6)
                    {
                        Console.WriteLine("İşlem Sonlandırıldı.");
                        break;
                    }

                Console.Clear();
                
            


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
                    case 2:
                    {
                        
                        Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string girisSilinen=Console.ReadLine();
                        if(islemler.SilinecekKontrol(girisSilinen)==true)
                        {
                            Console.WriteLine("Silme işlemi tamamlanmıştır.");
                        }
                        else
                        {
                            Console.WriteLine("Silme işlemi başarısız olmuştur.");
                        }
                        break;
                    }
                    case 3:
                    {
                        int index=-1;
                        Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                        string girisGuncellenen=Console.ReadLine();
                        if(islemler.GuncellenecekKontrol(girisGuncellenen,out index))
                        {
                            Console.WriteLine("Lütfen yeni numarayı giriniz.");
                            string yeniTel=Console.ReadLine();
                        
                        }
                        else
                        {
                            Console.WriteLine("Güncelleme işlemi başarısız olmuştur.");
                        }
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("3.işlemi seçtiniz");
                        islemler.rehberListele();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("5.işlemi seçtiniz");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("default");
                        break;
                    }
                }

                Console.WriteLine("\nYeni işlem için bir tuşa basınız");
                Console.ReadKey();
                Console.Clear();
                }catch (FormatException)
                {
                    Console.WriteLine("Hatalı giriş yapıldı!\n");
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
        public void rehberListele()
        {
            kisiler.Sort((u1, u2) => u1.isim.CompareTo(u2.isim));//isime göre sırala

            for (int i = 0; i < kisiler.Count; i++)
            {
                kisiGoruntule(kisiler[i]);
            }
        }
        public void KonsolEkran()
        {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
                Console.WriteLine("********************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(6) İşlemi Sonlandırmak");
        }
        public bool SilinecekKontrol(string gelenSilinecek)
        {
            for (int i = 0; i < kisiler.Count; i++)
            {
                if(gelenSilinecek==kisiler[i].isim || gelenSilinecek==kisiler[i].soyisim)
                {
                    KayitSil(i);
                    return true;
                }
            }
            return false;
        }
        void KayitSil(int kayitSilinecek)
        {
            kisiler.RemoveAt(kayitSilinecek);
        }
        public bool GuncellenecekKontrol(string gelenGuncellenecek,out int index)
        {
            for (int i = 0; i < kisiler.Count; i++)
            {
                if(gelenGuncellenecek==kisiler[i].isim || gelenGuncellenecek==kisiler[i].soyisim)
                {
                    index=i;
                    return true;
                }
            }
            index=-1;
            return false;
        }
       
       

    }
}
