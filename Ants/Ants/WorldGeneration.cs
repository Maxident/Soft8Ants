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
            myLogic = logic;
        }

        public override void Initialize()
        {

            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
