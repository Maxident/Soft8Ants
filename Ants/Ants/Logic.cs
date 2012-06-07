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
        String gameState;
        //these are the 5 basic tiles, red anthill, black anthill, blank, food, rocky
        public Texture2D texAntHillRed, texAntHillBlack, texTileBlank, texTileFood, texTileRocky;
        //these are arrays of 6 where 0=east, 1=SE. 2=SW (clockwise from east). they are ant on hill, ant on food, and ant on blank square, red and black for each
        public Texture2D[] texAntsOnHillRed, texAntsOnHillBlack, texAntsOnFoodRed, texAntsOnFoodBlack, texAntsBlankRed, texAntsBlankBlack;
        public Texture2D splash, menu, instructions, loadmap, worldinstr, loadbrain, savemap;
        public Tile[,] tiles; //the grid of tiles 150x150
        WorldChecker WC;
        WorldGeneration WG;
        WorldWriter WW;
        Ant[] redAnts, blackAnts;
        AntBrain redBrain, blackBrain;
        int redScore, blackScore;
        KeyboardState oldkbstate, newkbstate;
        SpriteFont myFont, myFont2;
        int menuState;
        KeyboardReader kbreader;
        String loadMapSTR, loadBrainRed, loadBrainBlack, saveMapSTR;
        bool blackLoaded;
        public Logic()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 903;
            this.graphics.PreferredBackBufferHeight = 900;
            //at the moment, the screen is 903x900 resolution, this is for a 150x150 grid of 6x6 squares. it would be 900x900, but the lines are staggered so we needed 3 extra wide
            //when we are done, we can add extra stuff on one side of the screen and make it 1200x900 (4:3) or something sensible
            texAntsOnHillRed = new Texture2D[6];
            texAntsOnHillBlack = new Texture2D[6];
            texAntsOnFoodRed = new Texture2D[6];
            texAntsOnFoodBlack = new Texture2D[6];
            texAntsBlankRed = new Texture2D[6];
            texAntsBlankBlack = new Texture2D[6];

            oldkbstate = new KeyboardState();
            newkbstate = new KeyboardState();

            redAnts = new Ant[114];
            blackAnts = new Ant[114];

            Content.RootDirectory = "Content";
            tiles = new Tile[150, 150];
            WG = new WorldGeneration(this, this);
            WW = new WorldWriter(this);
            //setWorldChecker(@"C:\Users\Max\TestWorld.txt");
            //redBrain = new AntBrain(@"C:\Users\Max\sampleant.txt", redAnts, this);
            //blackBrain = new AntBrain(@"C:\Users\Max\sampleant.txt", blackAnts, this);
            gameState = "intro";
            loadMapSTR = "";
            loadBrainRed = "";
            loadBrainBlack = "";
            saveMapSTR = "";
            menuState = 0;
            kbreader = new KeyboardReader(this);
            blackLoaded = false;
        }
        public void setWorldChecker(String filePath)
        {
            WC = new WorldChecker(WG, filePath);
            WC.go();
        }
        public void setBlackAntBrain(String filePath)
        {
            blackBrain = new AntBrain(filePath, blackAnts, this);
        }
        public void setRedAntBrain(String filePath)
        {
            redBrain = new AntBrain(filePath, redAnts, this);
        }
        //not in use
        protected override void Initialize()
        {
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
            splash = this.Content.Load<Texture2D>("pressenter");
            menu = this.Content.Load<Texture2D>("menu");
            savemap = this.Content.Load<Texture2D>("savemap");
            loadmap = this.Content.Load<Texture2D>("loadmap");
            loadbrain = this.Content.Load<Texture2D>("loadbrains");
            instructions = this.Content.Load<Texture2D>("instructions");
            worldinstr = this.Content.Load<Texture2D>("worldgeninstruc");

            myFont = Content.Load<SpriteFont>("SpriteFont1");
            myFont2 = Content.Load<SpriteFont>("SpriteFont2");

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

        }
        //blank
        protected override void UnloadContent()
        {

        }
        //for updating game mechanics (none yet)
        protected override void Update(GameTime gameTime)
        {
            oldkbstate = newkbstate;
            newkbstate = Keyboard.GetState();
            if (gameState.Equals("intro"))
            {
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    kbreader.reset();
                    gameState = "load brains";
                }
            }
            else if (gameState.Equals("load brains"))
            {
                kbreader.Update(gameTime);
                if (!blackLoaded)
                {
                    loadBrainBlack = kbreader.getText();
                    if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                    {
                        setBlackAntBrain(loadBrainBlack);
                        kbreader.reset();
                        blackLoaded = true;
                    }
                }
                else
                {
                    loadBrainRed = kbreader.getText();
                    if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                    {
                        setRedAntBrain(loadBrainRed);
                        kbreader.reset();
                        gameState = "menu";
                    }
                }
            }
            else if (gameState.Equals("menu"))
            {
                if (newkbstate.IsKeyDown(Keys.Down) && oldkbstate.IsKeyUp(Keys.Down))
                {
                    if (menuState < 3)
                    {
                        menuState++;
                    }
                    else
                    {
                        menuState = 0;
                    }
                }
                if (newkbstate.IsKeyDown(Keys.Up) && oldkbstate.IsKeyUp(Keys.Up))
                {
                    if (menuState > 0)
                    {
                        menuState--;
                    }
                    else
                    {
                        menuState = 3;
                    }
                }
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    if (menuState == 0)
                    {
                        gameState = "instructions";
                    }
                    else if (menuState == 1)
                    {

                        gameState = "world generator p1";
                    }
                    else if (menuState == 2)
                    {
                        gameState = "world loader";
                    }
                    else if (menuState == 3)
                    {
                        LoadTiles(spriteBatch);
                        WG.makeWorld(14, 11);
                        populate();
                        gameState = "";
                    }
                }
            }
            else if (gameState.Equals("instructions"))
            {
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.Back) && oldkbstate.IsKeyUp(Keys.Back))
                {
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.Escape) && oldkbstate.IsKeyUp(Keys.Escape))
                {
                    gameState = "menu";
                }
            }
            else if (gameState.Equals("world generator p1"))
            {
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    gameState = "world generator";
                }
                if (newkbstate.IsKeyDown(Keys.Back) && oldkbstate.IsKeyUp(Keys.Back))
                {
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.Escape) && oldkbstate.IsKeyUp(Keys.Escape))
                {
                    gameState = "menu";
                }
            }
            else if (gameState.Equals("world generator"))
            {
                if (newkbstate.IsKeyDown(Keys.Space) && oldkbstate.IsKeyUp(Keys.Space))
                {
                    LoadTiles(spriteBatch);
                    WG.makeWorld(14, 11);
                }
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    populate();
                    gameState = "";
                }
                if (newkbstate.IsKeyDown(Keys.Back) && oldkbstate.IsKeyUp(Keys.Back))
                {
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.S) && oldkbstate.IsKeyUp(Keys.S))
                {
                    gameState = "save map";
                }
                if (newkbstate.IsKeyDown(Keys.Escape) && oldkbstate.IsKeyUp(Keys.Escape))
                {
                    gameState = "menu";
                }

            }
            else if (gameState.Equals("save map"))
            {
                kbreader.Update(gameTime);
                saveMapSTR = kbreader.getText();
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    WW.setLines();
                    WW.write(saveMapSTR);
                    kbreader.reset();
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.Escape) && oldkbstate.IsKeyUp(Keys.Escape))
                {
                    gameState = "menu";
                }
            }
            else if (gameState.Equals("world loader"))
            {
                kbreader.Update(gameTime);
                loadMapSTR = kbreader.getText();
                if (newkbstate.IsKeyDown(Keys.Escape) && oldkbstate.IsKeyUp(Keys.Escape))
                {
                    gameState = "menu";
                }
                if (newkbstate.IsKeyDown(Keys.Enter) && oldkbstate.IsKeyUp(Keys.Enter))
                {
                    setWorldChecker(loadMapSTR);
                    kbreader.reset();
                    populate();
                    gameState = "";
                }
            }

            else
            {

                for (int i = 0; i < 114; i++)
                {
                    redBrain.executeCommand(i);
                    blackBrain.executeCommand(i);
                }
                for (int i = 0; i < 150; i++)
                {
                    for (int j = 0; j < 150; j++)
                    {
                        if (tiles[j, i].getAntHill())
                        {
                            if (tiles[j, i].getFood())
                            {
                                if (tiles[j, i].getColour().ToLower().Equals("red"))
                                {
                                    redScore += tiles[j, i].getNumFood();
                                    tiles[j, i].setNumFood(0);
                                    tiles[j, i].setFood(false);
                                }
                                else if (tiles[j, i].getColour().ToLower().Equals("black"))
                                {
                                    blackScore += tiles[j, i].getNumFood();
                                    tiles[j, i].setNumFood(0);
                                    tiles[j, i].setFood(false);
                                }
                            }
                        }
                    }
                }
                base.Update(gameTime);
            }
        }
        //draws each tile (which is everything, ants food and rocks are all different tile textures)
        protected override void Draw(GameTime gameTime)
        {
            if (gameState.Equals("intro"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(splash, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }

            else if (gameState.Equals("load brains"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(loadbrain, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(myFont2, loadBrainBlack, new Vector2(125, 350), Color.White);
                spriteBatch.DrawString(myFont2, loadBrainRed, new Vector2(125, 600), Color.White);
                spriteBatch.End();
            }
            else if (gameState.Equals("menu"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);

                if (menuState == 0)
                {
                    spriteBatch.DrawString(myFont, "Instructions", new Vector2(220, 200), Color.Red);
                    spriteBatch.DrawString(myFont, "Instructions", new Vector2(221, 201), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(myFont, "Instructions", new Vector2(220, 200), Color.Red);
                    spriteBatch.DrawString(myFont, "Instructions", new Vector2(221, 201), Color.Black);
                }


                if (menuState == 1)
                {
                    spriteBatch.DrawString(myFont, "World Generator", new Vector2(170, 300), Color.Red);
                    spriteBatch.DrawString(myFont, "World Generator", new Vector2(171, 301), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(myFont, "World Generator", new Vector2(170, 300), Color.Red);
                    spriteBatch.DrawString(myFont, "World Generator", new Vector2(171, 301), Color.Black);
                }
                if (menuState == 2)
                {
                    spriteBatch.DrawString(myFont, "World Loader", new Vector2(220, 400), Color.Red);
                    spriteBatch.DrawString(myFont, "World Loader", new Vector2(221, 401), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(myFont, "World Loader", new Vector2(220, 400), Color.Red);
                    spriteBatch.DrawString(myFont, "World Loader", new Vector2(221, 401), Color.Black);
                }
                if (menuState == 3)
                {
                    spriteBatch.DrawString(myFont, "Start Random", new Vector2(220, 500), Color.Red);
                    spriteBatch.DrawString(myFont, "Start Random", new Vector2(221, 501), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(myFont, "Start Random", new Vector2(220, 500), Color.Red);
                    spriteBatch.DrawString(myFont, "Start Random", new Vector2(221, 501), Color.Black);
                }
                spriteBatch.End();
            }
            else if (gameState.Equals("instructions"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(instructions, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            else if (gameState.Equals("world generator"))
            {

                GraphicsDevice.Clear(Color.Black);
                for (int i = 0; i < 150; i++)
                {
                    for (int j = 0; j < 150; j++)
                    {
                        tiles[i, j].Draw(gameTime);
                    }
                }
            }
            else if (gameState.Equals("world generator p1"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(worldinstr, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            else if (gameState.Equals("world loader"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(loadmap, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(myFont2, loadMapSTR, new Vector2(20, 600), Color.White);
                spriteBatch.End();
            }
            else if (gameState.Equals("save map"))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(savemap, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(myFont2, saveMapSTR, new Vector2(20, 600), Color.White);
                spriteBatch.End();
            }
            else
            {
                
                GraphicsDevice.Clear(Color.Black);
                for (int i = 0; i < 150; i++)
                {
                    for (int j = 0; j < 150; j++)
                    {
                        tiles[i, j].Draw(gameTime);
                        
                    }
                }
                spriteBatch.Begin();
                spriteBatch.DrawString(myFont, redScore.ToString(), new Vector2(20, 10), Color.Red);
                spriteBatch.DrawString(myFont, blackScore.ToString(), new Vector2(850, 10), Color.Black);
                spriteBatch.End();
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
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2(x * 6, y * 6), spriteBatch, true, false, false, 0, false, "", 0, 0);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2(x * 6, y * 6), spriteBatch, false, false, false, 0, false, "", 0, 0);
                        }
                    }
                    else
                    {
                        if (x == 0 || x == 149 || y == 0 || y == 149)
                        {
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2((x * 6) + 3, y * 6), spriteBatch, true, false, false, 0, false, "", 0, 0);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2((x * 6) + 3, y * 6), spriteBatch, false, false, false, 0, false, "", 0, 0);
                        }
                    }
                }
            }
        }
        public void loadTile(int x, int y, Texture2D tex, SpriteBatch spriteBatch, Boolean rocky, Boolean antHill, Boolean food, int numFood, Boolean ant, String antColour)
        {
            Vector2 newPos = new Vector2(tiles[x, y].getPos("x"), tiles[x, y].getPos("y"));
            tiles[x, y] = new Tile(this, tex, newPos, spriteBatch, rocky, antHill, food, numFood, ant, antColour, 0, 0);
        }
        public Tile getTile(int x, int y)
        {
            return tiles[x, y];
        }
        public Ant getAntOnTile(int X, int Y)
        {
            for (int i = 0; i < redAnts.Length; i++)
            {
                if (redAnts[i].x == X && redAnts[i].y == Y && redAnts[i].getAlive())
                {
                    return redAnts[i];
                }
                else if (blackAnts[i].x == X && blackAnts[i].y == Y && blackAnts[i].getAlive())
                {
                    return blackAnts[i];
                }
            }
            return null;
        }
        public Tile getAdjacentTile(int x, int y, int dir)
        {
            if (y % 2 == 0)
            {
                if (dir == 0)
                {
                    return tiles[x + 1, y];
                }
                else if (dir == 1)
                {
                    return tiles[x, y + 1];
                }
                else if (dir == 1)
                {
                    return tiles[x - 1, y + 1];
                }
                else if (dir == 1)
                {
                    return tiles[x - 1, y];
                }
                else if (dir == 1)
                {
                    return tiles[x - 1, y - 1];
                }
                else if (dir == 1)
                {
                    return tiles[x, y - 1];
                }
            }
            else
            {
                if (dir == 0)
                {
                    return tiles[x + 1, y];
                }
                else if (dir == 1)
                {
                    return tiles[x + 1, y + 1];
                }
                else if (dir == 1)
                {
                    return tiles[x, y + 1];
                }
                else if (dir == 1)
                {
                    return tiles[x - 1, y];
                }
                else if (dir == 1)
                {
                    return tiles[x, y - 1];
                }
                else if (dir == 1)
                {
                    return tiles[x + 1, y - 1];
                }
            }
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
