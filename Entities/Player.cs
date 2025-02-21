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

    public Player(EntityDataHandler.GeneralEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
        AssignAttributes(); //HERE WE NEED AN INTEGER ARRAY OF PLAYER ATTRIBUTES BASED ON SAVE FILES.
        AssignIteractHitbox();    
    }

    public override void AssignAttributes()
    {
        base.AssignAttributes(); // not needed unless we add more attibutes here or do some attribute logic magic
        this.MeleeWeaponEquiped = ItemDataHandler.MeleeWeapons.ShortSword; //GET DATA FROM SAVE FILES.
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
        var entityGettingInteracted = Globals.CollisionHandler.getCollidingEntity(this.Name,InteractHitbox);

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
        InteractHitbox = Globals.ItemDataHandler.getItemHitbox(this.Direction,this.Position, ItemDataHandler.MeleeWeapons.Fist.ToString());
    }
}


 

