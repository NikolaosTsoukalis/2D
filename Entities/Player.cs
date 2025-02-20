using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Player : CombatEntity
{
    public ItemDataHandler.MeleeWeapons MeleeWeaponEquiped;

    public Player(EntityDataHandler.GeneralEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
        //AssignAttributes(Globals.EntityDataHandler.GetEntityAttributeData(this.Name)); //HERE WE NEED AN INTEGER ARRAY OF PLAYER ATTRIBUTES BASED ON SAVE FILES
    }

    public override void AssignAttributes(int[] attributes)
    {
        base.AssignAttributes(attributes);
        MeleeWeaponEquiped = ItemDataHandler.MeleeWeapons.ShortSword; //GET DATA FROM SAVE FILES.
    }

    public override void MeleeAttack()
    {
        CombatEntity entityGettingAttacked = null;
        Rectangle attackHitbox = Globals.ItemDataHandler.getItemHitbox(this.Direction,this.Position, this.MeleeWeaponEquiped.ToString());
        if(Globals.CollisionHandler.getCollidingEntity(this.Name,attackHitbox).GetType() == typeof(CombatEntity))
        {
            entityGettingAttacked = (CombatEntity)Globals.CollisionHandler.getCollidingEntity(this.Name,attackHitbox);
        }
        
        if(entityGettingAttacked != null)
        {
            entityGettingAttacked.GetAttacked(Globals.ItemDataHandler.GetEquippableItemAttributeData(this.MeleeWeaponEquiped.ToString())[0]);
        }
        else
        {
            Console.WriteLine("THIS CANNOT BE ATTACKED!");
        }
    }

    public override bool GetAttacked(float damageTaken)
    {
        base.GetAttacked(damageTaken);
        return true;
    }

    public override void Interact()
    {
        Rectangle interactHitbox = Globals.ItemDataHandler.getItemHitbox(this.Direction,this.Position, ItemDataHandler.MeleeWeapons.Fist.ToString());

        var entityGettingInteracted = Globals.CollisionHandler.getCollidingEntity(this.Name,interactHitbox);

        if(entityGettingInteracted != null && entityGettingInteracted.IsInteractable)
        {
            entityGettingInteracted.getInteractedWith();
        }
        else
        {
            Console.WriteLine("Nothing to Interact with!");
        }
    }
}


 

