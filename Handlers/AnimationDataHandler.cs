using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class AnimationDataHandler
{
    public enum AnimationTypes 
    {
        Idle,
        Walk,
        Run,
        Attack
    }

    private static Dictionary<AnimationTypes,Tuple<Texture2D,string[]>> playerAnimationData;

    public static Dictionary<AnimationTypes,Tuple<Texture2D,string[]>> PlayerAnimationData
    {
        get{return playerAnimationData;}
        set{playerAnimationData = value;}
    }

    private static Dictionary<AnimationTypes,Tuple<Texture2D,string[]>> slimeAnimationData;

    public static Dictionary<AnimationTypes,Tuple<Texture2D,string[]>> SlimeAnimationData
    {
        get{return slimeAnimationData;}
        set{slimeAnimationData = value;}
    }

    public AnimationDataHandler(GameTime gameTime, Game game){}


    public static void LoadPlayerAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        PlayerAnimationData = new Dictionary<AnimationTypes,Tuple<Texture2D,string[]>>
        {
            { AnimationTypes.Walk,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"])},
            { AnimationTypes.Idle,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])},
            { AnimationTypes.Run,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])}
        };
    }

    public static void UnloadPlayerAnimationDictionary()
    {
        PlayerAnimationData = new();
    }

    public static void LoadSlimeAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        SlimeAnimationData = new Dictionary<AnimationTypes,Tuple<Texture2D,string[]>>
        {
            { AnimationTypes.Walk,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Slime_Walk_strip48"),["48","0.1"])},
            { AnimationTypes.Idle,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"])},
            { AnimationTypes.Run,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"])}
        };
    }

    public static void UnloadSlimeAnimationDictionary()
    {
        SlimeAnimationData = new();
    }
}