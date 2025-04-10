using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class AnimationDataHandler
{
    #region Enums

    public enum AnimationIdentifier 
    {
        Idle,
        Walk,
        Run,
        MeleeAttack,
        RangedAttack,
        Interact
    }

    #endregion Enums

    #region Fields

    private Tuple<Texture2D,string[]> data;

    #endregion Fields

    #region Constructors

    public AnimationDataHandler()
    {
        data = null;
    }

    #endregion Constructors

    #region General Functions

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
        try
        {                
            if (Enum.TryParse(entityName, true, out EntityDataHandler.NonHostileEntityTypes nonHostileEntityType))
            {
                switch (nonHostileEntityType)
                {
                    case EntityDataHandler.NonHostileEntityTypes.Player:
                        if(AssignPlayerAnimationData(identifier))
                        {
                            return data;
                        }
                        break;
                }
            }
            if (Enum.TryParse(entityName, true, out EntityDataHandler.HostileEntityTypes hostileEnemyType))
            {
                switch (hostileEnemyType)
                {
                    case EntityDataHandler.HostileEntityTypes.Slime:
                        if(AssignSlimeAnimationData(identifier))
                        {
                            return data;
                        }
                        break;
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return null;
        }

        Console.WriteLine("Entity Name : " + entityName + " or Animation Identifier: " + identifier + " is invalid.");
        return null;
    }

    #endregion General Functions

    #region Assign Data Functions
    
    private bool AssignPlayerAnimationData(AnimationIdentifier identifier)
    {
        data = null;
        try
        {
            switch(identifier)
            {
                case(AnimationIdentifier.Idle):  
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Entity/Character_Idle_strip80"),["80","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Walk):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Entity/Character_Walk_strip80"),["80","0.1"]);
                    break;
                    
                case(AnimationIdentifier.Run):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"]);
                    break;
                    
                case(AnimationIdentifier.Interact):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Entity/Character_Walk_strip80"),["80","0.1"]);
                    break;

                case(AnimationIdentifier.MeleeAttack):
                    data = new Tuple<Texture2D,string[]>(Globals.ContentManager.Load<Texture2D>("Entity/Character_MeleeAttack_strip56"),["56","0.1"]);
                    break;
                
                default:
                    break;
            }
            if(data != null)
            {
                return true;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
        return false; 
    }

    private bool AssignSlimeAnimationData(AnimationIdentifier identifier)
    {
        data = null;
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
            if(data != null)
                return true;
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
        return false; 
    }
    #endregion Assign Data Functions
}