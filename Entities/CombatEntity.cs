using System;
using System.Data;
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
        AssignAttributes(Globals.EntityDataHandler.GetHostileEntityAttributeData(this.Name));
    }

    public override void AssignAttributes(int[] attributes)
    { 
        try
        {
            base.AssignAttributes(attributes); //GET DATA FROM SAVE FILES.
            HP = attributes[1];
            AttackPower = attributes[4];
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
        
    }

    public virtual void MeleeAttack()
    {
        CombatEntity entityGettingAttacked = null;
        Rectangle attackHitbox = Globals.EntityDataHandler.getHostileEntityAttackHitBox(this.Direction,this.Position, this.Name.ToString());
        if(Globals.CollisionHandler.getCollidingEntity(this.Name,attackHitbox).GetType() == typeof(CombatEntity))
        {
            entityGettingAttacked = (CombatEntity)Globals.CollisionHandler.getCollidingEntity(this.Name,attackHitbox);
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
}


 

