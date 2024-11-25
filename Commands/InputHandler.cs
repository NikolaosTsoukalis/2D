using Microsoft.Xna.Framework.Input;
class InputHandler 
{
    private Command moveUp,moveDown,moveLeft,moveRight,exit;
    private KeyboardState ks = Keyboard.GetState();
    public Command HandleInput()
    {
        CommandAssign(); // temporary! this might be added to MAIN
        if(ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return moveUp = new MoveCommand("W",true);
            }
            return moveUp;
        }
        if(ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Left))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return moveUp = new MoveCommand("A",true);
            }
            return moveLeft;
        }
        if(ks.IsKeyDown(Keys.S) || ks.IsKeyDown(Keys.Down))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return moveUp = new MoveCommand("S",true);
            }
            return moveDown;
        }
        if(ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.Right))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return moveUp = new MoveCommand("D",true);
            }
            return moveRight;
        }
        if(ks.IsKeyDown(Keys.Escape))
        {
            return exit;
        }

        return null;
    }

    public void CommandAssign()
    {
        moveUp = new MoveCommand("W");
        moveDown = new MoveCommand("S");
        moveRight = new MoveCommand("A");
        moveLeft = new MoveCommand("D");
        exit = new ExitCommand();
    }

    public virtual void Update()
    {
        ks = Keyboard.GetState();
    }

}