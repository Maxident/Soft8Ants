using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ants
{
    class WorldWriter
    {
        String[] world;
        Logic myLogic;
        public WorldWriter(Logic MyLogic)
        {
            world = new String[152];
            myLogic = MyLogic;
        }
        public void setLines()
        {
            world[0] = "150";
            world[1] = "150";
            for (int i = 2; i < 152; i++)
            {
                world[i] = getLine(i - 2);
            }
        }
        public String getLine(int y)
        {
            String line = "";
            if (y % 2 == 1)
            {
                line += " ";
            }
            for (int i = 0; i < 150; i++)
            {
                line += getTileType(i, y) + " ";
            }
            return line;
        }
        public String getTileType(int x, int y)
        {
            Tile newTile = myLogic.getTile(x, y);
            String returnString = "";
            if (newTile.getRocky())
            {
                returnString = "#";
            }
            else if (newTile.getFood())
            {
                try
                {
                    returnString = newTile.getNumFood().ToString();
                }
                catch (Exception e)
                {
                    returnString = ".";
                }
            }
            else if (newTile.getAntHill())
            {
                if (newTile.getColour().ToLower().Equals("red"))
                {
                    returnString = "+";
                }
                else if (newTile.getColour().ToLower().Equals("black"))
                {
                    returnString = "-";
                }
                else
                {
                    returnString = ".";
                }
            }
            else
            {
                returnString = ".";
            }
            return returnString;
        }
        public void write(String filePath)
        {
            System.IO.File.WriteAllLines(filePath, world);
        }
    }
}
