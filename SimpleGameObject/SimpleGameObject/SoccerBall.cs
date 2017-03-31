using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Window_Size_Project.GraphicsSupport;

namespace SimpleGameObject.GraphicsSupport
{
    public class SoccerBall : TexturedPrimitive
    {
        private Vector2 mDeltaPosition; // Change current position by this amount
                                        /// <summary>
                                        /// Constructor of SoccerBall
                                        /// </summary>
                                        /// <param name="position">center position of the ball</param>
                                        /// <param name="diameter">diameter of the ball</param>
        public SoccerBall(Vector2 position, float diameter) :
        base("Soccer", position, new Vector2(diameter, diameter))
        {
            mDeltaPosition.X = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
            mDeltaPosition.Y = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
        }
        // Accessors
        public float Radius
        {
            get { return mSize.X * 0.5f; }
            set { mSize.X = 2f * value; mSize.Y = mSize.X; }
        }
        /// <summary>
        /// Compute the soccer ball's movement in the camera window
        /// </summary>
        public void Update()
        {
            Camera.CameraWindowCollisionStatus status =
            Camera.CollidedWithCameraWindow(this);
            switch (status)
            {
                case Camera.CameraWindowCollisionStatus.CollideBottom:
                case Camera.CameraWindowCollisionStatus.CollideTop:
                    mDeltaPosition.Y *= -1;
                    break;
                    
            case Camera.CameraWindowCollisionStatus.CollideLeft:
                case Camera.CameraWindowCollisionStatus.CollideRight:
                    mDeltaPosition.X *= -1;
                    break;
            }
            mPosition += mDeltaPosition;
        }
    }
}