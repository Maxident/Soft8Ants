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
    public class Tile : Microsoft.Xna.Framework.GameComponent
    {
        //probably not too much to look at here, most of the tile control is in other classes methods anyway
        Texture2D currentTex;
        Vector2 pos;
        SpriteBatch spriteBatch;
        int height, width, numFood, pherBlack, pherRed;
        public Boolean rocky, food, antHill, ant;
        String colour;
        public Tile(Game game, Texture2D CurrentTex, Vector2 Position, SpriteBatch spritebatch, 
            Boolean Rocky, Boolean Anthill, Boolean Food, int NumFood, Boolean Ant, String Colour, int pheremoneBlack, int pheremoneRed)
            : base(game)
        {
            height = Constants.TileHeight;
            width = Constants.TileWidth;
            currentTex = CurrentTex;
            pos = Position;
            spriteBatch = spritebatch;
            rocky = Rocky;
            antHill = Anthill;
            food = Food;
            numFood = NumFood;
            ant = Ant;
            colour = Colour;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(currentTex, pos, null, Color.White);
            spriteBatch.End();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void setTexture(Texture2D newTex)
        {
            currentTex = newTex;
        }
        public bool getRocky()
        {
            return rocky;
        }
        public bool getFood()
        {
            return food;
        }
        public void setFood(bool newFood)
        {
            food = newFood;
        }
        public bool getAntHill()
        {
            return antHill;
        }
        public bool getAnt()
        {
            return ant;
        }
        public int getNumFood()
        {
            return numFood;
        }
        public void setNumFood(int newNum)
        {
            numFood = newNum;
        }
        public String getColour()
        {
            return colour;
        }
        public int getPos(String XY)
        {
            if (XY.ToLower().Equals("x"))
            {
                return (int)pos.X;
            }
            else if (XY.ToLower().Equals("y"))
            {
                return (int)pos.Y;
            }
            return -1;
        }
        public int getTilePos(String XY)
        {
            if (XY.ToLower().Equals("x"))
            {
                return (int)pos.X/6;
            }
            else if (XY.ToLower().Equals("y"))
            {
                return (int)pos.Y/6;
            }
            return -1;
        }
        public void setPheremone(string RB, int num)
        {
            if (RB.ToLower().Equals("red"))
            {
                pherRed = num;
            }
            else if (RB.ToLower().Equals("black"))
            {
                pherBlack = num;
            }
        }
        public int getPheremone(string RB)
        {
            if (RB.ToLower().Equals("red"))
            {
                return pherRed;
            }
            else if (RB.ToLower().Equals("black"))
            {
                return pherBlack;
            }
            return -1;
        }
        public void takeFood()
        {
            if (food)
            {
                numFood--;
                if (numFood == 0)
                {
                    food = false;
                }
            }
        }
    }
}
