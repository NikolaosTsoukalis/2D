using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder()
    {
    }

    public void BuildMainMenu()
    {
        
    }

    public static Menu BuildLandingMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();

        Button StartGameButton = new Button(ButtonType.StartGameButton);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(ButtonType.SettingsButton);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(ButtonType.QuitButton);
        Buttons.Add(QuitButton);
        Menu menu = new Menu(new VerticalMainMenuLayoutBase(Buttons, null));
        return menu; 
    }

}