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

    private int[] hitboxData;
    private Rectangle hitbox;
    private static Dictionary<HostileEntityTypes,Dictionary<GlobalEnumarations.AttributeTypes, int>> HostileEntityAttributeData {get;set;}
    private static Dictionary<NonHostileEntityTypes,Dictionary<GlobalEnumarations.AttributeTypes, int>> NonHostileEntityAttributeData {get;set;}

    #endregion Values

    #region Constructors

    public EntityDataHandler()
    {
        //Load attribute dictionaries ( THESE DICTIONARIES MIGHT NEED TO BE REPLACED WITH A SWITCH CASE STRUCTURE) 
        LoadHostileEntityAttributeDictionary();
        LoadNonHostileEntityAttributeDictionary();

        //Load hitboxData int array empty.
        hitboxData = null;
        hitbox = new();
    }

    #endregion Constructors    

    #region HostileEntityFunctions

    public static void LoadHostileEntityAttributeDictionary()
    {
        HostileEntityAttributeData = new Dictionary<HostileEntityTypes,Dictionary<GlobalEnumarations.AttributeTypes, int>>
        {
            { HostileEntityTypes.Slime,GetEntityAttributeDictionary(HostileEntityTypes.Slime.ToString(),"Hostile")},
            { HostileEntityTypes.Skeleton,GetEntityAttributeDictionary(HostileEntityTypes.Skeleton.ToString(),"Hostile")},
            { HostileEntityTypes.Wolf,GetEntityAttributeDictionary(HostileEntityTypes.Wolf.ToString(),"Hostile")}
        };
    }

    private int[] GetHostileEntityAttackHitboxData(HostileEntityTypes identifier)
    {
        hitboxData = null;
        try
        {
            switch(identifier)
            {
                case(HostileEntityTypes.Slime):
                    hitboxData = [50,50,50,100];
                    break;
                
                case(HostileEntityTypes.Skeleton):
                    hitboxData = [20,20,20,20];
                    break;
                    
                default:
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            hitboxData = null;
        }
        return hitboxData; 
    }

    #endregion HostileEntityFunctions

    #region NonHostileEntityFunctions

    public static void LoadNonHostileEntityAttributeDictionary()
    {
        NonHostileEntityAttributeData = new Dictionary<NonHostileEntityTypes,Dictionary<GlobalEnumarations.AttributeTypes, int>>
        {
            { NonHostileEntityTypes.Player,GetEntityAttributeDictionary(NonHostileEntityTypes.Player.ToString(),"NonHostile")},
            { NonHostileEntityTypes.Companion,GetEntityAttributeDictionary(NonHostileEntityTypes.Companion.ToString(),"NonHostile")},
            { NonHostileEntityTypes.NPC,GetEntityAttributeDictionary(NonHostileEntityTypes.NPC.ToString(),"NonHostile")}
        };
    }

    private int[] GetNonHostileEntityAttackHitboxData(NonHostileEntityTypes identifier)
    {
        hitboxData = null;
        try
        {
            switch(identifier)
            {
                case(NonHostileEntityTypes.Player):
                    hitboxData = [50,50,50,100];
                    break;
                
                case(NonHostileEntityTypes.Companion):
                    hitboxData = [20,20,20,20];
                    break;
                    
                default:
                    hitboxData = null;
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            hitboxData = null;
        }
        return hitboxData; 
    }


    #endregion NonHostileEntityFunctions
    
    #region GeneralPurposeFunctions

    //Return a specific attirbute ( ex. HP ) of an Entity.
    //First it looks for the correct Dictionary of the entity, then inside the dictionary there is
    //another dicionary that has all the attributes. There it looks for the attribute that is asked as the parameter.
    public int GetSpecificEntityAttributeValue(string entityName, GlobalEnumarations.AttributeTypes type) 
    {
        Dictionary<GlobalEnumarations.AttributeTypes, int> tempData = null;
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

    public static Dictionary<GlobalEnumarations.AttributeTypes, int> GetEntityAttributeDictionary(string entityName,string entityType)
    {
        try
        {
            if(entityType == "Hostile")
            {
                switch(entityName)
                {
                    case "Slime":
                        return new Dictionary<GlobalEnumarations.AttributeTypes, int> ()
                        {
                            {GlobalEnumarations.AttributeTypes.HP,100},
                            {GlobalEnumarations.AttributeTypes.AttackPower,10},
                            {GlobalEnumarations.AttributeTypes.Speed,3},
                            {GlobalEnumarations.AttributeTypes.RunningSpeed,4}
                        };
                        
                    case "Skeleton":
                        return new Dictionary<GlobalEnumarations.AttributeTypes, int> ()
                        {
                            {GlobalEnumarations.AttributeTypes.HP,200},
                            {GlobalEnumarations.AttributeTypes.AttackPower,20},
                            {GlobalEnumarations.AttributeTypes.Speed,2},
                            {GlobalEnumarations.AttributeTypes.RunningSpeed,3}
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
                        return new Dictionary<GlobalEnumarations.AttributeTypes, int> ()
                        {
                            {GlobalEnumarations.AttributeTypes.HP,100},
                            {GlobalEnumarations.AttributeTypes.AttackPower,20},
                            {GlobalEnumarations.AttributeTypes.Speed,3},
                            {GlobalEnumarations.AttributeTypes.RunningSpeed,10}
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

    public bool AssignEntityAttackHitboxData(string entityName)
    {
        hitboxData = null;
        if (Enum.TryParse(entityName, true, out HostileEntityTypes hostileEntity))
        {
            //LoadMeleeWeaponDictionary();
            hitboxData = GetHostileEntityAttackHitboxData(hostileEntity);
            return true;
        }
        if (Enum.TryParse(entityName, true, out NonHostileEntityTypes nonHostileEntity))
        {
            //LoadMeleeWeaponDictionary();
            hitboxData = GetNonHostileEntityAttackHitboxData(nonHostileEntity);
            return true;
        }
            
        return false;
    }

    public Rectangle GetEntityAttackHitBox(GlobalEnumarations.Directions direction,Vector2 position, string entityName) 
    {
        hitbox = new();
        if(AssignEntityAttackHitboxData(entityName)) // pass player weapon 
        {      
            hitbox.Width = hitboxData[2];
            hitbox.Height = hitboxData[3];    
            switch(direction)
            {
                case GlobalEnumarations.Directions.Up:
                    hitbox.X = (int)position.X;
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case GlobalEnumarations.Directions.Left:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y;
                    break;

                case GlobalEnumarations.Directions.Down:
                    hitbox.X = (int)position.X;
                    hitbox.Y = (int)position.Y + hitboxData[1];
                    break;
                    
                case GlobalEnumarations.Directions.Right:
                    hitbox.X = (int)position.X + hitboxData[0];
                    hitbox.Y = (int)position.Y;
                    break;

                case GlobalEnumarations.Directions.UpLeft:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case GlobalEnumarations.Directions.UpRight:
                    hitbox.X = (int)position.X + hitboxData[0];
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case GlobalEnumarations.Directions.DownLeft:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y + hitboxData[1];
                    break;

                case GlobalEnumarations.Directions.DownRight:
                    hitbox.X = (int)position.X + hitboxData[0];
                    hitbox.Y = (int)position.Y + hitboxData[1];
                    break;
                    
                default:
                    break;
            }
            return hitbox;
        }
        return hitbox;
    }
    
    #endregion GeneralPurposeFunctions
}