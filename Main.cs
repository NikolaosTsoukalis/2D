using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spritebach;
    private Sprite sprite;
    private Movement movement;
    Texture2D texture;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Global.content = this.Content;
        Global.spriteBatch = new SpriteBatch(GraphicsDevice);

        texture = Content.Load<Texture2D>("testSprite1");
        sprite = new Sprite(texture, Vector2.Zero);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        var state = Keyboard.GetState(); 
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
            Exit();

        movement = new Movement(sprite.position, 3f);

        sprite.position = movement.Update(gameTime);
        


        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        Global.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Global.spriteBatch.Draw(sprite.texture,sprite.position, Color.White);


        Global.spriteBatch.End();

        base.Draw(gameTime);
    }
}
