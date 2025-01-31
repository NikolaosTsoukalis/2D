using System.Drawing;
using System.Numerics;

namespace _2D_RPG;

public class Attack
{

    public Attack(){}


    public Rectangle GetHitBox(ItemDataHandler.WeaponTypes weaponType,Vector2 position,string direction)// pass in current weapon.
    {
        switch(weaponType)
        {
            case ItemDataHandler.WeaponTypes.Melee:
                //int[] variables = GetMeleeWeaponVariables(MeleeWeaponType.Sword); // pass player weapon 
                
                switch(direction)
                {
                    case "W":
                        return new Rectangle((int)(position.X),(int)(position.Y - variables[1]),variables[2],variables[3]);

                    case "A":
                        return new Rectangle((int)(position.X - 50),(int)(position.Y),100,50);

                    case "S":
                        return new Rectangle((int)(position.X),(int)(position.Y + 50),50,100);
                        
                    case "D":
                        return new Rectangle((int)(position.X + 50),(int)(position.Y),100,50);
                        
                    case "WA":
                        return new Rectangle((int)(position.X - 50 ),(int)(position.Y - 50),100,100);

                    default:
                        return new();
                }
            case AttackTypes.Ranged:
                return new();
        }
        return new();
    }

    public int[] GetMeleeWeaponVariables(MeleeWeaponType weaponType)
    {
        switch(weaponType)
        {
            case MeleeWeaponType.Sword:
                return [50,50,100]; // these are the specific hitboxes and positions base on the weapon used. TO DO: MAKE A DICTIONARY WITH WEAPON SPECIFICS.
        }
        return [];
    }
}