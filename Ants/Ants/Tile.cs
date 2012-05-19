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
        int height, width;
        public Tile(Game game, Texture2D CurrentTex, Vector2 Position, SpriteBatch spritebatch)
            : base(game)
        {
            height = Constants.TileHeight;
            width = Constants.TileWidth;
            currentTex = CurrentTex;
            pos = Position;
            spriteBatch = spritebatch;
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
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
