using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

class InputHandler 
{
    #region Values

    private KeyboardState ks = Keyboard.GetState();

    #endregion Values

    #region Constructors

    public InputHandler()
    {
        //initialize non variable commands;
    }

    #endregion Constructors

    #region Functions

    public Command HandleInput()     //TO DO: CREATE A MENU THAT CAN DYNAMICALLY CHANGE KEYS BASE ON PLAYER'S PREFERENCE
    {
        Update();
        if(ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.S) || ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.W))
        {
            return HandleMovementInput();
        }
        if(ks.IsKeyDown(Keys.Escape))
        {
            return HandleCommandType("Esc",false);
        }
        if(ks.IsKeyDown(Keys.LeftShift) && ks.IsKeyDown(Keys.Space))
        {
            return HandleCommandType("ShiftSpace",false);
        }
        return null;
    }

    public Command HandleMovementInput()
    {
        if(ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                if(ks.IsKeyDown(Keys.D))
                {
                    return HandleCommandType("WD",true);
                }
                else if(ks.IsKeyDown(Keys.A))
                {
                    return HandleCommandType("WA",true);
                }
                else if(ks.IsKeyDown(Keys.S))
                {
                    return null;
                }
                else
                    return HandleCommandType("W",true);
            }
            if(ks.IsKeyDown(Keys.D))
            {
                return HandleCommandType("WD",false);
            }
            else if(ks.IsKeyDown(Keys.A))
            {
                return HandleCommandType("WA",false);
            }
            else if(ks.IsKeyDown(Keys.S))
            {
                return null;
            }
            return HandleCommandType("W",false);
        }
        if(ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Left))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                if(ks.IsKeyDown(Keys.W))
                {
                    return HandleCommandType("WA",true);
                }
                else if(ks.IsKeyDown(Keys.S))
                {
                    return HandleCommandType("SA",true);
                }
                else if(ks.IsKeyDown(Keys.D))
                {
                    return null;
                }
                else
                    return HandleCommandType("A",true);
            }
            if(ks.IsKeyDown(Keys.W))
            {
                return HandleCommandType("WA",false);
            }
            else if(ks.IsKeyDown(Keys.S))
            {
                return HandleCommandType("SA",false);
            }
            else if(ks.IsKeyDown(Keys.D))
            {
                return null;
            }
            return HandleCommandType("A",false);
        }
        if(ks.IsKeyDown(Keys.S) || ks.IsKeyDown(Keys.Down))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                if(ks.IsKeyDown(Keys.A))
                {
                    return HandleCommandType("SA",true);
                }
                else if(ks.IsKeyDown(Keys.D))
                {
                    return HandleCommandType("SD",true);
                }
                else if(ks.IsKeyDown(Keys.W))
                {
                    return null;
                }
                return HandleCommandType("S",true);
            }
            if(ks.IsKeyDown(Keys.A))
            {
                return HandleCommandType("SA",false);
            }
            else if(ks.IsKeyDown(Keys.D))
            {
                return HandleCommandType("SD",false);
            }
            else if(ks.IsKeyDown(Keys.W))
            {
                return null;
            }
            return HandleCommandType("S",false);
        }
        if(ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.Right))
        {
            if(ks.IsKeyDown(Keys.LeftShift))
            {
                if(ks.IsKeyDown(Keys.W))
                {
                    return HandleCommandType("WD",true);
                }
                else if(ks.IsKeyDown(Keys.S))
                {
                    return HandleCommandType("SD",true);
                }
                else if(ks.IsKeyDown(Keys.A))
                {
                    return null;
                }
                return HandleCommandType("D",true);
            }
            if(ks.IsKeyDown(Keys.W))
            {
                return HandleCommandType("WD",false);
            }
            else if(ks.IsKeyDown(Keys.S))
            {
                return HandleCommandType("SD",false);
            }
            else if(ks.IsKeyDown(Keys.W))
            {
                return null;
            }
            return HandleCommandType("D",false);
        }
        return null;
    }

    public Command HandleCommandType(string parameter, bool x)
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
            case "WA":
                MoveCommand moveUpLeft;
                if(x)
                {
                    moveUpLeft = new MoveCommand("WA",true);
                }
                else
                {
                    moveUpLeft = new MoveCommand("WA",false);
                }
                return moveUpLeft;
            case "WD":
                MoveCommand moveUpRight;
                if(x)
                {
                    moveUpRight = new MoveCommand("WD",true);
                }
                else
                {
                    moveUpRight = new MoveCommand("WD",false);
                }
                return moveUpRight;
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
            case "SA":
                MoveCommand moveDownLeft;
                if(x)
                {
                    moveDownLeft = new MoveCommand("SA",true);
                }
                else
                {
                    moveDownLeft = new MoveCommand("SA",false);
                }
                return moveDownLeft;
            case "SD":
                MoveCommand moveDownRight;
                if(x)
                {
                    moveDownRight = new MoveCommand("SD",true);
                }
                else
                {
                    moveDownRight = new MoveCommand("SD",false);
                }
                return moveDownRight;
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
            case "ShiftSpace":
                FullScreenCommand fullScreen = new FullScreenCommand();
                return fullScreen;
        }
        return null;
    }

    public virtual void Update()
    {
        ks = Keyboard.GetState();
    }

    #endregion Functions

}