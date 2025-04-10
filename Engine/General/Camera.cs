using System;
using _2D_RPG;
using Microsoft.Xna.Framework;

///<Summary>
/// Camera controls  
///</Summary>
public class Camera2D
{
    private Matrix _transform;
    private Vector2 _position;
    private float _zoom;
    private float _rotation;

    ///<Summary>
    /// camera constructor  
    ///</Summary>
    public Camera2D()
    {
        _zoom = 1f;
        _rotation = 0f;
        _position = new Vector2(500, 500);
    }

    ///<Summary>
    /// matrix to get the transform function of the camera with the inverted of cells 14 24 being the coordinates of the camera at lookat
    ///</Summary>
    public Matrix GetViewMatrix()
    {
        _transform =
            Matrix.CreateTranslation(new Vector3(-_position, 0)) *
            Matrix.CreateRotationZ(_rotation) *
            Matrix.CreateScale(_zoom, _zoom, 1) *
            //Matrix.CreateTranslation(new Vector3(Globals.GraphicsDeviceManager.PreferredBackBufferWidth * 0.5f, Globals.GraphicsDeviceManager.PreferredBackBufferHeight * 0.5f, 0));
            Matrix.CreateTranslation(new Vector3(Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width * 0.5f, Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height * 0.5f, 0));
        return _transform;
    }

    // Properties to control the camera
    private Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    private float Zoom
    {
        get => _zoom;
        set => _zoom = MathHelper.Clamp(value, 0.1f, 10f);
    }

    private float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }

    ///<Summary>
    /// Sets the camera to follow the player movement up until the edges of the map where it stays in bounds  
    ///</Summary>
    public void LookAt(Vector2 target)
    {
        int screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;
        //int screenWidth = Globals.GraphicsDeviceManager.PreferredBackBufferWidth;
        //int screenHeight = Globals.GraphicsDeviceManager.PreferredBackBufferHeight;
        bool isAtLimitX = target.X - screenWidth / 2 - 64 < 0 || target.X + screenWidth / 2 + 64 > Globals.WorldSize.X;
        bool isAtLimitY = target.Y - screenHeight / 2 - 64 < 0 || target.Y + screenHeight / 2 + 64 > Globals.WorldSize.X;
        //bool isAtInnerX = Math.Abs(_position.X - target.X) < 5 * 32; 
        //bool isAtInnerY = Math.Abs(_position.Y - target.Y) < 5 * 32;
        //if (isAtInnerX && isAtInnerY){}
        if (false){}
        else
        {
            if (isAtLimitX && isAtLimitY){}
            else if (isAtLimitX)
            {
                _position.Y = target.Y;
            }
            else if (isAtLimitY)
            {
                _position.X = target.X;
            }
            else
            {
                _position = target;
            }
        }
    }
}
