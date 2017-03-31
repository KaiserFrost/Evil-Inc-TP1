using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DrawandControl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager mGraphics;
        SpriteBatch mSpriteBatch;

        Texture2D mJPGImage;
        Vector2 mJPGPosition;

        Texture2D mPNGImage;
        Vector2 mPNGPosition;

        public Game1()
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Initialize the initial image positions.
            mJPGPosition = new Vector2(10f, 10f);
            mPNGPosition = new Vector2(100f, 100f);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mSpriteBatch = new SpriteBatch(GraphicsDevice);
            // Load the images.
            mJPGImage = Content.Load<Texture2D>("UWB-JPG");
            mPNGImage = Content.Load<Texture2D>("UWB-PNG");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            #region Keyboard
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            // Update the image positions with Arrow keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                mJPGPosition.X-=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                mJPGPosition.X+=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                mJPGPosition.Y-=5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                mJPGPosition.Y+=5;
            // Update the image positions with AWSD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                mPNGPosition.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                mPNGPosition.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                mPNGPosition.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                mPNGPosition.Y++;
            #endregion
            #region Mouse
            // Poll mouse state
            MouseState mMouseState = Mouse.GetState();
            // If left mouse button is pressed
            if (mMouseState.LeftButton == ButtonState.Pressed)
                mJPGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            // If right mouse button is pressed
            if (mMouseState.RightButton == ButtonState.Pressed)
                mPNGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            mSpriteBatch.Begin(); // Initialize drawing support
                                  // Draw the JPGImage
            mSpriteBatch.Draw(mJPGImage, mJPGPosition, Color.White);
            // Draw the PNGImage
            mSpriteBatch.Draw(mPNGImage, mPNGPosition, Color.White);
            mSpriteBatch.End(); // Inform graphics system we are done drawing
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
