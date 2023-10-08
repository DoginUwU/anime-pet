using GameScenes;
using Godot;

namespace Entities.Player.Animations;

public class Walk : BasePlayerAnimation
{
    private readonly Texture2D upPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/up_player.png");
    private readonly Texture2D downPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/down_player.png");
    private readonly Texture2D leftPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/left_player.png");
    private readonly Texture2D rightPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/right_player.png");
    private readonly Texture2D topLeftPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/top_left_player.png");
    private readonly Texture2D topRightPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/top_right_player.png");
    private readonly Texture2D bottomLeftPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/bottom_left_player.png");
    private readonly Texture2D bottomRightPlayerTexture = GD.Load<Texture2D>("res://entities/player/assets/bottom_right_player.png");

    public override void Start() {}

    public override void Process(double delta)
    {
        Vector2I step = GameController.Instance.commonWindow.normalizedCurrentStep;

        if(step == Vector2I.Up) {
            Player.Instance.Texture = upPlayerTexture;
        } else if(step == Vector2I.Down) {
            Player.Instance.Texture = downPlayerTexture;
        } else if(step == Vector2I.Left) {
            Player.Instance.Texture = leftPlayerTexture;
        } else if(step == Vector2I.Right) {
            Player.Instance.Texture = rightPlayerTexture;
        } else if(step == new Vector2I(-1, -1)) {
            Player.Instance.Texture = topLeftPlayerTexture;
        } else if(step == new Vector2I(1, -1)) {
            Player.Instance.Texture = topRightPlayerTexture;
        } else if(step == new Vector2I(-1, 1)) {
            Player.Instance.Texture = bottomLeftPlayerTexture;
        } else if(step == new Vector2I(1, 1)) {
            Player.Instance.Texture = bottomRightPlayerTexture;
        }
    }
}