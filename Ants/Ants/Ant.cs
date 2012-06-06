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
    public class Ant : Microsoft.Xna.Framework.GameComponent
    {
        public String colour;
        int restingNum;
        public int state, x, y, dir, ID;
        bool carryingFood, isAlive, resting;
        Logic myLogic;
        Tile myTile;
        public Ant(Game game, Logic MyLogic, String Colour, int X, int Y, int Dir, int id)
            : base(game)
        {
            state = 0;
            restingNum = 0;
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
                        myLogic.loadTile(x, y, myLogic.texAntHillRed, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, colour);
                    }
                    else if (colour.ToLower().Equals("black"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntHillBlack, myLogic.spriteBatch, myTile.getRocky(), myTile.getAntHill(), myTile.getFood(), myTile.getNumFood(), false, colour);
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
        public bool getAlive()
        {
            return isAlive;
        }
        public void setDead()
        {
            isAlive = false;
        }
        public void checkDead()
        {
            int antsAround = 0;
            Tile[] surround = new Tile[6];
            if (y % 2 == 0)
            {
                surround[0] = myLogic.getTile(x + 1, y);
                surround[1] = myLogic.getTile(x, y + 1);
                surround[2] = myLogic.getTile(x - 1, y + 1);
                surround[3] = myLogic.getTile(x - 1, y);
                surround[4] = myLogic.getTile(x - 1, y - 1);
                surround[5] = myLogic.getTile(x, y - 1);
            }
            else
            {
                surround[0] = myLogic.getTile(x + 1, y);
                surround[1] = myLogic.getTile(x + 1, y + 1);
                surround[2] = myLogic.getTile(x, y + 1);
                surround[3] = myLogic.getTile(x - 1, y);
                surround[4] = myLogic.getTile(x, y - 1);
                surround[5] = myLogic.getTile(x + 1, y - 1);
            }
            for (int i = 0; i < 6; i++)
            {
                if (surround[i].getAnt() && !surround[i].getColour().Equals(this.colour))
                {
                    antsAround++;
                }
            }
            if (antsAround > 4)
            {
                setDead();
                if(carryingFood)
                {
                    myLogic.loadTile(x, y, myLogic.texTileFood, myLogic.spriteBatch, false, false, true, 4 + myTile.getNumFood(), false, null);
                }
                else
                {
                    myLogic.loadTile(x, y, myLogic.texTileFood, myLogic.spriteBatch, false, false, true, 3 + myTile.getNumFood(), false, null);
                }
            }
        }
        public void mark(int num)
        {
            myTile.setPheremone(colour, num);
        }
        public void unmark()
        {
            myTile.setPheremone(colour, 0);
        }
        public void pickUpFood()
        {
            if (myTile.food)
            {
                myTile.getFood();
                carryingFood = true;
            }
        }
        public void dropFood()
        {
            if (carryingFood)
            {
                if (myTile.getAntHill())
                {
                    if (colour.ToLower().Equals("red"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnHillRed[dir], myLogic.spriteBatch, false, myTile.getAntHill(), true, myTile.getNumFood() + 1, true, colour);
                    }
                    else if (colour.ToLower().Equals("black"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnHillBlack[dir], myLogic.spriteBatch, false, myTile.getAntHill(), true, myTile.getNumFood() + 1, true, colour);
                    }
                }
                else
                {
                    if (colour.ToLower().Equals("red"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnFoodRed[dir], myLogic.spriteBatch, false, myTile.getAntHill(), true, myTile.getNumFood() + 1, true, colour);
                    }
                    else if (colour.ToLower().Equals("black"))
                    {
                        myLogic.loadTile(x, y, myLogic.texAntsOnFoodBlack[dir], myLogic.spriteBatch, false, myTile.getAntHill(), true, myTile.getNumFood() + 1, true, colour);
                    }
                }
                carryingFood = false;
            }
        }
        public void flip(int p, int st1, int st2)
        {
            Random rand = new Random();
            if (rand.Next(p) == 0)
            {
                state = st1;
            }
            else
            {
                state = st2;
            }
        }
        public int getRestingNum()
        {
            return restingNum;
        }
        public bool getResting()
        {
            return resting;
        }
        public void setResting(bool rest)
        {
            resting = rest;
        }
        public void setRestingNum(int rest)
        {
            restingNum = rest;
        }
        public bool hasFood()
        {
            return carryingFood;
        }

    }//end class
}//end namespace
