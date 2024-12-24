using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Globals
{
    #region Values
    public static ContentManager content { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static GraphicsDeviceManager _graphics { get; set; }

    public static Dictionary<string,Tuple<Texture2D,string[]>> PlayerAnimationData;
    public static float TotalSeconds { get; set; }

    private static List<Entity> entityList = new List<Entity>{};

    #endregion Values

    #region Constructors

    public static List<Entity> EntityList 
    {
        get{return entityList;}
    }

    #endregion Constructors

    #region Functions

    public static void Update(GameTime gameTime, Game game)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public static void AddEntityToList(Entity entity)
    {
            EntityList.Add(entity);
    }

    public static void RevomeEntityFromList(Entity entity)
    {
            EntityList.Remove(entity);
    }    

    public static void LoadAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        PlayerAnimationData = new Dictionary<string,Tuple<Texture2D,string[]>>
        {
            { "Walk",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"])},
            { "Idle",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])},
            { "Run",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])}
        };
    }

    #endregion Functions
}