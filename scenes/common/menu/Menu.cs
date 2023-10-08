using Entities.Player;
using Godot;

namespace GameScenes;

#nullable enable
public partial class Menu : Window
{
	public static Menu? Instance { get; private set; }

	[Export] public VBoxContainer menuContainer = null!;

	private bool _isOpen = false;
	
	public override void _Ready()
	{
		Instance = this;
		GetWindow().Visible = _isOpen;

		PackedScene progressInput = GD.Load<PackedScene>("res://scenes/common/menu/progress_input.tscn");

		foreach(Status status in Player.Instance!.PlayerStats.GetStatuses())
		{
			Node progressNode = progressInput.Instantiate();
			progressNode.Name = status.name;
			progressNode.GetNode<Label>("Label").Text = status.formatedName;
			progressNode.GetNode<ProgressBar>("ProgressBar").Value = status.value;
			progressNode.GetNode<ProgressBar>("ProgressBar").MaxValue = status.maxValue;
			progressNode.GetNode<ProgressBar>("ProgressBar").MinValue = status.minValue;
			progressNode.GetNode<ProgressBar>("ProgressBar").Step = 1f;

			menuContainer.AddChild(progressNode);
		}
	}

	public override void _Process(double delta)
	{
		foreach(Status status in Player.Instance!.PlayerStats.GetStatuses())
		{
			Node progressNoode = menuContainer.GetNode(status.name);
			ProgressBar progressBar = progressNoode.GetNode<ProgressBar>("ProgressBar");
			progressBar.Value = status.value;
		}
	}

	public void CallRandomMove() {
		Player.Instance?.PlayerAction.CallAction(PlayerActionType.RandomMove);
	}

	public void CallTakeDamage() {
		Status health = Player.Instance?.PlayerStats.GetStatus(StatusType.health)!;
		Player.Instance?.PlayerStats.SetStatusValue(health, health.value - 10f);
	}

	public void OpenMenu(Vector2 position)
	{
		_isOpen = !_isOpen;

		if(_isOpen) {
			GetWindow().Position = (Vector2I)position;
		}

		GetWindow().Visible = _isOpen;
	}
}
