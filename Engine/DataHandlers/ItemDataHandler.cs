
using System.Collections.Generic;
using System.ComponentModel;

namespace _2D_RPG;

public class ItemDataHandler
{
    #region Enums
    enum Potions{}

    enum Food{};

    enum Materials{}
    
    enum MeleeWeapons
    {
        ShortSword
    }

    enum RangedWeapons{}

    enum MagicWeapons{}

    public enum WeaponTypes
    {
        Melee,
        Ranged,
        Magic
    }

    enum Special{}

    #endregion Enums
    
    #region Values

    private Dictionary<MeleeWeapons,string[]> meleeWeaponData;
    #endregion Values
    public ItemDataHandler()
    {
        meleeWeaponData = new();
    }

    public static void LoadMeleeWeaponDictionary()
    {
        meleeWeaponData = new ()
    }
}