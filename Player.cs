using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using _2D_RPG;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private static Texture2D texture;
    public Vector2 position;
    private readonly Animation animation;
    private Sprite sprite;  // Add reference to the Sprite class

    public Player(Sprite sprite)
    {
        this.sprite = sprite;
        sprite.texture = Globals.content.Load<Texture2D>("testSpriteWalk_strip32");
        texture ??= sprite.texture;
        animation = new(sprite, 32, 0.1f);
        position = sprite.position;
    }

    public void Update()
    {
        animation.Update();
    }

    public void Draw()
    {
        animation.Draw(position);
    }

    // Expose texture width and height through properties
    public int SpriteWidth => sprite.Width;
    public int SpriteHeight => sprite.Height;
}
