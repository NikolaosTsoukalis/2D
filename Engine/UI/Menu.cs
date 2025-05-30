using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Menu 
{
    
    public List<Button> Buttons;

    public Component baseFieldComponent;

    //public Vector2 

    public Menu(List<Button> Buttons)
    {
        this.Buttons = Buttons;
    }

    public void Update(GameTime gameTime)
    {
        foreach (var button in Buttons)
        {
            button.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        foreach (var button in Buttons)
        {
            button.Draw(gameTime);
        }
        Globals.SpriteBatch.End();
    }
    
    public void AssignButtonPositions()
    {
        for(int i = 0; i < Buttons.Count; i++)
        {
            if (i == 0)
            {
                //Buttons[i].Position = 
            }
        }
    }
    
}