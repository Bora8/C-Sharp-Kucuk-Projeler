using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OrtaCagIrkları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Player1 Boyunuzu Giriniz.");
            int boyu = int.Parse(Console.ReadLine());
            Console.WriteLine("Player1 Kilonuzu Giriniz.");
            int kilosu = int.Parse(Console.ReadLine());
            Console.WriteLine("Player1 Silah Tercihinizi Giriniz.");
            string silahtercihi = Console.ReadLine();
            ırk kisi = new ırk(boyu, kilosu, silahtercihi);
            string player1 = kisi.kararverici();
            if(player1 == "MELEZ")
            {
                Console.WriteLine("2 ırklı bir melezsiniz.");
            }
            else if(player1 == "ÖZEL")
            {
                Console.WriteLine("Özel bir yeteneğiniz var. Hiçbir ırka uygun değilsiniz.");
            }
            else
            {
                Console.WriteLine(player1.ToLowerInvariant() + " ırkındansınız.");
            }
            

            Console.WriteLine("Player2 Boyunuzu Giriniz.");
            int boyu2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Player2 Kilonuzu Giriniz.");
            int kilosu2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Player2 Silah Tercihinizi Giriniz.");
            string silahtercihi2 = Console.ReadLine();
            ırk kisi2 = new ırk(boyu2, kilosu2, silahtercihi2);
            string player2 = kisi2.kararverici();
            if (player2 == "MELEZ")
            {
                Console.WriteLine("2 ırklı bir melezsiniz.");
            }
            else if (player2 == "ÖZEL")
            {
                Console.WriteLine("Özel bir yeteneğiniz var. Hiçbir ırka uygun değilsiniz.");
            }
            else
            {
                Console.WriteLine(player2.ToLowerInvariant() + " ırkındansınız.");
            }
            int player1can = kisi.Can();
            int player2can = kisi2.Can();
            Console.WriteLine(player1can + "-" + player2can);
            int saldırı1 = 0;
            int saldırı2 = 0;
            for(int i = 0; i < 10; i++)
            {
                if(player1can >= 0 && player2can >= 0)
                {
                    
                    Console.WriteLine(player1can + "-" + player2can+"\n"+(i+1) + ".nci tur saldırıları yapılıyor.");
                    Console.ReadKey();
                    saldırı1 = kisi.Guc();
                    saldırı2 = kisi2.Guc();
                    player1can = player1can-saldırı2;
                    player2can = player2can-saldırı1;
                    if(saldırı1>100 && saldırı2 > 100)
                    {
                        Console.WriteLine("Player1 hasarı:" + saldırı1 + "(SÜPER VURUŞ)" + " - " + "Player2 hasarı:" + saldırı2 + "(SÜPER VURUŞ)");
                    }
                    else if(saldırı1 > 100)
                    {
                        Console.WriteLine("Player1 hasarı:" + saldırı1 + "(SÜPER VURUŞ)" + " - " + "Player2 hasarı:" + saldırı2);
                    }
                    else if (saldırı2 > 100)
                    {
                        Console.WriteLine("Player1 hasarı:" + saldırı1 + " - " + "Player2 hasarı:" + saldırı2 + "(SÜPER VURUŞ)");
                    }
                    else
                    {
                        Console.WriteLine("Player1 hasarı:" + saldırı1 + " - " + "Player2 hasarı:" + saldırı2);
                    }
                    Console.WriteLine();
                }
                else
                {
                    if(player1can <= 0 && player2can <= 0)
                    {
                        Console.WriteLine("Berabere.");
                    }
                    else
                    {
                        if (player1can > player2can)
                        {
                            player2can = 0;
                            Console.WriteLine(player1can + "-" + player2can);
                            Console.WriteLine("Player1 WIN");
                        }
                        else if (player2can > player1can)
                        {
                            player1can = 0;
                            Console.WriteLine("Player2 WIN");
                        }
                    }
                    Console.Read();
                    break;
                }
            }



            Console.Read();
        }
        


    }
    class ırk 
    {
        private int boy;
        public int BOY
        {
            get { return boy; } set {  boy = value; }
        }

        private int kilo;
        public int KİLO
        {
            get { return kilo; }
            set { kilo = value; }
        }

        private string tercih;
        public string TERCİH
        {
            get { return tercih; }
            set { tercih = value.ToUpper(); }
        }
        public ırk(int boy, int kilo, string tercih)
        {
            BOY = boy;
            KİLO = kilo;
            TERCİH = tercih;
            
        }
        
        public string kararverici()
        {
            string[] irkisimleri = { "Dworf", "Elf", "İnsan", "Büyücü", "Ork" };
            int[,] boykilo = { { 100, 160, 85, 140 }, { 175, 225, 50, 85 }, { 150, 220, 45, 120 }, { 175, 200, 40, 85 }, { 180, 240, 85, 150 } };
            string karakter = "";
            int a = 0;
            for (int i = 0; i < irkisimleri.Length; i++)
            {
                
                if(boy >= boykilo[i, 0] && boy <= boykilo[i, 1] && kilo >= boykilo[i, 2] && kilo <= boykilo[i, 3]) 
                {
                    if(i == 0)
                    {
                        if (tercih == "KILIÇ" || tercih == "BALTA")
                        { 
                            a++;                            
                            karakter = "DWORF";
                        }
                         
                        
                    }
                    else if(i == 1)
                    {
                        if (tercih == "OK" || tercih == "ASA" || tercih == "MIZRAK")
                        {
                            a++;                           
                            karakter = "ELF";
                        }
                         
                    }
                    else if(i == 2)
                    {
                        if (tercih == "OK" || tercih == "KILIÇ" || tercih == "PALA")
                        {
                            a++;                            
                            karakter = "İNSAN";
                        }
                         
                    }
                    else if(i == 3)
                    {
                        if (tercih == "KILIÇ" || tercih == "ASA") 
                        {
                            a++;                            
                            karakter = "BÜYÜCÜ";
                        }
                         
                    }
                    else if(i == 4)
                    {
                        if (tercih == "BALTA" || tercih == "MIZRAK")
                        {
                            a++;           
                            karakter = "ORK";
                        }
                         
                    }
                    
                }
                
            }
            if (a > 1)
            {
                karakter = "MELEZ";
            }
            if (a == 0)
            {
                karakter = "ÖZEL";
            }
            
            return karakter;
            
        }
        Random random = new Random();
        public int Guc()
        {
            
            int i = 0;
            int saldiri = 0;
            if (tercih == "KILIÇ")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 140;
                }
                else
                {
                    saldiri = random.Next(30, 45);
                }
                
            }
            else if(tercih == "BALTA")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 135;
                }
                else
                {
                    saldiri = random.Next(25, 40);
                }
            }
            else if (tercih == "OK")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 135;
                }
                else
                {
                    saldiri = random.Next(25, 40);
                }
            }
            else if (tercih == "ASA")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 145;
                }
                else
                {
                    saldiri = random.Next(35, 50);
                }
            }
            else if (tercih == "MIZRAK")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 140;
                }
                else
                {
                    saldiri = random.Next(30, 45);
                }
            }
            else if (tercih == "PALA")
            {
                i = random.Next(1, 12);
                if (i == 5)
                {
                    saldiri = 230;
                }
                else
                {
                    saldiri = random.Next(10, 25);
                }
            }
            return saldiri;
        }
        public int Can()
        {
            int can = 0;
            switch (kararverici()) 
            {
                case "DWORF":
                    can = 440;
                    break;
                case "ELF":
                    can = 320;
                    break;
                case "İNSAN":
                    can = 335;
                    break;
                case "BÜYÜCÜ":
                    can = 335;
                    break;
                case "ORK":
                    can = 450;
                    break;
                case "MELEZ":
                    can = 350;
                    break;
                case "ÖZEL":
                    can = 375;
                    break;
                default:
                    break;
            }
            return can;
        }
        

    }           
}
