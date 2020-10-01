using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolisSimulering
{
    abstract class Bot
    {
        public int PosX;
        public int PosY;
        public int lastPosX;
        public int lastPosY;
        public int Type;

        // Tilldelar en random x-koordinat till objekt (0-100).
        public void CoordX()
        {
            Random rng1 = new Random();
            int xRan = rng1.Next(0, 100);

            PosX = xRan;
        }

        // Tilldelar en random y-koordinat till objekt (0-25).
        public void CoordY()
        {
            Random rng2 = new Random();
            int yRan = rng2.Next(0, 25);

            PosY = yRan;
        }

        public List<string> inventoryList = new List<string>();

        abstract public void Body();
        abstract public void BotType();
    }

    class Citizen : Bot
    {

        public void AddItems()
        {
            inventoryList.Add("Nycklar");
            inventoryList.Add("Mobiltelefon");
            inventoryList.Add("Pengar");
            inventoryList.Add("Klocka");
        }
        public override void BotType()
        {
            Type = 1;
        }
        public override void Body()
        {
            Console.Write("M");
        }
    }

    class Thief : Bot
    {
        public override void BotType()
        {
            Type = 2;
        }

        public override void Body()
        {
            Console.Write("T");
        }
    }

    class Police : Bot
    {
        public override void BotType()
        {
            Type = 3;
        }

        public override void Body()
        {
            Console.Write("P");
        }
    }

    class Position : Bot
    {
        public int X;
        public int Y;
        public int PosType;

        public override void Body()
        {
            throw new NotImplementedException();
        }

        public override void BotType()
        {
            throw new NotImplementedException();
        }
    }   
}
