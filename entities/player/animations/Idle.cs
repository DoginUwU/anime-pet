using Godot;

namespace Entities.Player.Animations;

public class Idle : BasePlayerAnimation
{
    private readonly Texture2D idleTexture = GD.Load<Texture2D>("res://entities/player/assets/idle.png");

    public override void Start()
    {
        Player.Instance.Texture = idleTexture;
    }

    public override void Process(double delta) {}
}