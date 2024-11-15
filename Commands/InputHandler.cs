using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
class InpuHandler 
{
    private Command moveUp,moveDown,moveLeft,moveRight;
    private KeyboardState ks = Keyboard.GetState();
    public Command handleInput()
    {
        if(ks.IsKeyDown(Keys.W))
        {
            return moveUp;
        }
        if(ks.IsKeyDown(Keys.A))
        {
            return moveLeft;
        }
        if(ks.IsKeyDown(Keys.S))
        {
            return moveDown;
        }
        if(ks.IsKeyDown(Keys.D))
        {
            return moveRight;
        }

        return null;
    }

    public void MoveCommand()
    {
        moveUp = new MoveCommand("W");
        moveDown = new MoveCommand("S");
        moveRight = new MoveCommand("A");
        moveLeft = new MoveCommand("D");
    }

}