
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

    private int[] hitboxData;
    private Rectangle hitbox;

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
                    hitboxData = [2];
                    break;
                
                case MeleeWeaponTypes.ShortSword:
                    hitboxData = [10];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return hitboxData;
    }

    public int[] GetMeleeWeaponHitboxData(MeleeWeaponTypes identifier)
    {
        hitboxData = null;
        try
        {
            switch(identifier)
            {
                case MeleeWeaponTypes.Fist:
                    hitboxData = [20,20,20,40];
                    break;
                
                case MeleeWeaponTypes.ShortSword:
                    hitboxData = [50,50,50,100];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return hitboxData;
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
                    hitboxData = [10];
                    break;
                
                case ChestpieceTypes.IronChestPlate:
                    hitboxData = [30];
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        return hitboxData;
    }

    #endregion ChestpieceFunctions

    #region Compilers 

    public ItemDataHandler()
    {
        //hitboxData array initiallization
        hitboxData = null;
        hitbox = new();

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
                hitboxData = GetMeleeWeaponAttributeData(MeleeWeaponTypes);
            }
            else if (Enum.TryParse(itemName, true, out ChestpieceTypes chestpieceTypes))
            {
                //LoadMeleeWeaponDictionary();
                hitboxData = GetChestpieceAttributeData(chestpieceTypes);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            hitboxData = null;
        }
        return hitboxData;
    }

    public Rectangle getWeaponHitbox(Globals.Directions direction,Vector2 position, string itemName) 
    {
        hitbox = new();
        if(AssignWeaponHitboxData(itemName)) // pass player weapon 
        {      
            hitbox.Width = hitboxData[2];
            hitbox.Height = hitboxData[3];    
            switch(direction)
            {
                case Globals.Directions.Up:
                    hitbox.X = (int)position.X;
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case Globals.Directions.Left:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y;
                    break;

                case Globals.Directions.Down:
                    hitbox.X = (int)position.X;
                    hitbox.Y = (int)position.Y + hitboxData[1];
                    break;
                    
                case Globals.Directions.Right:
                    hitbox.X = (int)position.X + hitboxData[0];
                    hitbox.Y = (int)position.Y;
                    break;

                case Globals.Directions.UpLeft:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case Globals.Directions.UpRight:
                    hitbox.X = (int)position.X + hitboxData[0];
                    hitbox.Y = (int)position.Y - hitboxData[1];
                    break;

                case Globals.Directions.DownLeft:
                    hitbox.X = (int)position.X - hitboxData[0];
                    hitbox.Y = (int)position.Y + hitboxData[1];
                    break;

                case Globals.Directions.DownRight:
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
    

    public bool AssignWeaponHitboxData(string itemName)
    {
        hitboxData = null;
        try
        {
            //ADD ALL ENUM IFS HERE:
            if (Enum.TryParse(itemName, true, out MeleeWeaponTypes MeleeWeaponTypes))
            {
                //LoadMeleeWeaponDictionary();
                hitboxData = GetMeleeWeaponHitboxData(MeleeWeaponTypes);
                return true;
            }
        }
        catch(Exception e)
        {
            Microsoft.Xna.Framework.Input.MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
            hitboxData = null;
        }
        return false;
    }

    #endregion GeneralFunctions
}