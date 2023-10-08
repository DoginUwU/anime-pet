
using System.Collections.Generic;
using GameScenes;
using Godot;

namespace Entities.Player;

public enum PlayerAnimationType {
    Idle,
    Walk,
}

#nullable enable
public class PlayerAnimation {
    public BasePlayerAnimation? animation = null;

    private static readonly IReadOnlyDictionary<PlayerAnimationType, BasePlayerAnimation> _animations = new Dictionary<PlayerAnimationType, BasePlayerAnimation>()
    {
        { PlayerAnimationType.Idle, new Animations.Idle() },
        { PlayerAnimationType.Walk, new Animations.Walk() },
    };

    public PlayerAnimation() {
        CallAnimation(PlayerAnimationType.Idle);
    }

    public void Process(double delta)
    {
        Vector2I step = GameController.Instance!.commonWindow!.normalizedCurrentStep;

        if(step != Vector2.Zero && animation is not Animations.Walk) {
            CallAnimation(PlayerAnimationType.Walk);
        } else if(step == Vector2.Zero && animation is not Animations.Idle) {
            CallAnimation(PlayerAnimationType.Idle);
        }

        animation?.Process(delta);
    }

    public void CallAnimation(PlayerAnimationType animationType)
    {
        if(_animations.ContainsKey(animationType))
        {
            animation = _animations[animationType];
            animation.Start();
        }
    }
}

public abstract class BasePlayerAnimation {
    public BasePlayerAnimation() {}

    public abstract void Start();

    public abstract void Process(double delta);
}