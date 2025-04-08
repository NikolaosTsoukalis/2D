namespace _2D_RPG;

class InteractCommand : Command 
{
    #region Fields

    #endregion Fields

    #region Constructors

    public InteractCommand() : base(CommandTypes.InteractCommand){}

    #endregion Constructors

    #region Functions
    
    public override void Execute(Player entity)
    {
        //entity.Direction = direction;
        entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Interact; // Interaction Animation ( pick up item/talk to npc/pet dog)
        entity.Interact();
    }

    #endregion Functions
}

