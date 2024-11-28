using Microsoft.Xna.Framework.Input;
class InputHandler 
{
    private KeyboardState ks = Keyboard.GetState();

    public InputHandler()
    {
        //initialize non variable commands;
    }
    public Command HandleInput()     //TO DO: CREATE A MENU THAT CAN DYNAMICALLY CHANGE KEYS BASE ON PLAYER'S PREFERENCE
    {
        Update();
        if(ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return HandleCommand("W",true);
            }
            return HandleCommand("W",false);
        }
        if(ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Left))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return HandleCommand("A",true);
            }
            return HandleCommand("A",false);
        }
        if(ks.IsKeyDown(Keys.S) || ks.IsKeyDown(Keys.Down))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return HandleCommand("S",true);
            }
            return HandleCommand("S",false);
        }
        if(ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.Right))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                return HandleCommand("D",true);
            }
            return HandleCommand("D",false);
        }
        if(ks.IsKeyDown(Keys.Escape))
        {
            return HandleCommand("Esc",false);
        }

        return null;
    }

    public Command HandleCommand(string parameter, bool x)
    {
        switch (parameter) 
        {
            case "W":
                MoveCommand moveUp;
                if(x)
                {
                    moveUp = new MoveCommand("W",true);
                }
                else
                {
                    moveUp = new MoveCommand("W",false);
                }
                return moveUp;
            case "S":
                MoveCommand moveDown;
                if(x)
                {
                    moveDown = new MoveCommand("S",true);
                }
                else
                {
                    moveDown = new MoveCommand("S",false);
                }
                return moveDown;
            case "D":
                MoveCommand moveRight;
                if(x)
                {
                    moveRight = new MoveCommand("D",true);
                }
                else
                {
                    moveRight = new MoveCommand("D",false);
                }
                return moveRight;
            case "A":
                MoveCommand moveLeft;
                if(x)
                {
                    moveLeft = new MoveCommand("A",true);
                }
                else
                {
                    moveLeft = new MoveCommand("A",false);
                }
                return moveLeft;
            case "Esc":
                ExitCommand exit = new ExitCommand();
                return exit;
        }
        return null;
    }

    public virtual void Update()
    {
        ks = Keyboard.GetState();
    }

}