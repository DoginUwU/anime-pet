using GameCommon;
using Godot;

namespace GameScenes;

#nullable enable
public partial class GameController : Node2D
{
	public static GameController? Instance { get; private set; }
	public CommonWindow? commonWindow;

	public override void _Ready()
	{
		Instance = this;
		commonWindow = new(GetWindow());
	}

    public override void _PhysicsProcess(double delta)
    {
		commonWindow?.Process(delta);
    }
}
