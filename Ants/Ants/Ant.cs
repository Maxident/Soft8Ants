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
        Boolean carryingFood;
        public Ant(Game game, String Colour, int X, int Y, int Dir, int id)
            : base(game)
        {
            carryingFood = false;
            colour = Colour;
            x = X;
            y = Y;
            dir = Dir;
            ID = id;
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
