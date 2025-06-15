using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class InputHandler 
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
        if(ks.IsKeyDown(Keys.Back))
        {
            return HandleCommandType("BackSpace",false);
        }
        if(ks.IsKeyDown(Keys.Space))
        {
            return HandleCommandType("Space",false);
        }
        if(ks.IsKeyDown(Keys.E))
        {
            return HandleCommandType("E",false);
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

    public Command HandleCommandType(string parameter, bool isRunning)
    {
        switch (parameter) 
        {
            case "W":
                MoveCommand moveUp;
                if(isRunning)
                {
                    moveUp = new MoveCommand(GlobalEnumarations.Directions.Up,true);
                }
                else
                {
                    moveUp = new MoveCommand(GlobalEnumarations.Directions.Up,false);
                }
                return moveUp;
            case "WA":
                MoveCommand moveUpLeft;
                if(isRunning)
                {
                    moveUpLeft = new MoveCommand(GlobalEnumarations.Directions.UpLeft,true);
                }
                else
                {
                    moveUpLeft = new MoveCommand(GlobalEnumarations.Directions.UpLeft,false);
                }
                return moveUpLeft;
            case "WD":
                MoveCommand moveUpRight;
                if(isRunning)
                {
                    moveUpRight = new MoveCommand(GlobalEnumarations.Directions.UpRight,true);
                }
                else
                {
                    moveUpRight = new MoveCommand(GlobalEnumarations.Directions.UpRight,false);
                }
                return moveUpRight;
            case "S":
                MoveCommand moveDown;
                if(isRunning)
                {
                    moveDown = new MoveCommand(GlobalEnumarations.Directions.Down,true);
                }
                else
                {
                    moveDown = new MoveCommand(GlobalEnumarations.Directions.Down,false);
                }
                return moveDown;
            case "SA":
                MoveCommand moveDownLeft;
                if(isRunning)
                {
                    moveDownLeft = new MoveCommand(GlobalEnumarations.Directions.DownLeft,true);
                }
                else
                {
                    moveDownLeft = new MoveCommand(GlobalEnumarations.Directions.DownLeft,false);
                }
                return moveDownLeft;
            case "SD":
                MoveCommand moveDownRight;
                if(isRunning)
                {
                    moveDownRight = new MoveCommand(GlobalEnumarations.Directions.DownRight,true);
                }
                else
                {
                    moveDownRight = new MoveCommand(GlobalEnumarations.Directions.DownRight,false);
                }
                return moveDownRight;
            case "D":
                MoveCommand moveRight;
                if(isRunning)
                {
                    moveRight = new MoveCommand(GlobalEnumarations.Directions.Right,true);
                }
                else
                {
                    moveRight = new MoveCommand(GlobalEnumarations.Directions.Right,false);
                }
                return moveRight;
            case "A":
                MoveCommand moveLeft;
                if(isRunning)
                {
                    moveLeft = new MoveCommand(GlobalEnumarations.Directions.Left,true);
                }
                else
                {
                    moveLeft = new MoveCommand(GlobalEnumarations.Directions.Left,false);
                }
                return moveLeft;
            case "Esc":
                ExitCommand exit = new ExitCommand();
                return exit;
            case "ShiftSpace":
                FullScreenCommand fullScreen = new FullScreenCommand();
                return fullScreen;
            case "BackSpace":
                EnableDebugsCommand enableDebugsCommand = new EnableDebugsCommand();
                return enableDebugsCommand;
            case "Space":
                MeleeAttackCommand meleeAttackCommand = new MeleeAttackCommand();
                return meleeAttackCommand;
            case "E":
                InteractCommand InteractCommand = new InteractCommand();
                return InteractCommand;
        }
        return null;
    }

    public virtual void Update()
    {
        ks = Keyboard.GetState();
    }

    #endregion Functions

}