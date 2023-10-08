using Godot;

namespace GameScenes;

public partial class MenuButton : Button {
    [Export] public Menu menu = null!;
    [Export] public string callName = "";

    public override void _Ready() {
        this.Pressed += OnPressed;
    }

    public void OnPressed() {
        menu.Call(callName);
    }
}