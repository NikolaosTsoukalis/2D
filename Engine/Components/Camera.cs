using _2D_RPG;
using Microsoft.Xna.Framework;

public class Camera2D
{
    private Matrix _transform;
    private Vector2 _position;
    private float _zoom;
    private float _rotation;

    public Camera2D()
    {
        _zoom = 1f;
        _rotation = 0f;
        _position = Vector2.Zero;
    }

    public Matrix GetViewMatrix()
    {
        _transform =
            Matrix.CreateTranslation(new Vector3(-_position, 0)) *
            Matrix.CreateRotationZ(_rotation) *
            Matrix.CreateScale(_zoom, _zoom, 1) *
            Matrix.CreateTranslation(new Vector3(Globals.GraphicsDeviceManager.PreferredBackBufferWidth * 0.5f, Globals.GraphicsDeviceManager.PreferredBackBufferHeight * 0.5f, 0));
        return _transform;
    }

    // Properties to control the camera
    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public float Zoom
    {
        get => _zoom;
        set => _zoom = MathHelper.Clamp(value, 0.1f, 10f);
    }

    public float Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }

    public void Move(Vector2 amount)
    {
        _position += amount;
    }

    public void LookAt(Vector2 target)
    {
        _position = target;
    }
}
