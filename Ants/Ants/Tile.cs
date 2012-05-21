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
        Texture2D currentTex;
        Vector2 pos;
        SpriteBatch spriteBatch;
        int height, width, numFood;
        Boolean rocky, food, antHill, ant;
        String antColour;
        public Tile(Game game, Texture2D CurrentTex, Vector2 Position, SpriteBatch spritebatch, Boolean Rocky, Boolean Anthill, Boolean Food, int NumFood, Boolean Ant, String AntColour, int pheremone)
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
            antColour = AntColour;
        }
        public override void Initialize()
        {
            // TODO: Add your initialization code here

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
        public Boolean getRocky()
        {
            return rocky;
        }
        public Boolean getFood()
        {
            return food;
        }
        public Boolean getAntHill()
        {
            return antHill;
        }
        public Boolean getAnt()
        {
            return ant;
        }
        public int getNumFood()
        {
            return numFood;
        }
        public String getAntColour()
        {
            return antColour;
        }
        public Vector2 getPos()
        {
            return pos;
        }
    }
}
