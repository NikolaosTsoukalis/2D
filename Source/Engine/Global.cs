using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Globals
{
    internal static ContentManager content { get; set; }
    internal static SpriteBatch spriteBatch { get; set; }
    internal static GraphicsDeviceManager _graphics { get; set; }
    public static float TotalSeconds { get; set; }

    internal static List<Entity> EntityList = new List<Entity>{};

    public static List<Entity> entityList 
    {
        get{return EntityList;}
    }

    public static void Update(GameTime gameTime)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public static void UpdateEntityList(bool choice,Entity entity)
    {
        if(choice)
        {
            EntityList.Add(entity);
        }
        else
            EntityList.Remove(entity);
    }   

/*
    //Format : Tuple<{animationName},{maxFrames}>,{time per Frame}
    public static readonly Dictionary<Tuple<string,Texture2D>,Tuple<int,float>> NewDictionary 
    = new Dictionary<Tuple<string,Texture2D>, Tuple<int,float>>()
        {
            { new Tuple<string, Texture2D>("Player",content.Load<Texture2D>("testSpriteWalk_strip32")), new Tuple<int, float>(32,0.1f) }
        };

*/
    public static readonly Dictionary<Tuple<string,Texture2D>,int> NewDictionary 
    = new Dictionary<Tuple<string,Texture2D>, int>()
    {
        { new Tuple<string, Texture2D>("Player",content.Load<Texture2D>("testSpriteWalk_strip32")), 32}
    };
    
}