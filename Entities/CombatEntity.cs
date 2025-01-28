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

    public CombatEntity(EntityDataHandler.HostileEntityTypes entityName,Texture2D texture,Vector2 position) : base(entityName.ToString(),texture,position)
    {
        AssignAttributes();
    }

    public void AssignAttributes()
    { 
        base.Speed = 3;
        base.RunningSpeed = 4;
        HP = 100;
        AttackPower = 10;
    }

    public virtual void MeleeAttack()
    {
        Rectangle attackHitbox;
        switch(Direction)
        {
            case "W":
                attackHitbox = new Rectangle((int)(this.Position.X),(int)(this.Position.Y - 50),50,100);
                break;
            case "A":
                attackHitbox = new Rectangle((int)(this.Position.X - 50),(int)(this.Position.Y),100,50);
                break;
            case "S":
                attackHitbox = new Rectangle((int)(this.Position.X),(int)(this.Position.Y + 50),50,100);
                break;
            case "D":
                attackHitbox = new Rectangle((int)(this.Position.X + 50),(int)(this.Position.Y),100,50);
                break;
            case "WA":
                attackHitbox = new Rectangle((int)(this.Position.X - 50 ),(int)(this.Position.Y - 50),100,100);
                break;
            default:
                attackHitbox = new();
                break;
        }
        
    }
}


 

