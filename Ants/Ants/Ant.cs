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
    //not actually done much here, just a bit of setup
    public class Ant : Microsoft.Xna.Framework.GameComponent
    {
        String colour;
        int x, y, dir, ID;
        bool carryingFood, isAlive, resting;
        Logic myLogic;
        Tile myTile;
        public Ant(Game game, Logic MyLogic, String Colour, int X, int Y, int Dir, int id)
            : base(game)
        {
            carryingFood = false;
            isAlive = true;
            resting = false;
            colour = Colour;
            x = X;
            y = Y;
            dir = Dir;
            ID = id;
            myLogic = MyLogic;
            myTile = myLogic.getTile(x, y);
            if(colour.Equals("red"))
            {
                myLogic.loadTile(x, y, myLogic.texAntsOnHillRed[0], myLogic.spriteBatch, false, true, false, 0, true, "red");
            }
            else if (colour.Equals("black"))
            {
                myLogic.loadTile(x, y, myLogic.texAntsOnHillBlack[0], myLogic.spriteBatch, false, true, false, 0, true, "black");
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void turn(String lr)
        {
            myTile = myLogic.getTile(x, y);
            if (lr.ToLower().Equals("left"))
            {
                if (dir == 0)
                {
                    dir = 5;
                }
                else
                {
                    dir--;
                }
                    
            }
            else if (lr.ToLower().Equals("right"))
            {
                if (dir == 5)
                {
                    dir = 0;
                }
                else
                {
                    dir++;
                }
            }

            if (colour.ToLower().Equals("red"))
            {
                myLogic.loadTile(x, y, myLogic.texAntsOnHillRed[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
            }
            else if (colour.ToLower().Equals("black"))
            {
                myLogic.loadTile(x, y, myLogic.texAntsOnHillBlack[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
            }
        }
        public void move()
        {
            if (sense("ahead").getRocky() == false && sense("ahead").getAnt() == false)
            {
                if (myTile.getFood())
                {
                    myLogic.loadTile(x, y, myLogic.texTileFood, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, null);
                }
                else if (myTile.getAntHill())
                {
                    if (colour.ToLower().Equals("red"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntHillRed, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, null);
                    }
                    else if (colour.ToLower().Equals("black"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntHillBlack, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, null);
                    }
                }
                else
                {
                    myLogic.loadTile(x, y, myLogic.texTileBlank, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, null);
                }
                switch (dir)
                {
                    case 0:
                        x++;
                        break;
                    case 1:
                        if (y % 2 == 0)
                        {
                            y++;
                        }
                        else
                        {
                            x++; y++;
                        }
                        break;
                    case 2:
                        if (y % 2 == 0)
                        {
                            x--; y++;
                        }
                        else
                        {
                            y++;
                        }
                        break;
                    case 3:
                        x--;
                        break;
                    case 4:
                        if (y % 2 == 0)
                        {
                            x--; y--;
                        }
                        else
                        {
                            y--;
                        }
                        break;
                    case 5:
                        if (y % 2 == 0)
                        {
                            y--;
                        }
                        else
                        {
                            x++;
                            y--;
                        }
                        break;
                }
                myTile = myLogic.getTile(x, y);


                if (colour.ToLower().Equals("red"))
                {
                    if (myTile.getFood())
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnFoodRed[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                    else if (myTile.getAntHill())
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnHillRed[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                    else
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsBlankRed[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                }
                else if (colour.ToLower().Equals("black"))
                {
                    if (myTile.getFood())
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnFoodBlack[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                    else if (myTile.getAntHill())
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnHillBlack[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                    else
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsBlankBlack[dir], myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), true, colour);
                    }
                }
            }
        }
        public Tile sense(String whichTile)
        {
            int tempdir = dir;
            bool ready = false;
            if(whichTile.ToLower().Equals("Here"))
            {
                return myTile;
            }
            else if (whichTile.ToLower().Equals("ahead"))
            {
                ready = true;
            }
            else if (whichTile.ToLower().Equals("leftahead"))
            {
                if (tempdir == 0)
                {
                    tempdir = 5;
                }
                else
                {
                    tempdir--;
                }
                ready = true;
            }
            else if (whichTile.ToLower().Equals("rightahead"))
            {
                if (tempdir == 5)
                {
                    tempdir = 0;
                }
                else
                {
                    tempdir++;
                }
                ready = true;
            }
            if (ready)
            {
                switch (tempdir)
                {
                    case 0:
                        return myLogic.getTile(x+1, y); 
                    case 1:
                        if (y % 2 == 0)
                        {
                            return myLogic.getTile(x, y + 1);
                        }
                        else
                        {
                            return myLogic.getTile(x + 1, y + 1);
                        }
                    case 2:
                        if (y % 2 == 0)
                        {
                            return myLogic.getTile(x - 1, y + 1);
                        }
                        else
                        {
                            return myLogic.getTile(x, y + 1);
                        }
                    case 3:
                        return myLogic.getTile(x - 1, y); 
                    case 4:
                        if (y % 2 == 0)
                        {
                            return myLogic.getTile(x - 1, y - 1);
                        }
                        else
                        {
                            return myLogic.getTile(x, y - 1);
                        }
                    case 5:
                        if (y % 2 == 0)
                        {
                            return myLogic.getTile(x, y - 1);
                        }
                        else
                        {
                            return myLogic.getTile(x + 1, y - 1);
                        }
                  }
            }
            return myTile;
        }

        public bool getResting()
        {
            return resting;
        }
        public void setResting(bool newRest)
        {
            resting = newRest;
        }
        public bool getAlive()
        {
            return isAlive;
        }
        public void setDead()
        {
            isAlive = false;
        }
    }//end class
}//end namespace
