using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace _2D_RPG;

public class Attack
{

    public enum AttackTypes
    {
        Melee,
        Ranged
    }

    public enum MeleeWeaponType
    {
        Sword,
        ShortSword
    }
    public Attack(){}


    public Rectangle GetHitBox(AttackTypes attackType,Vector2 position,string direction)
    {
        switch(attackType)
        {
            case AttackTypes.Melee:
                GetMeleeWeaponVariables()
                switch(direction)
                {
                    case "W":
                        return new Rectangle((int)(position.X),(int)(position.Y - 50),50,100);

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

    public string[] GetMeleeWeaponVariables(MeleeWeaponType weaponType)
    {
        switch(weaponType)
        {
            case MeleeWeaponType.Sword:
                return ["0","50","50","100"]; // these are the specific hitboxes and positions base on the weapon used. TO DO: MAKE A DICTIONARY WITH WEAPON SPECIFICS.
        }
        return [];
    }
}