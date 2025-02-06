using System.Collections.Generic;
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

    private static Dictionary<HostileEntityTypes,string[]> hostileEntityData;

    public static Dictionary<HostileEntityTypes,string[]> HostileEntityData
    {
        get{return hostileEntityData;}
        set{hostileEntityData = value;}
    }

    public EntityDataHandler(GameTime gameTime, Game game){}

/*
    public static void LoadPlayerVariables()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        EntityData = new Dictionary<GeneralEntityTypes,string[]>
        {
            { GeneralEntityTypes.Player,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"])},
            { GeneralEntityTypes.Slime,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])},
            { GeneralEntityTypes.Run,new Tuple<Texture2D,string[]>(Globals.content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])}
        };
    }
*/
    public static void LoadHostileEntityDictionary()
    {
        //Format : {HostileEnemyType},string[{"HP","DMG","ATTSPD","DEFENCE","MOVSPEED"}]
        HostileEntityData = new Dictionary<HostileEntityTypes,string[]>
        {
            { HostileEntityTypes.Slime,["1","1","1","1"]},
            { HostileEntityTypes.Skeleton,["32","0.3"]},
            { HostileEntityTypes.Wolf,["32","0.3"]}
        };
    }
    
}