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
    public class KeyboardReader : Microsoft.Xna.Framework.GameComponent
    {
        String readText;
        KeyboardState newkbstate, oldkbstate;
        public KeyboardReader(Game game) : base(game)
        {
            readText = "C:\\";
            newkbstate = Keyboard.GetState();
            oldkbstate = Keyboard.GetState();
        }
        public override void Update(GameTime gameTime)
        {
            oldkbstate = newkbstate;
            newkbstate = Keyboard.GetState();
            if (newkbstate.IsKeyDown(Keys.A) && oldkbstate.IsKeyUp(Keys.A))
            {
                readText += "A";
            }
            if (newkbstate.IsKeyDown(Keys.B) && oldkbstate.IsKeyUp(Keys.B))
            {
                readText += "B";
            }
            if (newkbstate.IsKeyDown(Keys.C) && oldkbstate.IsKeyUp(Keys.C))
            {
                readText += "C";
            }
            if (newkbstate.IsKeyDown(Keys.D) && oldkbstate.IsKeyUp(Keys.D))
            {
                readText += "D";
            }


            if (newkbstate.IsKeyDown(Keys.E) && oldkbstate.IsKeyUp(Keys.E))
            {
                readText += "E";
            }
            if (newkbstate.IsKeyDown(Keys.F) && oldkbstate.IsKeyUp(Keys.F))
            {
                readText += "F";
            }
            if (newkbstate.IsKeyDown(Keys.G) && oldkbstate.IsKeyUp(Keys.G))
            {
                readText += "G";
            }
            if (newkbstate.IsKeyDown(Keys.H) && oldkbstate.IsKeyUp(Keys.H))
            {
                readText += "H";
            }
            if (newkbstate.IsKeyDown(Keys.I) && oldkbstate.IsKeyUp(Keys.I))
            {
                readText += "I";
            }
            if (newkbstate.IsKeyDown(Keys.J) && oldkbstate.IsKeyUp(Keys.J))
            {
                readText += "J";
            }
            if (newkbstate.IsKeyDown(Keys.K) && oldkbstate.IsKeyUp(Keys.K))
            {
                readText += "K";
            }
            if (newkbstate.IsKeyDown(Keys.L) && oldkbstate.IsKeyUp(Keys.L))
            {
                readText += "L";
            }
            if (newkbstate.IsKeyDown(Keys.M) && oldkbstate.IsKeyUp(Keys.M))
            {
                readText += "M";
            }
            if (newkbstate.IsKeyDown(Keys.N) && oldkbstate.IsKeyUp(Keys.N))
            {
                readText += "N";
            }
            if (newkbstate.IsKeyDown(Keys.O) && oldkbstate.IsKeyUp(Keys.O))
            {
                readText += "O";
            }
            if (newkbstate.IsKeyDown(Keys.P) && oldkbstate.IsKeyUp(Keys.P))
            {
                readText += "P";
            }
            if (newkbstate.IsKeyDown(Keys.Q) && oldkbstate.IsKeyUp(Keys.Q))
            {
                readText += "Q";
            }
            if (newkbstate.IsKeyDown(Keys.R) && oldkbstate.IsKeyUp(Keys.R))
            {
                readText += "R";
            }
            if (newkbstate.IsKeyDown(Keys.S) && oldkbstate.IsKeyUp(Keys.S))
            {
                readText += "S";
            }
            if (newkbstate.IsKeyDown(Keys.T) && oldkbstate.IsKeyUp(Keys.T))
            {
                readText += "T";
            }
            if (newkbstate.IsKeyDown(Keys.U) && oldkbstate.IsKeyUp(Keys.U))
            {
                readText += "U";
            }
            if (newkbstate.IsKeyDown(Keys.V) && oldkbstate.IsKeyUp(Keys.V))
            {
                readText += "V";
            }
            if (newkbstate.IsKeyDown(Keys.W) && oldkbstate.IsKeyUp(Keys.W))
            {
                readText += "W";
            }
            if (newkbstate.IsKeyDown(Keys.X) && oldkbstate.IsKeyUp(Keys.X))
            {
                readText += "X";
            }
            if (newkbstate.IsKeyDown(Keys.Y) && oldkbstate.IsKeyUp(Keys.Y))
            {
                readText += "Y";
            }
            if (newkbstate.IsKeyDown(Keys.Z) && oldkbstate.IsKeyUp(Keys.Z))
            {
                readText += "Z";
            }
            if (newkbstate.IsKeyDown(Keys.Up) && oldkbstate.IsKeyUp(Keys.Up))
            {
                readText += "\\";
            }
            if (newkbstate.IsKeyDown(Keys.OemPeriod) && oldkbstate.IsKeyUp(Keys.OemPeriod))
            {
                readText += ".";
            }
            if (newkbstate.IsKeyDown(Keys.Back) && oldkbstate.IsKeyUp(Keys.Back))
            {
                if (readText.Length > 0)
                {
                    readText = readText.Remove(readText.Length - 1);
                }
            }
            if (newkbstate.IsKeyDown(Keys.OemSemicolon) && oldkbstate.IsKeyUp(Keys.OemSemicolon))
            {
                readText += ":";
            }
            base.Update(gameTime);

            if (newkbstate.IsKeyDown(Keys.NumPad1) && oldkbstate.IsKeyUp(Keys.NumPad1))
            {
                readText += "1";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad2) && oldkbstate.IsKeyUp(Keys.NumPad2))
            {
                readText += "2";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad3) && oldkbstate.IsKeyUp(Keys.NumPad3))
            {
                readText += "3";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad4) && oldkbstate.IsKeyUp(Keys.NumPad4))
            {
                readText += "4";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad5) && oldkbstate.IsKeyUp(Keys.NumPad5))
            {
                readText += "5";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad6) && oldkbstate.IsKeyUp(Keys.NumPad6))
            {
                readText += "6";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad7) && oldkbstate.IsKeyUp(Keys.NumPad7))
            {
                readText += "7";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad8) && oldkbstate.IsKeyUp(Keys.NumPad8))
            {
                readText += "8";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad9) && oldkbstate.IsKeyUp(Keys.NumPad9))
            {
                readText += "9";
            }
            if (newkbstate.IsKeyDown(Keys.NumPad0) && oldkbstate.IsKeyUp(Keys.NumPad0))
            {
                readText += "0";
            }
        }
        public String getText()
        {
            return readText;
        }
        public void reset()
        {
            readText = "C:\\";
        }
    }
}
