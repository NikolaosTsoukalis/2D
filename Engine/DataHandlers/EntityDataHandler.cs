using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace _2D_RPG;
public class EntityDataHandler
{ 
    #region Enums

    public enum NonHostileEntityTypes
    {
        Player,
        NPC,
        Companion
    }

    public enum HostileEntityTypes
    {
        Slime,
        Skeleton,
        Wolf
    }

    #endregion Enums

    #region Values

    private static Dictionary<HostileEntityTypes,Dictionary<Globals.AttributeTypes, int>> HostileEntityAttributeData {get;set;}
    private static Dictionary<HostileEntityTypes,int[]> HostileEntityHitboxData {get;set;}

    
    private static Dictionary<NonHostileEntityTypes,Dictionary<Globals.AttributeTypes, int>> NonHostileEntityAttributeData {get;set;}
    private static Dictionary<NonHostileEntityTypes,int[]> NonHostileEntityHitboxData {get;set;}

    #endregion Values

    #region Constructors

    public EntityDataHandler()
    {
        //Load attribute dictionaries
        LoadHostileEntityAttributeDictionary();
        LoadNonHostileEntityAttributeDictionary();

        //Load hitbox dicitonaries
        LoadHostileEntityHitboxDataDictionary();
        LoadNonHostileEntityHitboxDataDictionary();
    }

    #endregion Constructors    

    #region HostileEntityFunctions

    public static void LoadHostileEntityAttributeDictionary()
    {
        HostileEntityAttributeData = new Dictionary<HostileEntityTypes,Dictionary<Globals.AttributeTypes, int>>
        {
            { HostileEntityTypes.Slime,GetEntityAttributeDictionary(HostileEntityTypes.Slime.ToString(),"Hostile")},
            { HostileEntityTypes.Skeleton,GetEntityAttributeDictionary(HostileEntityTypes.Skeleton.ToString(),"Hostile")},
            { HostileEntityTypes.Wolf,GetEntityAttributeDictionary(HostileEntityTypes.Wolf.ToString(),"Hostile")}
        };
    }

    public static void LoadHostileEntityHitboxDataDictionary() // x,y,width,height
    {
        HostileEntityHitboxData = new Dictionary<HostileEntityTypes, int[]> 
        {
            { HostileEntityTypes.Slime,[50,50,50,100] },
            { HostileEntityTypes.Skeleton,[20,20,20,40] }
        };
    }

    #endregion HostileEntityFunctions

    #region NonHostileEntityFunctions

    public static void LoadNonHostileEntityAttributeDictionary()
    {
        NonHostileEntityAttributeData = new Dictionary<NonHostileEntityTypes,Dictionary<Globals.AttributeTypes, int>>
        {
            { NonHostileEntityTypes.Player,GetEntityAttributeDictionary(NonHostileEntityTypes.Player.ToString(),"NonHostile")},
            { NonHostileEntityTypes.Companion,GetEntityAttributeDictionary(NonHostileEntityTypes.Companion.ToString(),"NonHostile")},
            { NonHostileEntityTypes.NPC,GetEntityAttributeDictionary(NonHostileEntityTypes.NPC.ToString(),"NonHostile")}
        };
    }

    public static void LoadNonHostileEntityHitboxDataDictionary() // x,y,width,height
    {
        NonHostileEntityHitboxData = new Dictionary<NonHostileEntityTypes, int[]> 
        {
            { NonHostileEntityTypes.Player,[20,20,20,40] },
            { NonHostileEntityTypes.Companion,[20,20,20,40] },
            { NonHostileEntityTypes.NPC,[20,20,20,40] }
        };
    }

    #endregion NonHostileEntityFunctions
    
    #region GeneralPurposeFunctions

    //Return a specific attirbute ( ex. HP ) of an Entity.
    //First it looks for the correct Dictionary of the entity, then inside the dictionary there is
    //another dicionary that has all the attirbutes. There it looks for the attribute that is asked as the parameter.
    public int GetSpecificEntityAttributeValue(string entityName, Globals.AttributeTypes type) 
    {
        Dictionary<Globals.AttributeTypes, int> tempData = null;
        int attribute = 0;

        if (Enum.TryParse(entityName, true, out HostileEntityTypes hostileEntity))
        {
            tempData = HostileEntityAttributeData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
            attribute = tempData.FirstOrDefault(attribute => attribute.Key.ToString() == type.ToString() ).Value;
        }
        if (Enum.TryParse(entityName, true, out NonHostileEntityTypes nonHostileEntity))
        {
            tempData = NonHostileEntityAttributeData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
            attribute = tempData.FirstOrDefault(attribute => attribute.Key.ToString() == type.ToString() ).Value;
        }
        
        return attribute;
    }

    public static Dictionary<Globals.AttributeTypes, int> GetEntityAttributeDictionary(string entityName,string entityType)
    {
        try
        {
            if(entityType == "Hostile")
            {
                switch(entityName)
                {
                    case "Slime":
                        return new Dictionary<Globals.AttributeTypes, int> ()
                        {
                            {Globals.AttributeTypes.HP,100},
                            {Globals.AttributeTypes.AttackPower,10},
                            {Globals.AttributeTypes.Speed,3},
                            {Globals.AttributeTypes.RunningSpeed,4}
                        };
                        
                    case "Skeleton":
                        return new Dictionary<Globals.AttributeTypes, int> ()
                        {
                            {Globals.AttributeTypes.HP,200},
                            {Globals.AttributeTypes.AttackPower,20},
                            {Globals.AttributeTypes.Speed,2},
                            {Globals.AttributeTypes.RunningSpeed,3}
                        };
                    default:
                        return null;
                }
            }
            else if(entityType == "NonHostile")
            {
                switch(entityName)
                {
                    case "Player":
                        return new Dictionary<Globals.AttributeTypes, int> ()
                        {
                            {Globals.AttributeTypes.HP,100},
                            {Globals.AttributeTypes.AttackPower,20},
                            {Globals.AttributeTypes.Speed,3},
                            {Globals.AttributeTypes.RunningSpeed,4}
                        };
                    default:
                        return null;
                }
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Console.Write("THERE IS NO ENTITY WITH THE NAME : " + entityName);
            return null;
        }
    }

    public int[] GetEntityAttackHitboxData(string entityName)
    {
        int[] tempData = null;

        if (Enum.TryParse(entityName, true, out HostileEntityTypes hostileEntity))
        {
            //LoadMeleeWeaponDictionary();
            tempData = HostileEntityHitboxData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
        }
        if (Enum.TryParse(entityName, true, out NonHostileEntityTypes nonHostileEntity))
        {
            //LoadMeleeWeaponDictionary();
            tempData = NonHostileEntityHitboxData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
        }
            
        return tempData;
    }

    public Rectangle getEntityAttackHitBox(Globals.Directions direction,Vector2 position, string entityName) 
    {
        int[] variables = GetEntityAttackHitboxData(entityName); // pass player weapon 
        
        switch(direction)
        {
            case Globals.Directions.Up:
                return new Rectangle((int)(position.X),(int)(position.Y - variables[1]),variables[2],variables[3]);

            case Globals.Directions.Left:
                return new Rectangle((int)(position.X - variables[0]),(int)(position.Y),variables[2],variables[3]);

            case Globals.Directions.Down:
                return new Rectangle((int)(position.X),(int)(position.Y + variables[1]),variables[2],variables[3]);
                
            case Globals.Directions.Right:
                return new Rectangle((int)(position.X + variables[0]),(int)(position.Y),variables[2],variables[3]);  

            case Globals.Directions.UpLeft:
                return new Rectangle((int)(position.X - variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);

            case Globals.Directions.UpRight:
                return new Rectangle((int)(position.X + variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);

            case Globals.Directions.DownLeft:
                return new Rectangle((int)(position.X - variables[0] ),(int)(position.Y + variables[1]),variables[2],variables[3]);

            case Globals.Directions.DownRight:
                return new Rectangle((int)(position.X + variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);
                
            default:
                return new();
        }
    }
    
    #endregion GeneralPurposeFunctions
}