using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Player : CombatEntity
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

    public Player(EntityDataHandler.GeneralEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
        AssignAttributes();
    }

    public override void AssignAttributes()
    {
        base.AssignAttributes();
    }

    public override void MeleeAttack()
    {
        base.MeleeAttack();
    }

    public override bool GetAttacked(float damageTaken)
    {
        base.GetAttacked(damageTaken);
        return true;
    }

    public override void Interact()
    {
        var entityGettingInteracted = new(null);
        Rectangle interactHitbox = Globals.ItemDataHandler.getHitBox(this.Direction,this.Position, ItemDataHandler.MeleeWeapons.Fist.ToString());
        if(Globals.CollisionHandler.getCollidingEntity(this.Name,interactHitbox).IsInteractable)
        {
            var entityGettingInteracted = Globals.CollisionHandler.getCollidingEntity(this.Name,interactHitbox);
        }
        
        if(entityGettingInteracted != null)
        {
            entityGettingAttacked.GetAttacked(Globals.ItemDataHandler.GetEquippableItemAttributeData(this.MeleeWeaponEquiped.ToString())[0]);
        }
        else
        {
            Console.WriteLine("THIS CANNOT BE ATTACKED!");
        }
    }
}


 

