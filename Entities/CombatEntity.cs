using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CombatEntity : MovingEntity
{
    #region Enums

    private enum AttributesTypes
    {
        Speed,
        runningSpeed,
        HP,
        AttackPower
    }
    #endregion Enums
    private float speed;
    public float Speed 
    {
        get{ return speed;}
        set{speed = value;}
    }
    private float runningSpeed;
    public float RunningSpeed 
    {
        get{ return runningSpeed;}
        set{runningSpeed = value;}
    }

    private float hp;
    public float HP 
    {
        get{ return hp;}
        set{hp = value;}
    }
    private float attackPower;
    public float AttackPower 
    {
        get{ return attackPower;}
        set{attackPower = value;}
    }

    public CombatEntity(EntityDataHandler.HostileEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
        AssignAttributes();
    }

    public void AssignAttributes()
    { 
        base.Speed = 3;
        base.RunningSpeed = 4;
        HP = 100;
        AttackPower = 10;
    }

    public Rectangle MeleeAttack(ItemDataHandler.WeaponTypes weaponType,Vector2 position,string direction)// pass in current weapon.
    {
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
    }
}


 

