using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Entities.Player;

public enum PlayerActionType
{
	RandomMove
}

#nullable enable
public class PlayerAction {
    public BasePlayerAction? currentAction = null;

    private static readonly IReadOnlyDictionary<PlayerActionType, BasePlayerAction> _actions = new Dictionary<PlayerActionType, BasePlayerAction>()
	{
		{ PlayerActionType.RandomMove, new Actions.RandomMove() }
	};

    public PlayerAction() {}

    public void Process(double delta) {
        currentAction?.Process(delta);
    }

    public void CallRandomAction()
	{
		currentAction = _actions.ElementAt((int)(GD.Randi() % _actions.Count)).Value;
		currentAction.Start();
	}

	public void CallAction(PlayerActionType action)
	{
		if(_actions.ContainsKey(action))
		{
			currentAction = _actions[action];
			currentAction.Start();
		}
	}
}

public abstract class BasePlayerAction {
    public BasePlayerAction() {}

    public abstract void Start();

    public abstract void Process(double delta);
}