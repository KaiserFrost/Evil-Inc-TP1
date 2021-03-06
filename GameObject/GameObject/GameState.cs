using Microsoft.Xna.Framework;

namespace BookExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameState
    {
        Vector2 kInitRocketPosition = new Vector2(10, 10);
        // Rocket support
        GameObject mRocket;
        // The arrow
        GameObject mArrow;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameState()
        {
            mRocket = new GameObject("Rocket", kInitRocketPosition, new Vector2(3, 10));

            mArrow = new GameObject("Arrow", new Vector2(50, 30), new Vector2(10, 4));
            mArrow.InitialFrontDirection = Vector2.UnitX; // Inicialmente aponta para a posi��o x
        }

        /// <summary>
        /// Update the game state
        /// </summary>
        public void UpdateGame()
        {
            #region Step 3a. Controla e mexe o foguete
            mRocket.RotateAngleInRadian +=
                MathHelper.ToRadians(InputWrapper.ThumbSticks.Right.X);

            mRocket.Speed += InputWrapper.ThumbSticks.Left.Y * 0.1f;

            mRocket.VelocityDirection = mRocket.FrontDirection;

            if (Camera.CollidedWithCameraWindow(mRocket) !=
                        Camera.CameraWindowCollisionStatus.InsideWindow)
            {
                mRocket.Speed = 0f;
                mRocket.Position = kInitRocketPosition;
            }

            mRocket.Update();
            #endregion

            #region Step 3b. Set the arrow to point towards the rocket
            Vector2 toRocket = mRocket.Position - mArrow.Position;
            mArrow.FrontDirection = toRocket;
            #endregion
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public void DrawGame()
        {
            mRocket.Draw();
            mArrow.Draw();

            FontSupport.PrintStatus("Rocket Speed(LeftThumb-Y)=" + mRocket.Speed + 
                "  VelocityDirection(RightThumb-X):" + mRocket.VelocityDirection, null);

            FontSupport.PrintStatusAt(mRocket.Position, mRocket.Position.ToString(), Color.White);
        }
    }
}
