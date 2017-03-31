using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BookExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameState
    {

        ChaserGameObject mChaser;

        // Simple game status
        int mChaserHit, mChaserMissed;

        Vector2 kInitRocketPosition = new Vector2(10, 10);
        // Rocket support
        GameObject mRocket;

        GameObject mArrow;


        /// <summary>
        /// Constructor
        /// </summary>
        public GameState()
        {
            mChaser = new ChaserGameObject("Chaser", Vector2.Zero, new Vector2(6f, 1.7f), null);
            mChaser.InitialFrontDirection = -Vector2.UnitX; // inicialmente na dire��o x negativo
            mChaser.Speed = 0.2f;

            // Inicializa o status do jogo
            mChaserHit = 0;
            mChaserMissed = 0;

            mRocket = new GameObject("Rocket", kInitRocketPosition, new Vector2(3, 10));

            mArrow = new GameObject("Arrow", new Vector2(50, 30), new Vector2(10, 4));
            mArrow.InitialFrontDirection = Vector2.UnitX; // initially pointing in the x direction

           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public void UpdateGame()
        {

            #region Control and fly the rocket
            mRocket.RotateAngleInRadian += MathHelper.ToRadians(InputWrapper.ThumbSticks.Right.X);
            mRocket.Speed += InputWrapper.ThumbSticks.Left.Y * 0.1f;

            mRocket.VelocityDirection = mRocket.FrontDirection;

            if (Camera.CollidedWithCameraWindow(mRocket) != Camera.CameraWindowCollisionStatus.InsideWindow)
            {
                mRocket.Speed = 0f;
                mRocket.Position = kInitRocketPosition;
            }

            mRocket.Update();
            #endregion

            #region Set the arrow to point towards the rocket
            Vector2 toRocket = mRocket.Position - mArrow.Position;
            mArrow.FrontDirection = toRocket;
            #endregion

            #region Step 3. Check/launch the chaser!
            if (mChaser.HasValidTarget)
            {
                mChaser.ChaseTarget();

                if (mChaser.HitTarget)
                {
                    mChaserHit++;
                    mChaser.Target = null;
                }

                if (Camera.CollidedWithCameraWindow(mChaser) !=
                            Camera.CameraWindowCollisionStatus.InsideWindow)
                {
                    mChaserMissed++;
                    mChaser.Target = null;
                }
            }

            if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                mChaser.Target = mRocket;
                mChaser.Position = mArrow.Position;
            }
            #endregion
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public void DrawGame()
        {
            mRocket.Draw();
            mArrow.Draw();
            if (mChaser.HasValidTarget)
                mChaser.Draw();

            // Print out text messsage to echo status
            FontSupport.PrintStatus("Chaser Hit=" + mChaserHit + "   Missed=" + mChaserMissed, null);
        }
    }
}
