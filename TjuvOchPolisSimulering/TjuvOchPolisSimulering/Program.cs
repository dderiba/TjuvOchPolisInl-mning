using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;
namespace TjuvOchPolisSimulering
{
    class Program
    {
        public static List<Bot> city = new List<Bot>();   
        
        static void Main(string[] args)
        {
            Settings();          // Ställer in inställningar för consolefönstret.
            AddPopulation();     // Lägger till "befolkningen" till världen.
            DrawWorld();         // Ritar ut världen.
        }

        private static void Settings()
        {
            Console.CursorVisible = false;
            BufferWidth = 200;
            BufferHeight = 200;
            SetBufferSize(Console.BufferWidth, Console.BufferHeight);
        }

        private static void AddPopulation()
        {
            // Lägger till medborgare till staden.
            for (int i = 0; i < 15; i++)
            {
                Citizen citizen = new Citizen();

                citizen.CoordX();
                citizen.CoordY();
                citizen.BotType();
                citizen.AddItems();
                city.Add(citizen);
            }

            // Lägger till tjuvar till staden.
            for (int i = 0; i < 10; i++)
            {
                Thief thief = new Thief();

                thief.CoordX();
                thief.CoordY();
                thief.BotType();
                city.Add(thief);
            }

            // Lägger till poliser till staden.
            for (int i = 0; i < 7; i++)
            {
                Police police = new Police();

                police.CoordX();
                police.CoordY();
                police.BotType();
                city.Add(police);
            }
        }

        // Om en karaktär förflyttar sig utanför kartans gräns: Karaktären transporteras istället till andra änden av X- respektive Y-axeln.
        private static void TransportPosition()
        {
            foreach (Bot bot in city)
            {
                if (bot.PosX < 0)
                {
                    bot.PosX = 100;
                }
                if (bot.PosY < 0)
                {
                    bot.PosY = 25;
                }
                if (bot.PosX > 100)
                {
                    bot.PosX = 0;
                }
                if (bot.PosY > 25)
                {
                    bot.PosY = 0;
                }
            }
        }

        // Ger ett värde mellan 0-8 som matas in i DrawWorld() switchen, vilket i sin tur motsvarar en riktning (stop, ⇑, ⇗, ⇒, ⇘, ⇓, ⇙, ⇐, ⇖) som karaktären rör sig åt. 
        private static int Direction()
        {

            Random rngDir = new Random();
            int directionValue = rngDir.Next(0, 8);

            return directionValue;
        }
        
        // Ritar ut världen.
        private static void DrawWorld()
        {
            while (true)
            {               
                Clear();
                foreach (Bot bot in city)
                {
                    switch (Direction())
                    {
                        case 0:
                           break;

                        case 1:
                            bot.PosY--;
                            break;

                        case 2:
                            bot.PosX++;
                            bot.PosY--;
                            break;

                        case 3:
                            bot.PosX++;
                            break;

                        case 4:
                            bot.PosX++;
                            bot.PosY++;
                            break;

                        case 5:
                            bot.PosY++;
                            break;
                        case 6:
                            bot.PosX--;
                            bot.PosY++;                         
                            break;

                        case 7:
                            bot.PosX--;                            
                            break;

                        case 8:
                            bot.PosX--;
                            bot.PosY--;                         
                            break;

                        default:
                            break;
                    }
                    TransportPosition();
                    SetCursorPosition(bot.PosX, bot.PosY);
                    bot.Body();                                                        
                }               
                Thread.Sleep(500);
            }
        }           
    }
}
