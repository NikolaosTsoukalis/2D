using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Globals
{
    public static ContentManager content { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static GraphicsDeviceManager _graphics { get; set; }

    public static Dictionary<string,Tuple<Texture2D,string[]>> AnimationData;
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

    public static void LoadAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        AnimationData = new Dictionary<string,Tuple<Texture2D,string[]>>
        {
            { "Player",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])},
            { "Player1",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3","x","y"])}
        };
    }
}