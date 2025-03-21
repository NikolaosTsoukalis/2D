using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class AnimationDataHandler
{
    public enum AnimationIdentifier 
    {
        Idle,
        Walk,
        Run,
        MeleeAttack,
        RangedAttack,
        Interact
    }

    private Tuple<Texture2D,string[]> data;

    public AnimationDataHandler()
    {
        data = new Tuple<Texture2D, string[]>(null,null);
    }

    private Tuple<Texture2D,string[]> GetPlayerAnimationData(AnimationIdentifier identifier)
    {
        try
        {
            switch(identifier)
            {
                case(AnimationIdentifier.Idle):  
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Walk):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Walk_strip32"),["80","0.1"]);
                    break;
                    
                case(AnimationIdentifier.Run):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Interact):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"]);
                    break;
                
                default:
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            data = new Tuple<Texture2D, string[]>(null,null);
        }
        return data; 
    }

    private Tuple<Texture2D,string[]> GetSlimeAnimationData(AnimationIdentifier identifier)
    {
        try
        {
            switch(identifier)
            {
                case(AnimationIdentifier.Idle):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Walk):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Run):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Interact):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"]);
                    break;
                
                default:
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            data = new Tuple<Texture2D, string[]>(null,null);
        }
        return data; 
    }

    /* OLDER DICTIONARY SOLUTION(TEMPORARY/MUST REMOVE)

    private static Dictionary<AnimationIdentifier,Tuple<Texture2D,string[]>> PlayerAnimationData;
    private static Dictionary<AnimationIdentifier,Tuple<Texture2D,string[]>> SlimeAnimationData;
    

    public static void LoadPlayerAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        PlayerAnimationData = new Dictionary<AnimationIdentifier,Tuple<Texture2D,string[]>>
        {
            { AnimationIdentifier.Walk,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"])},
            { AnimationIdentifier.Idle,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])},
            { AnimationIdentifier.Run,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])},
            { AnimationIdentifier.Interact,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])}
        };
    }

    public static void UnloadPlayerAnimationDictionary()
    {
        PlayerAnimationData = new();
    }

    public static void LoadSlimeAnimationDictionary()
    {
        //Format : {Texture2D},string[{"totalFrames","timeOfEachFrame"}]
        SlimeAnimationData = new Dictionary<AnimationIdentifier,Tuple<Texture2D,string[]>>
        {
            { AnimationIdentifier.Walk,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.1"])},
            { AnimationIdentifier.Idle,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"])},
            { AnimationIdentifier.Run,new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Slime_Walk_strip48"),["48","0.3"])}
        };
    }

    public static void UnloadSlimeAnimationDictionary()
    {
        SlimeAnimationData = new();
    }

    */
    public Tuple<Texture2D, string[]> GetAnimationData(string entityName, AnimationIdentifier identifier)
    {
        
        if (Enum.TryParse(entityName, true, out EntityDataHandler.NonHostileEntityTypes nonHostileEntityType))
        {
            switch (nonHostileEntityType)
            {
                case EntityDataHandler.NonHostileEntityTypes.Player:
                    return GetPlayerAnimationData(identifier);
            }
        }
        else if (Enum.TryParse(entityName, true, out EntityDataHandler.HostileEntityTypes hostileEnemyType))
        {
            switch (hostileEnemyType)
            {
                case EntityDataHandler.HostileEntityTypes.Slime:
                    return GetSlimeAnimationData(identifier);
            }
        }
        return null;
    }

}