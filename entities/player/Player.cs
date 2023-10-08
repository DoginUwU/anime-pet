using GameScenes;
using Godot;

namespace Entities.Player;

#nullable enable
public partial class Player : Sprite2D
{
	public PlayerAction PlayerAction { get; private set; } = null!;
	public PlayerAnimation PlayerAnimation { get; private set; } = null!;
	public PlayerStats PlayerStats { get; private set; } = null!;

	public static Player? Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		PlayerAction = new();
		PlayerAnimation = new();
		PlayerStats = new(this);
	}

	public override void _Process(double delta)
	{
		PlayerAction.Process(delta);
		PlayerAnimation.Process(delta);
		PlayerStats.Process(delta);
	}

    public override void _Input(InputEvent @event)
    {
        if(@event.GetType() == typeof(InputEventMouseButton))
		{
			InputEventMouseButton mouseEvent = (InputEventMouseButton)@event;
			if(mouseEvent.ButtonIndex == MouseButton.Right && mouseEvent.Pressed)
			{
				Menu.Instance?.OpenMenu(GetWindow().Position);
			}
		}
    }
}
