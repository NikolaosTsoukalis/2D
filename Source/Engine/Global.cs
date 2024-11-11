using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Globals
{
    internal static ContentManager content { get; set; }
    internal static SpriteBatch spriteBatch { get; set; }
    internal static GraphicsDeviceManager _graphics { get; set; }
    public static float TotalSeconds { get; set; }

    public static void Update(GameTime gameTime)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}