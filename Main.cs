using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2D_RPG
{
    public class Main : Game
    {
        private Player player;
        private Movement movement;
        private TileManager tileManager;
        private Matrix _viewMatrix;
        private Matrix _projectionMatrix;
        private Vector3 _scaleFactor;

        public Main()
        {
            Globals._graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Globals._graphics.IsFullScreen = false; // Disable fullscreen
            Globals._graphics.PreferredBackBufferWidth = 800; // Set initial window size
            Globals._graphics.PreferredBackBufferHeight = 480;

            // Allow resizing the window
            /*
            Window.AllowUserResizing = true;  // Enable resizing
            Window.ClientSizeChanged += OnWindowResized; // Event for resizing
            */
        }

        protected override void Initialize()
        {
            base.Initialize();
            // Create the initial projection and view matrix based on the window size
            //UpdateViewAndProjection();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            tileManager = new TileManager(25, 15, 32); // 25x15 grid, each tile 32x32 pixels
            TileGeneration.LoadTextures(Content);
            tileManager.LoadTerrain(22, Content); // This will be the id of the seed 

            player = new Player(new Sprite(Vector2.Zero));
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            InputManager.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);

            // Handle window resizing during the game loop
            //UpdateViewAndProjection();

            movement = new Movement(player.position, 3f);
            player.position = movement.Update(gameTime);
            player.Update();

            // Ensure the player stays within the bounds of the screen considering the scaling factor
            /*
            player.position = new Vector2(
                MathHelper.Clamp(player.position.X, 0, (800 - 32) * _scaleFactor.Y), // Adjusted clamping to the map width minus 32 for size of player
                MathHelper.Clamp(player.position.Y, 0, (480 - 64) * _scaleFactor.Z) // Adjusted clamping to the map height minus 64 for height of player
            );
            */
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin();

            tileManager.Draw(Globals.spriteBatch);
            player.Draw();

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
