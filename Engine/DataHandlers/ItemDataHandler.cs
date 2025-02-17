
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class ItemDataHandler
{
    #region Enums
    public enum Potions{}

    public enum Food
    {
        Mutton,
        Strawberry
    }

    public enum Materials{}

    public enum EquipableItemTypes
    {
        Helmet,
        Chestpiece,
        Legguard,
        Boots
    }

    public enum SpecialItems{}

    #endregion Enums
    

    #region MeleeWeaponData

    public enum WeaponTypes
    {
        Melee,
        Ranged,
        Magic
    }

    public enum MeleeWeapons
    {
        ShortSword,
        Fist
    }

    public enum RangedWeapons{}

    public enum MagicWeapons{}

    private static Dictionary<string,int[]> meleeWeaponAttributeData;
    public static Dictionary<string,int[]> MeleeWeaponAttributeData
    {
        get{return meleeWeaponAttributeData;}
    }

    private static Dictionary<string,int[]> meleeWeaponHitboxData;
    public static Dictionary<string,int[]> MeleeWeaponHitboxData
    {
        get{return meleeWeaponHitboxData;}
        
    }

    private static Dictionary<string,int[]> meleeWeaponInventoryData;
    public static Dictionary<string,int[]> MeleeWeaponInventoryData
    {
        get{return meleeWeaponInventoryData;}
    }

    #endregion MeleeWeaponData

    #region MeleeWeaponFunctions

    public static void LoadMeleeWeaponAttributeDataDictionary() // {damage, x, y, z}
    {
        meleeWeaponAttributeData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[10] },
            { MeleeWeapons.Fist.ToString(),[2] }
        };
    }

    public static void LoadMeleeWeaponHitboxDataDictionary() // x,y,width,height
    {
        meleeWeaponHitboxData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[50,50,50,100] },
            { MeleeWeapons.Fist.ToString(),[20,20,20,40] }
        };
    }

    public static void LoadMeleeWeaponInventoryDataDictionary() // x,y,width,height
    {
        meleeWeaponInventoryData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[] }
        };
    }
    
    #endregion MeleeWeaponFunctions

    #region ChestpieceData

    public enum ChestpieceTypes
    {
        LeatherTunic,
        IronChestPlate
    }

    private static Dictionary<string,int[]> chestpieceAttributeData;
    public static Dictionary<string,int[]> ChestpieceAttributeData
    {
        get{return chestpieceAttributeData;}
    }

    private static Dictionary<string,int[]> chestpieceInventoryData;
    public static Dictionary<string,int[]> ChestpieceInventoryData
    {
        get{return chestpieceInventoryData;} 
    }

    #endregion ChestpieceData

    #region ChestpieceFunctions

    public static void LoadChestpieceDictionary() // {defence, x, y, z}
    {
        chestpieceAttributeData = new Dictionary<string, int[]> 
        {
            { ChestpieceTypes.LeatherTunic.ToString(),[50] }
        };
    }

    #endregion ChestpieceFunctions

    private static Dictionary<string,string[]> foodData;
    public static Dictionary<string,string[]> FoodData
    {
        get{return foodData;}
        
    }

    public ItemDataHandler()
    {
        //Weapons
        LoadMeleeWeaponAttributeDataDictionary();
        LoadMeleeWeaponHitboxDataDictionary();

        //Armor
        LoadChestpieceDictionary();

        //Consumables
        LoadFoodDictionary();
    }

    #region GeneralFunctions

    public static void LoadFoodDictionary()
    {
        foodData = new Dictionary<string, string[]> {};
    }    

    public int[] GetEquippableItemAttributeData(string itemName)
    {
        int[] tempData = null;

        if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
        {
            //LoadMeleeWeaponDictionary();
            tempData = MeleeWeaponAttributeData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
        else if (Enum.TryParse(itemName, true, out ChestpieceTypes chestpieceTypes))
        {
            //LoadMeleeWeaponDictionary();
            tempData = ChestpieceAttributeData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
            
        return tempData;
    }

    public Rectangle getHitBox(Globals.Directions direction,Vector2 position, string itemName) 
    {
        int[] variables = ItemDataHandler.getItemHitboxData(itemName); // pass player weapon 
        
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

    public static int[] getItemHitboxData(string itemName)
    {
        try
        {
            if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
            {
                //LoadMeleeWeaponDictionary();
                return MeleeWeaponHitboxData.FirstOrDefault( item => item.Key == itemName ).Value;
            }
            return null;
        }
        catch(Exception e)
        {
            Microsoft.Xna.Framework.Input.MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
            return null;
        }
    }

    #endregion GeneralFunctions
}