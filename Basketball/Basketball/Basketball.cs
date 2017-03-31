using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Window_Size_Project.GraphicsSupport;


namespace Basketball
{
    public class BasketBall : TexturedPrimitive
    {
        private const float kIncreaseRate = 1.001f; // Change current position by this amount
        private Vector2 kInitSize = new Vector2(5, 5);
        private const float kFinalSize = 15f;

        /// <summary>
        /// Constructor of BasketBall
        /// </summary>
        public BasketBall() : base("BasketBall")
        {
            mPosition = Camera.RandomPosition();
            mSize = kInitSize;
        }

        /// <summary>
        /// Continuously increase in size until it gets too large, returns true if exploded
        /// </summary>
        public bool UpdateAndExplode()
        {
            mSize *= kIncreaseRate;
            return mSize.X > kFinalSize;
        }
    }
}

