using GameCommon;
using GameScenes;
using Godot;

namespace Entities.Player.Actions;

public class RandomMove : BasePlayerAction
{
    public RandomMove() : base()
    {
    }

    public override void Start()
    {
        CommonWindow.GetRandomWindowPosition(out Vector2I newPosition);
        GameController.Instance?.commonWindow.MoveConstantWindow(newPosition.X, newPosition.Y);
    }

    public override void Process(double delta)
    {
        
    }
}