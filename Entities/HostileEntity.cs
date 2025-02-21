using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class HostileEntity : CombatEntity
{

    public HostileEntity(EntityDataHandler.HostileEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(), texture, position)
    {
        AssignAttributes(Globals.EntityDataHandler.GetEntityAttributeData(this.Name));
    }

    public override void AssignAttributes(int[] attributes)
    {
        //add extras?
        base.AssignAttributes(attributes);
    }

    public override void getInteractedWith()
    {
        Globals.drawInteraction = !Globals.drawInteraction;
    }

    public override void MeleeAttack()
    {
        base.MeleeAttack();
    }
}