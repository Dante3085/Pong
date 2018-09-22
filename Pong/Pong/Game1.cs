using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameJRPG_Ver._2.TwoDGameEngine;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Graphics.Sprites;
using MonoGameJRPG_Ver._2.TwoDGameEngine.Input;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int screenWidth;
        public static int screenHeight;

        private Paddle paddleOne;
        private Paddle paddleTwo;
        private Ball ball;
        private CollisionManager collisionManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            screenWidth = 600;
            screenHeight = 300;

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.IsFullScreen = true;

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Contents.LoadAll(Content, graphics.GraphicsDevice);

            paddleOne = new Paddle(Contents.paddle, ESide.Left, screenWidth, screenHeight,
                KeyboardInput.Default());

            paddleTwo = new Paddle(Contents.paddle, ESide.Right, screenWidth, screenHeight,
                gamePadInput: GamePadInput.Default());

            ball = new Ball(Contents.ball, 
                new Vector2(screenWidth / 2, screenHeight / 2),
                screenWidth, screenHeight);

            ball.Sprite.CollisionHandler = partner => { ball.Forward = !ball.Forward; };

            collisionManager = new CollisionManager(paddleOne.Sprite,
                paddleTwo.Sprite, ball.Sprite);
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

            InputManager.UpdateCurrentStates();
            // TODO: Add your update logic here
            paddleOne.Update(gameTime);
            paddleTwo.Update(gameTime);
            ball.Update(gameTime);
            collisionManager.Update(gameTime);

            InputManager.UpdatePreviousStates();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            paddleOne.Draw(spriteBatch);
            paddleTwo.Draw(spriteBatch);
            ball.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
