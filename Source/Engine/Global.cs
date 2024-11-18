using System;
using System.Collections.Generic;
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


    //Format : Tuple<{animationName},{maxFrames}>,{time per Frame}
    public static readonly Dictionary<Tuple<string,int>,float> NewDictionary = new Dictionary<Tuple<string,int>, float>()
        {
            { new Tuple<string, int>("Player",32), 0.1f },
            { "Reference2", Array2 },
            { "Reference3", Array3 },
            { "Reference4", Array4 },
            { "Reference5", Array5 }
        };
}