using GameCommon;
using Godot;

namespace GameScenes.Main;

public partial class Main : Node2D
{
	public override void _Ready()
	{
		CommonWindow.MakeTransparent(GetTree());
	}

	public override void _Process(double delta)
	{

	}
}
