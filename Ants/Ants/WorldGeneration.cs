using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Ants
{
    public class WorldGeneration : Microsoft.Xna.Framework.GameComponent
    {
        Logic myLogic;
        public WorldGeneration(Game game, Logic logic)
            : base(game)
        {
            myLogic = logic; //this is important, from the Logic class, we need the method LoadTile(whatevers in here), 
            // but this class will be inside that one so this is how we get at that method
        }
        //not in use atm
        public override void Initialize()
        {

            base.Initialize();
        }

        //not in use atm
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        //sets one single tile at tiles[x,y] to rocky. make sure that 0 <= x <= 150 AND 0 <= y <= 150
        public void setRocky(int x, int y)
        {
            myLogic.loadTile(x, y, myLogic.texTileRocky, myLogic.spriteBatch, true, false, false, 0, false, "");
        }

        //sets one single tile at tiles[x,y] to antHill and RB is a string that should be "red" or "black". make sure that 0 <= x <= 150 AND 0 <= y <= 150
        public void setAntHill(int x, int y, String RB)
        {
            if (RB.ToLower().Equals("red"))
            {
                myLogic.loadTile(x, y, myLogic.texAntHillRed, myLogic.spriteBatch, false, true, false, 0, false, "red");
            }
            else if (RB.ToLower().Equals("black"))
            {
                myLogic.loadTile(x, y, myLogic.texAntHillBlack, myLogic.spriteBatch, false, true, false, 0, false, "black");
            }
        }

        //sets one single tile at tiles[x,y] to blank. make sure that 0 <= x <= 150 AND 0 <= y <= 150
        public void setBlank(int x, int y)
        {
            myLogic.loadTile(x, y, myLogic.texTileBlank, myLogic.spriteBatch, false, false, false, 0, false, "");
        }

        //sets one single tile at tiles[x,y] to have food, the integer is how many food on that tile. make sure that 0 <= x <= 150 AND 0 <= y <= 150
        public void setFood(int x, int y, int food)
        {
            myLogic.loadTile(x, y, myLogic.texTileFood, myLogic.spriteBatch, false, false, true, food, false, "");
        }

        //makes an antHill where x and y are the top left corner of the hill, make sure to leave atleast 15 squares either way, so make sure that 0 <= x <= 135 AND 0 <= y <= 135
        public void makeAntHill(int x, int y, String RB)
        {
            if (y % 2 == 1)
            {

                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y, RB);
                }
                for (int i = 3; i < 11; i++)
                {
                    setAntHill(x + i, y + 1, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 2, RB);
                }
                for (int i = 2; i < 12; i++)
                {
                    setAntHill(x + i, y + 3, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 4, RB);
                }
                for (int i = 1; i < 13; i++)
                {
                    setAntHill(x + i, y + 5, RB);
                }
                for (int i = 0; i < 13; i++)
                {
                    setAntHill(x + i, y + 6, RB);
                }
                for (int i = 1; i < 13; i++)
                {
                    setAntHill(x + i, y + 7, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 8, RB);
                }
                for (int i = 2; i < 12; i++)
                {
                    setAntHill(x + i, y + 9, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 10, RB);
                }
                for (int i = 3; i < 11; i++)
                {
                    setAntHill(x + i, y + 11, RB);
                }
                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y + 12, RB);
                }
            }
            else
            {

                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 1, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 2, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 3, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 4, RB);
                }
                for (int i = 0; i < 12; i++)
                {
                    setAntHill(x + i, y + 5, RB);
                }
                for (int i = 0; i < 13; i++)
                {
                    setAntHill(x + i, y + 6, RB);
                }
                for (int i = 0; i < 12; i++)
                {
                    setAntHill(x + i, y + 7, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 8, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 9, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 10, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 11, RB);
                }
                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y + 12, RB);
                }
            }
            


        }

        //makes an rock formation where x and y are the top left corner, make sure to leave atleast 10 squares either way, so make sure that 0 <= x <= 140 AND 0 <= y <= 140
        //int select is a number 1-6 which are different formations. 1-4 are like preset formations, (which are slightly different depending on whether y is odd or even)
        //and 5 and 6 are random, 5 is more sparse, 6 is more solid
        public void makeRockFormation(int x, int y, int select)
        {
            if(select == 1)
            {
                setRocky(x + 2, y);
                setRocky(x + 3, y);
                setRocky(x + 4, y);
                setRocky(x + 9, y);
                setRocky(x + 10, y);
                setRocky(x + 11, y);
                setRocky(x + 12, y);
                setRocky(x + 13, y);
                setRocky(x + 14, y);
                setRocky(x + 10, y + 1);
                setRocky(x + 11, y + 1);
                setRocky(x + 12, y + 1);
                setRocky(x + 13, y + 1);
                setRocky(x, y + 1);
                setRocky(x + 1, y + 1);
                setRocky(x + 2, y + 1);
                setRocky(x + 3, y + 1);
                setRocky(x + 4, y + 1);
                setRocky(x + 5, y + 1);
                setRocky(x + 1, y + 2);
                setRocky(x + 2, y + 2);
                setRocky(x + 3, y + 2);
                setRocky(x + 4, y + 2);
                setRocky(x + 10, y + 2);
                setRocky(x + 11, y + 2);
                setRocky(x + 12, y + 2);
                setRocky(x + 1, y + 3);
                setRocky(x + 2, y + 3);
                setRocky(x + 3, y + 3);
                setRocky(x + 4, y + 3);
                setRocky(x + 5, y + 3);
                setRocky(x + 6, y + 3);
                setRocky(x, y + 4);
                setRocky(x + 1, y + 4);
                setRocky(x + 2, y + 4);
                setRocky(x + 3, y + 4);
                setRocky(x + 4, y + 4);
                setRocky(x + 5, y + 4);
                setRocky(x + 6, y + 4);
                setRocky(x + 3, y + 5);
                setRocky(x + 4, y + 5);
                setRocky(x + 5, y + 5);
                setRocky(x + 6, y + 5);
                setRocky(x + 7, y + 5);
                setRocky(x + 3, y + 6);
                setRocky(x + 4, y + 6);
                setRocky(x + 5, y + 6);
                setRocky(x + 6, y + 6);
                setRocky(x + 3, y + 7);
                setRocky(x + 4, y + 7);
                setRocky(x + 5, y + 7);
                setRocky(x + 3, y + 8);
                setRocky(x + 4, y + 8);
                setRocky(x + 5, y + 8);
                setRocky(x + 8, y + 8);
                setRocky(x + 9, y + 8);
                setRocky(x + 10, y + 10);
                setRocky(x + 11, y + 10);
                setRocky(x + 12, y + 10);
                setRocky(x + 10, y + 11);
                setRocky(x + 11, y + 11);
                setRocky(x + 12, y + 12);
                setRocky(x + 10, y + 12);
                setRocky(x + 11, y + 12);
                setRocky(x + 6, y + 13);
                setRocky(x + 7, y + 13);
                setRocky(x + 8, y + 13);
                setRocky(x + 9, y + 13);
                setRocky(x + 10, y + 13);
                setRocky(x + 11, y + 13);
                setRocky(x + 12, y + 13);
                setRocky(x + 13, y + 13);
                setRocky(x + 14, y + 13);
                setRocky(x + 4, y + 14);
                setRocky(x + 5, y + 14);
                setRocky(x + 6, y + 14);
                setRocky(x + 7, y + 14);
                setRocky(x + 8, y + 14);
                setRocky(x + 9, y + 14);
                setRocky(x + 10, y + 14);
                setRocky(x + 11, y + 14);
                setRocky(x + 12, y + 14);
                setRocky(x + 13, y + 14);
                setRocky(x + 14, y + 14);
            }
            else if (select == 2)
            {
                setRocky(x + 3, y);
                setRocky(x + 4, y);
                setRocky(x + 5, y);
                setRocky(x + 9, y);
                setRocky(x + 8, y);
                setRocky(x + 2, y + 1);
                setRocky(x + 3, y + 1);
                setRocky(x + 4, y + 1);
                setRocky(x + 5, y + 1);
                setRocky(x + 8, y + 1);
                setRocky(x + 9, y + 1);
                setRocky(x, y + 2);
                setRocky(x + 1, y + 2);
                setRocky(x + 2, y + 2);
                setRocky(x + 3, y + 2);
                setRocky(x + 4, y + 2);
                setRocky(x + 5, y + 2);
                setRocky(x + 6, y + 2);
                setRocky(x + 7, y + 2);
                setRocky(x + 8, y + 2);
                setRocky(x + 9, y + 2);
                setRocky(x, y + 3);
                setRocky(x + 2, y + 3);
                setRocky(x + 3, y + 3);
                setRocky(x + 4, y + 3);
                setRocky(x + 5, y + 3);
                setRocky(x + 8, y + 3);
                setRocky(x + 3, y + 4);
                setRocky(x + 4, y + 4);
                setRocky(x + 5, y + 4);
            }
            else if (select == 3)
            {
                setRocky(x, y);
                setRocky(x + 1, y);
                setRocky(x + 3, y);
                setRocky(x + 4, y);
                setRocky(x + 5, y);
                setRocky(x + 6, y);
                setRocky(x + 2, y + 1);
                setRocky(x + 3, y + 1);
                setRocky(x + 4, y + 1);
                setRocky(x + 5, y + 2);
                setRocky(x + 4, y + 2);
                setRocky(x + 1, y + 3);
                setRocky(x + 2, y + 3);
                setRocky(x + 3, y + 3);
                setRocky(x + 4, y + 3);
                setRocky(x + 5, y + 3);
                setRocky(x, y + 4);
                setRocky(x + 2, y + 4);
                setRocky(x + 3, y + 4);
                setRocky(x + 4, y + 4);
                setRocky(x + 5, y + 4);
                setRocky(x + 2, y + 6);
                setRocky(x + 3, y + 6);
                setRocky(x + 4, y + 6);
                setRocky(x + 5, y + 6);
                setRocky(x + 2, y + 7);
                setRocky(x + 3, y + 7);
                setRocky(x + 4, y + 7);
                setRocky(x + 5, y + 7);
                setRocky(x + 2, y + 8);
                setRocky(x + 3, y + 8);
                setRocky(x + 4, y + 8);
                setRocky(x + 5, y + 8);
                setRocky(x + 2, y + 9);
                setRocky(x + 3, y + 9);
                setRocky(x + 4, y + 9);
                setRocky(x + 7, y + 7);
                setRocky(x + 8, y + 7);
                setRocky(x + 9, y + 7);
                setRocky(x + 1, y + 7);
                setRocky(x + 7, y + 8);
                setRocky(x + 8, y + 8);
                setRocky(x + 1, y + 8);
                setRocky(x + 7, y + 9);
                setRocky(x + 8, y + 9);
                setRocky(x + 9, y + 9);
                setRocky(x + 2, y + 10);
                setRocky(x + 3, y + 10);
                setRocky(x + 4, y + 10);
                setRocky(x + 5, y + 10);
                setRocky(x + 2, y + 10);
                setRocky(x + 3, y + 10);
                setRocky(x + 4, y + 10);
                setRocky(x + 5, y + 10);
                setRocky(x + 2, y + 10);
                setRocky(x + 3, y + 10);
                setRocky(x + 4, y + 10);
                setRocky(x + 7, y + 10);
                setRocky(x + 8, y + 10);
                setRocky(x + 9, y + 10);
                setRocky(x + 1, y + 10);
                setRocky(x + 7, y + 10);
                setRocky(x + 8, y + 10);
                setRocky(x + 1, y + 10);
                setRocky(x + 7, y + 10);
                setRocky(x + 8, y + 10);
                setRocky(x + 9, y + 10);
                setRocky(x + 2, y + 11);
                setRocky(x + 3, y + 11);
                setRocky(x + 4, y + 11);
                setRocky(x + 5, y + 11);
                setRocky(x + 2, y + 11);
                setRocky(x + 3, y + 11);
                setRocky(x + 4, y + 11);
                setRocky(x + 5, y + 11);
                setRocky(x + 2, y + 11);
                setRocky(x + 3, y + 11);
                setRocky(x + 4, y + 11);
                setRocky(x + 7, y + 11);
                setRocky(x + 8, y + 11);
                setRocky(x + 9, y + 11);
                setRocky(x + 1, y + 11);
                setRocky(x + 7, y + 11);
                setRocky(x + 8, y + 11);
                setRocky(x + 1, y + 11);
                setRocky(x + 7, y + 11);
                setRocky(x + 8, y + 11);
                setRocky(x + 9, y + 11);
                setRocky(x + 2, y + 14);
                setRocky(x + 3, y + 14);
                setRocky(x + 4, y + 14);
                setRocky(x + 7, y + 14);
                setRocky(x + 8, y + 14);
                setRocky(x + 9, y + 14);
                setRocky(x + 1, y + 14);
                setRocky(x + 7, y + 14);
                setRocky(x + 8, y + 14);
                setRocky(x + 1, y + 14);
                setRocky(x + 7, y + 14);
                setRocky(x + 8, y + 14);
                setRocky(x + 9, y + 14);
                setRocky(x + 14, y + 12);
                setRocky(x + 14, y + 11);
                setRocky(x + 13, y + 12);
                setRocky(x + 13, y + 11);
                setRocky(x + 12, y + 12);
                setRocky(x + 12, y + 11);
                setRocky(x + 13, y + 13);
                setRocky(x + 14, y + 13);
                setRocky(x + 13, y + 13);
                setRocky(x + 12, y + 13);
                setRocky(x + 11, y + 13);
                setRocky(x + 10, y + 13);
                setRocky(x + 9, y + 13);
                setRocky(x + 14, y + 3);
                setRocky(x + 14, y + 4);
                setRocky(x + 13, y + 3);
                setRocky(x + 13, y + 4);
                setRocky(x, y);
                setRocky(x + 9, y+6);
                setRocky(x + 11, y + 6);
                setRocky(x + 12, y + 6);
                setRocky(x + 13, y + 6);
                setRocky(x + 14, y + 6);
                setRocky(x + 10, y + 5);
                setRocky(x + 11, y + 5);
                setRocky(x + 12, y + 5);
                setRocky(x + 13, y + 4);
                setRocky(x + 12, y + 4);
                setRocky(x + 9, y + 3);
                setRocky(x + 10, y + 3);
                setRocky(x + 11, y + 3);
                setRocky(x + 12, y + 3);
                setRocky(x + 13, y + 3);
                setRocky(x + 8, y + 2);
                setRocky(x + 10, y + 2);
                setRocky(x + 11, y + 2);
                setRocky(x + 12, y + 2);
                setRocky(x + 13, y + 2);
                setRocky(x + 10, y + 1);
                setRocky(x + 11, y + 1);
                setRocky(x + 12, y + 1);
                setRocky(x + 13, y + 1);
            }
            else if (select == 4)
            {
                for (int i = 1; i < 14; i++)
                {
                    for (int j = i; j < 14; j++)
                    {
                        setRocky(x + j, y + i);
                    }
                }
            }
            else if (select == 5)
            {
                Random rand = new Random();
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (rand.Next(1000) % 100 < 45)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                }
            }
            else if (select == 6)
            {
                Random rand = new Random();
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (rand.Next(1000) % 100 < 55)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                }
            }
        }

        public void makeFoodFormation(int x, int y)
        {
            for (int i = 5; i < 10; i++)
            {
                for (int j = 5; j < 10; j++)
                {
                    setFood(x + j, y + i, 5);
                }
            }
        }

        public void makeWorld(int rocks, int food)
        {
            Random rand = new Random();
            bool freeSpace = false;
            int newX = 0, newY = 0, select = 0;
            int[,] usedSpaces = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    usedSpaces[j, i] = 0;
                }
            }
            //Set up ant hill red
            while (!freeSpace)
            {
                newX = rand.Next(1, 5);
                newY = rand.Next(1, 5);
                if (usedSpaces[newX, newY] == 0)
                {
                    freeSpace = true;
                    usedSpaces[newX, newY] = 1;
                }
            }
            freeSpace = false;
            makeAntHill(newX * 15, newY * 15, "red");

            //set up ant hill black
            while (!freeSpace)
            {
                newX = rand.Next(5, 9);
                newY = rand.Next(5, 9);
                if (usedSpaces[newX, newY] == 0)
                {
                    freeSpace = true;
                    usedSpaces[newX, newY] = 1;
                }
            }
            freeSpace = false;
            makeAntHill(newX * 15, newY * 15, "black");

            //set up rocks
            for (int i = 0; i < rocks; i++)
            {
                while (!freeSpace)
                {
                    newX = rand.Next(10);
                    newY = rand.Next(10);
                    if (usedSpaces[newX, newY] == 0)
                    {
                        select = rand.Next(1, 7);
                        freeSpace = true;
                        usedSpaces[newX, newY] = 1;
                    }
                }
                makeRockFormation(newX * 15, newY * 15, select);
                freeSpace = false;
            }

            //set up food
            for (int i = 0; i < food; i++)
            {
                while (!freeSpace)
                {
                    newX = rand.Next(10);
                    newY = rand.Next(10);
                    if (usedSpaces[newX, newY] == 0)
                    {
                        select = rand.Next(1, 7);
                        freeSpace = true;
                        usedSpaces[newX, newY] = 1;
                    }
                }
                makeFoodFormation(newX * 15, newY * 15);
                freeSpace = false;
            }
        }
    }
}
