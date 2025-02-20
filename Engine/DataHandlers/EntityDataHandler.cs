using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace _2D_RPG;
public class EntityDataHandler
{
    public enum GeneralEntityTypes
    {
        Player,
        Enemy,
        NPC,
        Item,
        Environment
    }

    public enum HostileEntityTypes
    {
        Slime,
        Skeleton,
        Wolf
    }

    private static Dictionary<HostileEntityTypes,int[]> hostileEntityData;

    public static Dictionary<HostileEntityTypes,int[]> HostileEntityData
    {
        get{return hostileEntityData;}
        set{hostileEntityData = value;}
    }

    private static Dictionary<HostileEntityTypes,int[]> hostileEntityHitboxData;

    public static Dictionary<HostileEntityTypes,int[]> HostileEntityHitboxData
    {
        get{return hostileEntityHitboxData;}
        set{hostileEntityHitboxData = value;}
    }

    public EntityDataHandler(GameTime gameTime, Game game){}

    public static void LoadHostileEntityAttributeDictionary()
    {
        //{HostileEnemyType},string[{"HP","DMG","SPEED","RUNNINGSPEED","ATTACKPOWER"}]
        HostileEntityData = new Dictionary<HostileEntityTypes,int[]>
        {
            { HostileEntityTypes.Slime,[100,1,3,4,10]},
            { HostileEntityTypes.Skeleton,[32,32]},
            { HostileEntityTypes.Wolf,[32,32]}
        };
    }

    public static void LoadEntityHitboxDataDictionary() // x,y,width,height
    {
        HostileEntityHitboxData = new Dictionary<HostileEntityTypes, int[]> 
        {
            { HostileEntityTypes.Slime,[50,50,50,100] },
            { HostileEntityTypes.Skeleton,[20,20,20,40] }
        };
    }

    public int[] GetHostileEntityAttributeData(string entityName)
    {
        int[] tempData = null;

        if (Enum.TryParse(entityName, true, out HostileEntityTypes entity))
        {
            //LoadMeleeWeaponDictionary();
            tempData = HostileEntityData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
        }
            
        return tempData;
    }

    public int[] GetHostileEntityAttackHitboxData(string entityName)
    {
        int[] tempData = null;

        if (Enum.TryParse(entityName, true, out HostileEntityTypes entity))
        {
            //LoadMeleeWeaponDictionary();
            tempData = HostileEntityHitboxData.FirstOrDefault(entity => entity.Key.ToString() == entityName ).Value;
        }
            
        return tempData;
    }

    public Rectangle getHostileEntityAttackHitBox(Globals.Directions direction,Vector2 position, string itemName) 
    {
        int[] variables = GetHostileEntityAttackHitboxData(itemName); // pass player weapon 
        
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
}