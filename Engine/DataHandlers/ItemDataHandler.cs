
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class ItemDataHandler
{
    #region General Enums
    public enum Potions{}

    public enum Food
    {
        Mutton,
        Strawberry
    }

    public enum Materials{}

    public enum ArmorTypes
    {
        Helmet,
        Chestpiece,
        Legguard,
        Boots
    }

    public enum SpecialItems{}

    public enum RangedWeapons{}

    public enum MagicWeapons{}

    #endregion General Enums
    
    #region Fields

    private int[] data;

    #endregion Fields

    #region MeleeWeaponData

    public enum MeleeWeaponTypes
    {
        ShortSword,
        Fist
    }

    #endregion MeleeWeaponData

    #region MeleeWeaponFunctions

    public int[] GetMeleeWeaponAttributeData(MeleeWeaponTypes identifier)  // {damage, x, y, z}
    {
        try
        {
            switch(identifier)
            {
                case MeleeWeaponTypes.Fist:
                    data = [2];
                    break;
                
                case MeleeWeaponTypes.ShortSword:
                    data = [10];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return data;
    }

    public int[] GetMeleeWeaponHitboxData(MeleeWeaponTypes identifier)
    {
        try
        {
            switch(identifier)
            {
                case MeleeWeaponTypes.Fist:
                    data = [20,20,20,40];
                    break;
                
                case MeleeWeaponTypes.ShortSword:
                    data = [50,50,50,100];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return data;
    }
    
    #endregion MeleeWeaponFunctions

    #region ChestpieceData

    public enum ChestpieceTypes
    {
        LeatherTunic,
        IronChestPlate
    }

    #endregion ChestpieceData

    #region ChestpieceFunctions

    public int[] GetChestpieceAttributeData(ChestpieceTypes identifier)  // {defence, x, y, z}
    {
        try
        {
            switch(identifier)
            {
                case ChestpieceTypes.LeatherTunic:
                    data = [10];
                    break;
                
                case ChestpieceTypes.IronChestPlate:
                    data = [30];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return data;
    }

    #endregion ChestpieceFunctions

    #region Compilers 

    public ItemDataHandler()
    {
        //Data array initiallization
        data = null;

        //Consumables
        //LoadFoodDictionary();
    }

    #endregion Compilers

    #region GeneralFunctions

    public int[] GetEquippableItemAttributeData(string itemName)
    {
        try
        {
            if (Enum.TryParse(itemName, true, out MeleeWeaponTypes MeleeWeaponTypes))
            {
                //LoadMeleeWeaponDictionary();
                data = GetMeleeWeaponAttributeData(MeleeWeaponTypes);
            }
            else if (Enum.TryParse(itemName, true, out ChestpieceTypes chestpieceTypes))
            {
                //LoadMeleeWeaponDictionary();
                data = GetChestpieceAttributeData(chestpieceTypes);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            data = null;
        }
        return data;
    }

    public Rectangle getWeaponHitbox(Globals.Directions direction,Vector2 position, string itemName) 
    {
        int[] variables = GetWeaponHitboxData(itemName); // pass player weapon 
        
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

    public int[] GetWeaponHitboxData(string itemName)
    {
        try
        {
            //ADD ALL ENUM IFS HERE:
            if (Enum.TryParse(itemName, true, out MeleeWeaponTypes MeleeWeaponTypes))
            {
                //LoadMeleeWeaponDictionary();
                data = GetMeleeWeaponHitboxData(MeleeWeaponTypes);
            }
        }
        catch(Exception e)
        {
            Microsoft.Xna.Framework.Input.MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
            data = null;
        }
        return data;
    }

    #endregion GeneralFunctions
}