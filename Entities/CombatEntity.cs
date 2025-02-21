using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CombatEntity : MovingEntity
{
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

    private ItemDataHandler.MeleeWeapons meleeWeaponEquiped;
    public ItemDataHandler.MeleeWeapons MeleeWeaponEquiped 
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
        AssignAttributes(Globals.EntityDataHandler.GetEntityAttributeData(this.Name));
        AssignHitbox(this,null);
    }

    public override void AssignAttributes(int[] attributes)
    { 
        try
        {
            //defence
            //intellect
            //stamina?
            //etc (everything that in not assign at parent method calls.)   
            this.ModifyAttribute(Globals.AttributeTypes.HP,attributes[1]);  
            this.ModifyAttribute(Globals.AttributeTypes.AttackPower,attributes[4]);          
            base.AssignAttributes(attributes);
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        
    }

    public virtual void MeleeAttack()
    {
        CombatEntity entityGettingAttacked = null;
        if(Globals.CollisionHandler.getCollidingEntity(this.Name,AttackHitbox).GetType() == typeof(CombatEntity))
        {
            entityGettingAttacked = (CombatEntity)Globals.CollisionHandler.getCollidingEntity(this.Name,AttackHitbox);
        }
        
        if(entityGettingAttacked != null)
        {
            entityGettingAttacked.GetAttacked(this.AttackPower);
        }
        else
        {
            Console.WriteLine("THIS CANNOT BE ATTACKED!");
        }
    }

    public virtual bool GetAttacked(float damageTaken)
    {
        //damage taken should be overriden by a method that takes into account all attributes/abillities.
        HP -= damageTaken;
        return true;
    }

    public void AssignHitbox(Entity entity,string weaponName)
    {
        if(entity.GetType() == typeof(Player))
        {
            AttackHitbox = Globals.ItemDataHandler.getItemHitbox(this.Direction,this.Position, weaponName);
        }
        else
            AttackHitbox = Globals.EntityDataHandler.getEntityAttackHitBox(this.Direction,this.Position, this.Name.ToString());
    }
}


 

