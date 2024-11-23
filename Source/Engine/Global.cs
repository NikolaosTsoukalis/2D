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

    //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
    public static readonly Dictionary<string,Tuple<Texture2D,string[]>> AnimationData 
    = new Dictionary<string,Tuple<Texture2D,string[]>>()
    {
        { "Player",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.1"])},
        { "Player1",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])}
    };
    
}