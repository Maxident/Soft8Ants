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
    public class Logic : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //these are the 5 basic tiles, red anthill, black anthill, blank, food, rocky
        Texture2D texAntHillRed, texAntHillBlack,  texTileBlank, texTileFood, texTileRocky; 
        //these are arrays of 6 where 0=east, 1=SE. 2=SW (clockwise from east). they are ant on hill, ant on food, and ant on blank square, red and black for each
        Texture2D[] texAntsOnHillRed, texAntsOnHillBlack, texAntsOnFoodRed, texAntsOnFoodBlack, texAntsBlankRed, texAntsBlankBlack; 
        Tile[,] tiles;
        public Logic()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 903;
            this.graphics.PreferredBackBufferHeight = 903;
            Content.RootDirectory = "Content";
            tiles = new Tile[150,150];
        }
        protected override void Initialize()
        {
            texAntsOnHillRed = new Texture2D[6];
            texAntsOnHillBlack = new Texture2D[6];
            texAntsOnFoodRed = new Texture2D[6];
            texAntsOnFoodBlack = new Texture2D[6];
            texAntsBlankRed = new Texture2D[6];
            texAntsBlankBlack = new Texture2D[6];


            base.Initialize();  
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texAntHillRed = this.Content.Load<Texture2D>("TileAntHillR");
            texAntHillBlack = this.Content.Load<Texture2D>("TileAntHillB");
            texTileBlank = this.Content.Load<Texture2D>("TileBlank");
            texTileRocky = this.Content.Load<Texture2D>("TileRocky");
            texTileFood = this.Content.Load<Texture2D>("TileFood");


            //this section is to link each picture/tile. each pictures name says what it is eg. TileFoodAndAnt is a tile with ant on food, 
            //then a 2 letter code where SE= southeast EE= east etc, followed by B or R for black or red
            texAntsOnHillRed[0] = this.Content.Load<Texture2D>("TileAntAndHillEER");
            texAntsOnHillRed[1] = this.Content.Load<Texture2D>("TileAntAndHillSER");
            texAntsOnHillRed[2] = this.Content.Load<Texture2D>("TileAntAndHillSWR");
            texAntsOnHillRed[3] = this.Content.Load<Texture2D>("TileAntAndHillWWR");
            texAntsOnHillRed[4] = this.Content.Load<Texture2D>("TileAntAndHillNWR");
            texAntsOnHillRed[5] = this.Content.Load<Texture2D>("TileAntAndHillNER");
            texAntsOnHillBlack[0] = this.Content.Load<Texture2D>("TileAntAndHillEEB");
            texAntsOnHillBlack[1] = this.Content.Load<Texture2D>("TileAntAndHillSEB");
            texAntsOnHillBlack[2] = this.Content.Load<Texture2D>("TileAntAndHillSWB");
            texAntsOnHillBlack[3] = this.Content.Load<Texture2D>("TileAntAndHillWWB");
            texAntsOnHillBlack[4] = this.Content.Load<Texture2D>("TileAntAndHillNWB");
            texAntsOnHillBlack[5] = this.Content.Load<Texture2D>("TileAntAndHillNEB");

            texAntsOnFoodRed[0] = this.Content.Load<Texture2D>("TileFoodAndAntEER");
            texAntsOnFoodRed[1] = this.Content.Load<Texture2D>("TileFoodAndAntSER");
            texAntsOnFoodRed[2] = this.Content.Load<Texture2D>("TileFoodAndAntSWR");
            texAntsOnFoodRed[3] = this.Content.Load<Texture2D>("TileFoodAndAntWWR");
            texAntsOnFoodRed[4] = this.Content.Load<Texture2D>("TileFoodAndAntNWR");
            texAntsOnFoodRed[5] = this.Content.Load<Texture2D>("TileFoodAndAntNER");
            texAntsOnFoodBlack[0] = this.Content.Load<Texture2D>("TileFoodAndAntEEB");
            texAntsOnFoodBlack[1] = this.Content.Load<Texture2D>("TileFoodAndAntSEB");
            texAntsOnFoodBlack[2] = this.Content.Load<Texture2D>("TileFoodAndAntSWB");
            texAntsOnFoodBlack[3] = this.Content.Load<Texture2D>("TileFoodAndAntWWB");
            texAntsOnFoodBlack[4] = this.Content.Load<Texture2D>("TileFoodAndAntNWB");
            texAntsOnFoodBlack[5] = this.Content.Load<Texture2D>("TileFoodAndAntNEB");

            texAntsBlankRed[0] = this.Content.Load<Texture2D>("TileAntEER");
            texAntsBlankRed[1] = this.Content.Load<Texture2D>("TileAntSER");
            texAntsBlankRed[2] = this.Content.Load<Texture2D>("TileAntSWR");
            texAntsBlankRed[3] = this.Content.Load<Texture2D>("TileAntWWR");
            texAntsBlankRed[4] = this.Content.Load<Texture2D>("TileAntNWR");
            texAntsBlankRed[5] = this.Content.Load<Texture2D>("TileAntNER");
            texAntsBlankBlack[0] = this.Content.Load<Texture2D>("TileAntEEB");
            texAntsBlankBlack[1] = this.Content.Load<Texture2D>("TileAntSEB");
            texAntsBlankBlack[2] = this.Content.Load<Texture2D>("TileAntSWB");
            texAntsBlankBlack[3] = this.Content.Load<Texture2D>("TileAntWWB");
            texAntsBlankBlack[4] = this.Content.Load<Texture2D>("TileAntNWB");
            texAntsBlankBlack[5] = this.Content.Load<Texture2D>("TileAntNEB");

            
            LoadTiles(spriteBatch);
            testAntHill();
            testRocks();
            testRocks2();

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    tiles[i, j].Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
        private void LoadTiles(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < 150; y++)
            {
                for (int x = 0; x < 150; x++)
                {
                    if (y % 2 == 0)
                    {
                        if (x == 0 || x == 149 || y == 0 || y == 149)
                        {
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2(x * 6, y * 6), spriteBatch, true, false, false, 0, false, "", 0);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2(x * 6, y * 6), spriteBatch, false, false, false, 0, false, "", 0);
                        }
                    }
                    else
                    {
                        if (x == 0 || x == 149 || y == 0 || y == 149)
                        {
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2((x * 6) + 3, y * 6), spriteBatch, true, false, false, 0, false, "", 0);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2((x * 6) + 3, y * 6), spriteBatch, false, false, false, 0, false, "", 0);
                        }
                    }
                }
                

            }
        }
        private void loadTile(int x, int y, Texture2D tex, SpriteBatch spriteBatch, Boolean rocky, Boolean antHill, Boolean food, int numFood, Boolean ant, String antColour)
        {
            Vector2 newPos = tiles[x,y].getPos();
            tiles[x, y] = new Tile(this, tex, newPos, spriteBatch, rocky, antHill, food, numFood, ant, antColour, 0);
        }
        
        
        
        
        
        
        
        
        
        
        private void testAntHill()
        {
            loadTile(5, 5, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");
            loadTile(6, 5, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");

            loadTile(5, 6, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");
            loadTile(6, 6, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");
            loadTile(7, 6, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");

            loadTile(5, 7, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");
            loadTile(6, 7, texAntHillBlack, spriteBatch, false, true, false, 0, true, "black");

            loadTile(5, 4, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(6, 4, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(7, 4, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");

            loadTile(4, 5, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(7, 5, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");

            loadTile(4, 6, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(8, 6, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");

            loadTile(4, 7, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(7, 7, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");

            loadTile(5, 8, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(6, 8, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
            loadTile(7, 8, texAntHillBlack, spriteBatch, false, true, false, 0, false, "");
        }
        private void testRocks()
        {
            loadTile(75, 50, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 50, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(77, 50, texTileRocky, spriteBatch, true, false, false, 0, false, "");

            loadTile(74, 51, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(75, 51, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(76, 51, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(77, 51, texTileRocky, spriteBatch, true, false, false, 0, false, "");

            loadTile(74, 52, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(75, 52, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 52, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(77, 52, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(78, 52, texTileRocky, spriteBatch, true, true, false, 0, false, "");

            loadTile(73, 53, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(74, 53, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(75, 53, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 53, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(77, 53, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(78, 53, texTileRocky, spriteBatch, true, true, false, 0, false, "");

            loadTile(74, 54, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(75, 54, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 54, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(77, 54, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(78, 54, texTileRocky, spriteBatch, true, false, false, 0, false, "");

            loadTile(74, 55, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(75, 55, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 55, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(77, 55, texTileRocky, spriteBatch, true, true, false, 0, false, "");

            loadTile(75, 56, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(76, 56, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(77, 56, texTileRocky, spriteBatch, true, false, false, 0, false, "");
        }
        private void testRocks2()
        {
            loadTile(100, 110, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(101, 110, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(102, 110, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 110, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 110, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(105, 110, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(106, 110, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(100, 111, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(101, 111, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(102, 111, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 111, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 111, texTileRocky, spriteBatch, true, true, false, 0, false, "");
            loadTile(105, 111, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(106, 111, texTileRocky, spriteBatch, true, false, false, 0, false, "");

            loadTile(101, 112, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 112, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(101, 113, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 113, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 114, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 114, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 115, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 115, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 116, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 116, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 117, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 117, texTileRocky, spriteBatch, true, false, false, 0, false, "");

            loadTile(104, 109, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(105, 109, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 108, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(105, 108, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 107, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 107, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 106, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(104, 106, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 105, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 105, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(102, 104, texTileRocky, spriteBatch, true, false, false, 0, false, "");
            loadTile(103, 104, texTileRocky, spriteBatch, true, false, false, 0, false, "");

        }
    }
}
