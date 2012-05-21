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
                myLogic.loadTile(x, y, myLogic.texAntHillRed, myLogic.spriteBatch, false, true, false, 0, false, "black");
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

                for (int i = 3; i < 9; i++)
                {
                    setAntHill(x + i, y, RB);
                }
                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y + 1, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 2, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 3, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 4, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 5, RB);
                }
                for (int i = 0; i < 12; i++)
                {
                    setAntHill(x + i, y + 6, RB);
                }
                for (int i = 1; i < 12; i++)
                {
                    setAntHill(x + i, y + 7, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 8, RB);
                }
                for (int i = 2; i < 11; i++)
                {
                    setAntHill(x + i, y + 9, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 10, RB);
                }
                for (int i = 3; i < 10; i++)
                {
                    setAntHill(x + i, y + 11, RB);
                }
                for (int i = 3; i < 9; i++)
                {
                    setAntHill(x + i, y + 12, RB);
                }
            }
            else
            {

                for (int i = 3; i < 9; i++)
                {
                    setAntHill(x + i, y, RB);
                }
                for (int i = 2; i < 9; i++)
                {
                    setAntHill(x + i, y + 1, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 2, RB);
                }
                for (int i = 1; i < 10; i++)
                {
                    setAntHill(x + i, y + 3, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 4, RB);
                }
                for (int i = 0; i < 11; i++)
                {
                    setAntHill(x + i, y + 5, RB);
                }
                for (int i = 0; i < 12; i++)
                {
                    setAntHill(x + i, y + 6, RB);
                }
                for (int i = 0; i < 11; i++)
                {
                    setAntHill(x + i, y + 7, RB);
                }
                for (int i = 1; i < 11; i++)
                {
                    setAntHill(x + i, y + 8, RB);
                }
                for (int i = 1; i < 10; i++)
                {
                    setAntHill(x + i, y + 9, RB);
                }
                for (int i = 2; i < 10; i++)
                {
                    setAntHill(x + i, y + 10, RB);
                }
                for (int i = 2; i < 9; i++)
                {
                    setAntHill(x + i, y + 11, RB);
                }
                for (int i = 3; i < 9; i++)
                {
                    setAntHill(x + i, y + 12, RB);
                }
            }
            


        }

        //makes an rock formation where x and y are the top left corner, make sure to leave atleast 10 squares either way, so make sure that 0 <= x <= 140 AND 0 <= y <= 140
        //int select is a number 1-6 which are different formations. 1-4 are like preset formations, (which are slightly different depending on whether y is odd or even)
        //and 5 and 6 are random, 5 is quite sparse, 6 is quite solid
        public void makeRockFormation(int x, int y, int select)
        {
            if(select == 1)
            {
                setRocky(x + 2, y);
                setRocky(x + 3, y);
                setRocky(x + 4, y);
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
                setRocky(x + 8, y + 9);
                setRocky(x + 9, y + 9);
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
            }
            else if (select == 4)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        for (int j = i; j < 10 - i; j++)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                    else
                    {
                        for (int j = 10 -i; j < i; j++)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                }
            }
            else if (select == 5)
            {
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (rand.Next(99) % 3 == 0)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                }
            }
            else if (select == 6)
            {
                Random rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (rand.Next(200) % 4 > 0)
                        {
                            setRocky(x + j, y + i);
                        }
                    }
                }
            }
        }

    }
}
