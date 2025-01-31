
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _2D_RPG;

public class ItemDataHandler
{
    #region Enums
    public enum Potions{}

    public enum Food{};

    public enum Materials{}
    
    public enum MeleeWeapons
    {
        ShortSword
    }

    public enum RangedWeapons{}

    public enum MagicWeapons{}

    public enum WeaponTypes
    {
        Melee,
        Ranged,
        Magic
    }

    enum Special{}

    #endregion Enums
    
    #region Values

    private static Dictionary<MeleeWeapons,string[]> meleeWeaponData;
    public static Dictionary<MeleeWeapons,string[]> MeleeWeaponData
    {
        get{return meleeWeaponData;}
        
    }

    #endregion Values
    public ItemDataHandler()
    {
        meleeWeaponData = new();
    }

    public static void LoadMeleeWeaponDictionary()
    {
        meleeWeaponData = new Dictionary<MeleeWeapons, string[]> {};
    }

    public static Dictionary<,string[]> getItemData(string itemName)
    {
        
        if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
        {
            LoadMeleeWeaponDictionary();
            return meleeWeaponData;
        }
        else if (Enum.TryParse(itemName, true, out Food food))
        {
            switch (hostileEnemyType)
            {
                case EntityDataHandler.HostileEntityTypes.Slime:
                    return AnimationDataHandler.SlimeAnimationData;
            }
        }
        return null;
    }
}