namespace _2D_RPG;

public class MenuHandler()
{
    private Menu currentMenu;
    private State currentGameState;

    public MenuHandler(Main main)
    {
        currentGameState = main.currentGameState;
        this.currentMenu = null;
    }


}