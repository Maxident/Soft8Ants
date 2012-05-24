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
        public SpriteBatch spriteBatch;
        //these are the 5 basic tiles, red anthill, black anthill, blank, food, rocky
        public Texture2D texAntHillRed, texAntHillBlack,  texTileBlank, texTileFood, texTileRocky; 
        //these are arrays of 6 where 0=east, 1=SE. 2=SW (clockwise from east). they are ant on hill, ant on food, and ant on blank square, red and black for each
        public Texture2D[] texAntsOnHillRed, texAntsOnHillBlack, texAntsOnFoodRed, texAntsOnFoodBlack, texAntsBlankRed, texAntsBlankBlack;
        public Tile[,] tiles; //the grid of tiles 150x150
        WorldGeneration WG;
        Ant[] redAnts, blackAnts;
        public Logic()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 903;
            this.graphics.PreferredBackBufferHeight = 900;
            //at the moment, the screen is 903x900 resolution, this is for a 150x150 grid of 6x6 squares. it would be 900x900, but the lines are staggered so we needed 3 extra wide
            //when we are done, we can add extra stuff on one side of the screen and make it 1200x900 (4:3) or something sensible
            Content.RootDirectory = "Content";
            tiles = new Tile[150,150];
        }
        //just some initial start up stuff in here
        protected override void Initialize()
        {
            texAntsOnHillRed = new Texture2D[6];
            texAntsOnHillBlack = new Texture2D[6];
            texAntsOnFoodRed = new Texture2D[6];
            texAntsOnFoodBlack = new Texture2D[6];
            texAntsBlankRed = new Texture2D[6];
            texAntsBlankBlack = new Texture2D[6];

            WG = new WorldGeneration(this, this);    // this is quite important, check out WorldGeneration Class

            redAnts = new Ant[127];
            blackAnts = new Ant[127];

            base.Initialize();  
        }
        //this is just loading all the png files to Texture2D
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
            
            WG.makeWorld(14, 11);

            populate();

            
        }
        //blank
        protected override void UnloadContent()
        {

        }
        //for updating game mechanics (none yet)
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < 114; i++)
            {
                redAnts[i].turn("left");

                redAnts[i].move();
                redAnts[i].move();
                redAnts[i].move();
                redAnts[i].move();
                redAnts[i].move();
            }

            base.Update(gameTime);
        }
        //draws each tile (which is everything, ants food and rocks are all different tile textures)
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
        //made this method just to place all the tiles on the screen. all blank except rocky round the edges
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
        
        public void loadTile(int x, int y, Texture2D tex, SpriteBatch spriteBatch, Boolean rocky, Boolean antHill, Boolean food, int numFood, Boolean ant, String antColour)
        {
            Vector2 newPos = tiles[x,y].getPos();
            tiles[x, y] = new Tile(this, tex, newPos, spriteBatch, rocky, antHill, food, numFood, ant, antColour, 0);
        }

        public Tile getTile(int x, int y)
        {
            return tiles[x, y];
        }

        public void populate()
        {
            int redID = 0, blackID = 0;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (tiles[j, i].getAntHill())
                    {
                        if (tiles[j, i].getColour().ToLower().Equals("red"))
                        {
                            redAnts[redID] = new Ant(this, this, "red", j, i, 0, redID);
                            redID++;
                        }
                        else if (tiles[j, i].getColour().ToLower().Equals("black"))
                        {
                            blackAnts[blackID] = new Ant(this, this, "black", j, i, 0, blackID);
                            blackID++;
                        }
                    }
                }
            }
        }
    
    }
}
