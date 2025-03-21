using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Player : CombatEntity
{
    private Rectangle interactHitBox;
    public Rectangle InteractHitbox 
    {
        get{ return interactHitBox;}
        set{interactHitBox = value;}
    }

    public Player(EntityDataHandler.NonHostileEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
         //HERE WE NEED AN INTEGER ARRAY OF PLAYER ATTRIBUTES BASED ON SAVE FILES.
        this.AssignIteractHitbox();    
    }

    public override void AssignAttributes()
    {
        base.AssignAttributes(); // not needed unless we add more attibutes here or do some attribute logic magic
        this.MeleeWeaponEquiped = ItemDataHandler.MeleeWeaponTypes.ShortSword; //GET DATA FROM SAVE FILES.
    }

    public override void MeleeAttack()
    {
        base.MeleeAttack();
    }

    public override bool GetAttacked(int damageTaken)
    {
        base.GetAttacked(damageTaken);
        return true;
    }

    public override void Interact()
    {
        AssignIteractHitbox();
        var entityGettingInteracted = Globals.CollisionHandler.getCollidingEntity(this.Name,this.InteractHitbox);

        if(entityGettingInteracted != null && entityGettingInteracted.IsInteractable)
        {
            entityGettingInteracted.getInteractedWith();
        }
        else
        {
            Console.WriteLine("Nothing to Interact with!");
        }
    }

    public void AssignIteractHitbox()
    {
        //add extra pros cons based on consumables/items equipped/buffs etc.
        //HITBOX IS PULLED FROM THE ENTITY DATA HANDLER AS IT IS NOT BASED ON A WEAPON/ITEM. 
        //LOGIC CAN BE ADDED TO INFLUENCE THE INTERACT HITBOX BUT IT WILL NEVER BE BASED ON AN ITEM.
        InteractHitbox = Globals.EntityDataHandler.GetEntityAttackHitBox(this.Direction,this.Position, this.Name);
    }
}


 

