using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaYönetimSistemi
{
    internal class Program
    {
        /*
        Gelişmiş bir araba yönetim sistemi tasarlayın. Bu sistem, çeşitli türdeki araçların yönetimini ve araç üzerindeki işlemlerin gerçekleştirilmesini sağlayacak şekilde detaylı bir yapıda olmalıdır. Sistem, Nesne Yönelimli Programlama (NYP) prensiplerini kullanarak C# ile geliştirilmelidir ve aşağıdaki özellikleri barındırmalıdır:

        Kapsülleme (Encapsulation): Araçların marka, model, üretim yılı, kilometre gibi bilgileri güvenli bir şekilde saklanmalı, bu bilgilere sadece tanımlı metotlar aracılığıyla erişilebilmelidir.
        Kalıtım (Inheritance): Araçlar Sedan, SUV, Hatchback, Sport gibi kategorilere ayrılmalı, her kategori genel bir Araba sınıfından türemeli ve kendi özel özelliklerine (örneğin, Sport için maksimum hız) sahip olmalıdır.
        Polimorfizm: Araçlar için genel davranışlar (Calistir, Durdur, BilgiGoster gibi) tanımlanmalı, bu davranışlar her araç türünde farklılık göstermelidir.
        Soyutlama (Abstraction): Araba sınıfı soyut bir sınıf olmalı, bazı metodlar soyut metotlar olarak tanımlanmalıdır. Bu, her türe özgü davranışların tanımlanmasını zorunlu kılar.
        Koleksiyonlar: Sistemdeki araçların listesi, uygun bir koleksiyon yapısı kullanılarak yönetilmeli. Bu liste üzerinde, araç ekleme, silme, listeleme ve araç özelliklerine göre sıralama gibi işlemler yapılabilmesi gerekmelidir.
        Ara Yüzler (Interfaces): Bazı özel işlevsellikler, ara yüzler kullanılarak tanımlanmalı ve ilgili sınıflar tarafından uygulanmalıdır (örneğin, IElektrikliArac ara yüzü elektrikli araçlar için şarj süresi ve menzil bilgisini içerebilir).
        Exception Handling: Sistem, olası hataları yönetebilmeli ve kullanıcı dostu hata mesajları verebilmelidir.
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Araba Yönetim Sistemine Hoşgeldiniz.\n1 = Sistemdeki Arabaları Görüntüle, 2 = Sisteme Yeni Araba Ekle");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                SUV suv1 = new SUV("BMV", "520i", 2016, 105524);
                Sport sport1 = new Sport("Ferrari", "Fe15", 2009, 207511);
                Sport sport2 = new Sport("Peugeot", "228", 2019, 179980);
                Sedan sedan1 = new Sedan("Mercedes", "228", 2006, 386020);
                suv1.BilgiGoster();
                sport1.BilgiGoster();
                sport2.BilgiGoster();
                sedan1.BilgiGoster();
            }
            else if (secim == 2)
            {
                Console.WriteLine("Araç Tipini Seçiniz\n1 = Sedan, 2 = SUV, 3 = Hatchback, 4 = Sport, 5 = Elektrikli Araba, 6 = Elektrikli Motor");
                int tip = int.Parse(Console.ReadLine());
                Console.WriteLine("Aracın Markası :");
                string aracmarka = Console.ReadLine();
                Console.WriteLine("Aracın Modeli :");
                string aracmmodel = Console.ReadLine();
                Console.WriteLine("Aracın Üretim Tarihi :");
                int aracuretimyili = int.Parse(Console.ReadLine());
                Console.WriteLine("Aracın Kilometresi :");
                int arackilometre = int.Parse(Console.ReadLine());
                if (tip == 1)
                {
                    Sedan sedan = new Sedan(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    sedan.BilgiGoster();
                }
                else if (tip == 2)
                {
                    SUV suv = new SUV(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    suv.BilgiGoster();
                }
                else if (tip == 3)
                {
                    Hatchback hatchback = new Hatchback(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    hatchback.BilgiGoster();
                }
                else if (tip == 4)
                {
                    Sport sport = new Sport(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    sport.BilgiGoster();
                }
                else if (tip == 5)
                {

                    Elektrikli elektrikli = new Elektrikli(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    elektrikli.SarjEt();
                    elektrikli.BilgiGoster();
                }
                else if (tip == 6)
                {
                    Motor motor = new Motor(aracmarka, aracmmodel, aracuretimyili, arackilometre);
                    motor.SarjEt();
                    motor.BilgiGoster();
                }
                else
                {
                    Console.WriteLine("Lütfen geçerli bir seçim yapınız.");
                }
                
            }
            Console.Read();
        }
        abstract class Araba
        {
            private string marka;
            public string MARKA
            {
                get { return marka; }
                set { marka = value.ToUpper(); }
            }
            private string model;
            public string MODEL
            {
                get { return model; }
                set { model = value.ToUpper(); }
            }
            private int üretimyili;
            public int ÜRETIMYILI
            {
                get { return üretimyili; }
                set {
                    if (value >= 1886)
                    {
                        üretimyili = value;
                    }
                    else
                    {
                        Console.WriteLine("Üretim yılı 1886 veya daha büyük olmalıdır.");
                        
                    }
                }
            }
            private int kilometre;
            public int KİLOMETRE
            {
                get { return kilometre; }
                set { kilometre = Math.Abs(value); }
            }
            public Araba(string marka, string model, int üretimyili, int kilometre)
            {
                MARKA = marka;
                MODEL = model;
                ÜRETIMYILI = üretimyili;
                KİLOMETRE = kilometre;
                
            }

            public abstract void Calistir();
            public abstract void Durdur();
            public abstract void BilgiGoster();
        }
        class Sedan : Araba
        {
            public Sedan(string marka, string model, int üretimyili, int kilometre) : base(marka,model,üretimyili,kilometre)
            {

            }
            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir araç.");
            }

            public override void Calistir()
            {
                Console.WriteLine("Sedan Araç Çalıştırıldı.");
            }

            public override void Durdur()
            {
                Console.WriteLine("Sedan Araç Durduruldu.");
            }
        }
        class SUV : Araba
        {
            public SUV(string marka, string model, int üretimyili, int kilometre) : base(marka, model, üretimyili, kilometre)
            {
            }

            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir araç.");
            }

            public override void Calistir()
            {
                Console.WriteLine("SUV Araç Çalıştırıldı.");
            }

            public override void Durdur()
            {
                Console.WriteLine("SUV Araç Durduruldu.");
            }
        }

        class Hatchback : Araba
        {
            public Hatchback(string marka, string model, int üretimyili, int kilometre) : base(marka, model, üretimyili, kilometre)
            {
            }

            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir araç.");
            }

            public override void Calistir()
            {
                Console.WriteLine("Hatchback Araç Çalıştırıldı.");
            }

            public override void Durdur()
            {
                Console.WriteLine("Hatchback Araç Durduruldu.");
            }
        }

        class Sport : Araba
        {
            public Sport(string marka, string model, int üretimyili, int kilometre) : base(marka, model, üretimyili, kilometre)
            {
            }

            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir araç.");
            }

            public override void Calistir()
            {
                Console.WriteLine("Sport Araç Çalıştırıldı.");
            }

            public override void Durdur()
            {
                Console.WriteLine("Sport Araç Durduruldu.");
            }
        }
        class Elektrikli : Araba
        {
            public Elektrikli(string marka, string model, int üretimyili, int kilometre) : base(marka, model, üretimyili, kilometre)
            {
                
            }
            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir araç.");
            }

            public override void Calistir()
            {
                Console.WriteLine("Elektrikli Araç Çalıştırılıyor");
            }

            public override void Durdur()
            {
                Console.WriteLine("Elektrikli Araç Durduruldu");
            }
            
            private int tsarj;
            public int TSARJ
            {
                get { return tsarj; }
                set { tsarj = Math.Abs(value); }
            }
            public void SarjEt()
            {
                Console.WriteLine("Aracınızın şarj süresi :");
                int t = int.Parse(Console.ReadLine());
                TSARJ = t;
                Console.WriteLine(MARKA + " " + MODEL + " aracınız " + TSARJ + " saat içerisinde dolacak");
            }

        }
        class Motor : Elektrikli
        {
            public Motor(string marka, string model, int üretimyili, int kilometre) : base(marka, model, üretimyili, kilometre)
            {

            }
            public override void BilgiGoster()
            {
                Console.WriteLine(MARKA + " " + MODEL + " modelinde " + ÜRETIMYILI + " yılında üretilmiş " + KİLOMETRE + " kilometrede bir motor.");
            }
            
            
        }
            
    }
    
}
