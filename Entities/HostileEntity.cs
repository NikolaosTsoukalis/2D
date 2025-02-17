using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class HostileEntity : CombatEntity
{

    public HostileEntity(EntityDataHandler.HostileEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(), texture, position)
    {
        AssignAttributes();
    }

    public override void AssignAttributes()
    {
        base.AssignAttributes();
        /* 
        base.Speed = 3;
        base.RunningSpeed = 4;
        HP = 100;
        AttackPower = 10;
        MeleeWeaponEquiped = ItemDataHandler.MeleeWeapons.ShortSword;
        */
    }
}