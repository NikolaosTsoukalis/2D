using System.Numerics;
using System.Runtime.CompilerServices;

class movingEntity : Entity
{
    private float lspeed;
    public float speed
    {
        get{ return lspeed; }
        set{ lspeed = speed; }
    }
    private bool isRunning;
    public movingEntity(){}

    public virtual void Update(string parameter)
    {
        
    }
}