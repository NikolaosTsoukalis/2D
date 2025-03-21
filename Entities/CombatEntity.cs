using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CombatEntity : MovingEntity
{
    protected int HP;
    protected int AttackPower;

    private ItemDataHandler.MeleeWeaponTypes meleeWeaponEquiped;
    public ItemDataHandler.MeleeWeaponTypes MeleeWeaponEquiped 
    {
        get{ return meleeWeaponEquiped;}
        set{meleeWeaponEquiped = value;}
    }

    private Rectangle attackHitBox;
    public Rectangle AttackHitbox 
    {
        get{ return attackHitBox;}
        set{attackHitBox = value;}
    }

    public CombatEntity(string entityName,Texture2D texture,Vector2 position) : base(entityName,texture,position)
    {
        //this.AssignAttributes();
        this.AssignHitbox(null);
    }

    public override void AssignAttributes()
    { 
        base.AssignAttributes();
        try
        {
            //defence
            //intellect
            //stamina?
            //etc (everything that in not assign at parent method calls.)   
            this.ModifyAttribute(Globals.AttributeTypes.HP,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,Globals.AttributeTypes.HP));  
            this.ModifyAttribute(Globals.AttributeTypes.AttackPower,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,Globals.AttributeTypes.AttackPower));          
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    public virtual void MeleeAttack()
    {
        AssignHitbox(this.MeleeWeaponEquiped.ToString());
        CombatEntity entityGettingAttacked = null;
        if(Globals.CollisionHandler.getCollidingEntity(this.Name,AttackHitbox) != null)
        {    
            if(Globals.CollisionHandler.getCollidingEntity(this.Name,AttackHitbox).GetType() == typeof(CombatEntity))
            {
                entityGettingAttacked = (CombatEntity)Globals.CollisionHandler.getCollidingEntity(this.Name,AttackHitbox);
            }
        }
        if(entityGettingAttacked != null)
        {
            entityGettingAttacked.GetAttacked(this.GetAttribute(Globals.AttributeTypes.AttackPower));
        }
        else
        {
            Console.WriteLine("THIS CANNOT BE ATTACKED!");
        }
    }

    public virtual bool GetAttacked(int damageTaken)
    {
        //damage taken should be overriden by a method that takes into account all attributes/abillities.
        int currentHp = this.GetAttribute(Globals.AttributeTypes.HP) - damageTaken;  
        this.ModifyAttribute(Globals.AttributeTypes.HP,currentHp);
        
        return true;
    }

    public void AssignHitbox(string weaponName)
    {
        if(weaponName != null)
        {
            AttackHitbox = Globals.ItemDataHandler.getWeaponHitbox(this.Direction,this.Position, weaponName);
        }
        else
            AttackHitbox = Globals.EntityDataHandler.GetEntityAttackHitBox(this.Direction,this.Position, this.Name.ToString());
    }
}


 

