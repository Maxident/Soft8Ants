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
        Texture2D texTileBlank, texTileRocky;
        Vector2 vectTile;
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
            


            base.Initialize();  
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texTileBlank = this.Content.Load<Texture2D>("TileBlank");
            texTileRocky = this.Content.Load<Texture2D>("TileRocky");
            LoadTiles(spriteBatch);
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
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2(x * 6, y * 6), spriteBatch);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2(x * 6, y * 6), spriteBatch);
                        }
                    }
                    else
                    {
                        if (x == 0 || x == 149 || y == 0 || y == 149)
                        {
                            tiles[x, y] = new Tile(this, texTileRocky, new Vector2((x * 6) + 3, y * 6), spriteBatch);
                        }
                        else
                        {
                            tiles[x, y] = new Tile(this, texTileBlank, new Vector2((x * 6) + 3, y * 6), spriteBatch);
                        }
                    }
                }
            }
        }
    }
}
