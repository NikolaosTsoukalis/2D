using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using _2D_RPG;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class InputManager 
{

    public static KeyboardState ks = Keyboard.GetState();

    public InputManager(){}

    public static void Update()
    {
        ks = Keyboard.GetState();
    }
}