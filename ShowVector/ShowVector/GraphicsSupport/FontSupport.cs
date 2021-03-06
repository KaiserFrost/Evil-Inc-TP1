using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShowVector;

namespace BookExample
{
    /// <summary>
    /// FontSupport: for demo purposes, this is defined to be a static class
    /// </summary>
    static public class FontSupport
    {
        static private SpriteFont sTheFont = null;
        static private Color sDefaultDrawColor = Color.Black;
        static private Vector2 sStatusLocation = new Vector2(5, 5);

        /// <summary>
        /// Loads the font if not already loaded
        /// </summary>
        static private void LoadFont()
        {
            // For demo purposes, loads Arial.spritefont
            if (null == sTheFont)
                sTheFont = Game1.sContent.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// Determines if use default color (black) or user specified color
        /// </summary>
        /// <param name="c">user specified color (may be null)</param>
        /// <returns>Color to used for drawing font</returns>
        static private Color ColorToUse(Nullable<Color> c)
        {
            return (null == c) ? sDefaultDrawColor : (Color)c;
        }
        
        /// <summary>
        /// Draws font at specified location
        /// </summary>
        /// <param name="pos">location to start drawing the font</param>
        /// <param name="msg">message to draw</param>
        /// <param name="drawColor">color to draw in (if null, use black)</param>
        static public void PrintStatusAt(Vector2 pos, String msg, Nullable<Color> drawColor)
        {
            LoadFont();

            Color useColor = ColorToUse(drawColor);

            int pixelX, pixelY;
            Camera.ComputePixelPosition(pos, out pixelX, out pixelY);
            Game1.sSpriteBatch.DrawString(sTheFont, msg, new Vector2(pixelX, pixelY), useColor);
        }

        /// <summary>
        /// Draws font from upper left corner.
        /// </summary>
        /// <param name="msg">message to draw</param>
        /// <param name="drawColor">color to draw in (if null, use black)</param>
        static public void PrintStatus(String msg, Nullable<Color> drawColor)
        {
            LoadFont();
            Color useColor = ColorToUse(drawColor);

            // Compute top left corner as the reference for output status
            Game1.sSpriteBatch.DrawString(sTheFont, msg, sStatusLocation, useColor);
        }
       
    }
}
