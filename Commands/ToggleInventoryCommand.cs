using Microsoft.Xna.Framework;

namespace _2D_RPG;

class ToggleInventoryCommand : Command 
{
    #region Values
    #endregion Values

    #region Constructors

    public ToggleInventoryCommand() : base(CommandTypes.ToggleInventoryCommand){}

    #endregion Constructors

    #region Functions
    
    public override void Execute(Main main)
    {
        //entity.Direction = direction;
        if(Main.currentGameState.GetType() == typeof(GameState))
        {
            Globals.ToggleInventory = !Globals.ToggleInventory;
        }

    }

    #endregion Functions
}