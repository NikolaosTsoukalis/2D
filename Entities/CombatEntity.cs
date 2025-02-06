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

    public ItemDataHandler.MeleeWeapons MeleeWeaponEquiped;

    public CombatEntity(string entityName,Texture2D texture,Vector2 position) : base(entityName,texture,position)
    {
        AssignAttributes();
    }

    public virtual void AssignAttributes()
    { 
        base.Speed = 3;
        base.RunningSpeed = 4;
        HP = 100;
        AttackPower = 10;
        MeleeWeaponEquiped = ItemDataHandler.MeleeWeapons.ShortSword;
    }

    public virtual void MeleeAttack()
    {
        Rectangle attackHitbox = Globals.itemDataHandler.getWeaponHitBox(this.Direction,this.Position, this.MeleeWeaponEquiped.ToString());
        Entity entityGettingHit = Globals.collisionHandler.getCollidingEntity(this.Name,attackHitbox);
        
        if(entityGettingHit != null)
        {
            //remove health from entity base on weapon damage.
        }
    }
}


 

