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
                int[] variables = ItemDataHandler.getItemHitboxData(ItemDataHandler.MeleeWeapons.ShortSword.ToString()); // pass player weapon 
        
                switch(direction)
                {
                    case "W":
                        return new Rectangle((int)(position.X),(int)(position.Y - variables[1]),variables[2],variables[3]);

                    case "A":
                        return new Rectangle((int)(position.X - variables[0]),(int)(position.Y),variables[2],variables[3]);

                    case "S":
                        return new Rectangle((int)(position.X),(int)(position.Y + variables[1]),variables[2],variables[3]);
                        
                    case "D":
                        return new Rectangle((int)(position.X + variables[0]),(int)(position.Y),variables[2],variables[3]);
                        
                    case "WA":
                        return new Rectangle((int)(position.X - variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);

                    default:
                        return new();
                }
            case ItemDataHandler.WeaponTypes.Ranged:
                return new();
        }
        return new();
    }
}