using System;
using System.Collections.Generic;
using Godot;

namespace Entities.Player;

public enum StatusLossMode
{
    automatic,
    manual
}

public enum StatusType
{
    health,
    hunger,
    thirst,
}

#nullable enable
public class Status
{
    public string name = "";
    public string formatedName = "";
    public StatusType type;
    public float value;
    public float maxValue;
    public float minValue;
    public StatusLossMode lossMode;
    public float? lossPerSecond;
    public Action? onValueChange;
    public Action? onReachMaxValue;
    public Action? onReachMinValue;
}

public class PlayerStats
{
    private readonly List<Status> _statuses = new() {
        new() {
            name = "health",
            formatedName = "Health",
            type = StatusType.health,
            value = 100f,
            maxValue = 100f,
            minValue = 0f,
            lossMode = StatusLossMode.manual,
        },
        new() {
            name = "hunger",
            formatedName = "Hunger",
            type = StatusType.hunger,
            value = 100f,
            maxValue = 100f,
            minValue = 0f,
            lossMode = StatusLossMode.automatic,
            lossPerSecond = 1
        },
        new() {
            name = "thirst",
            formatedName = "Thirst",
            type = StatusType.thirst,
            value = 100f,
            maxValue = 100f,
            minValue = 0f,
            lossMode = StatusLossMode.automatic,
            lossPerSecond = 1.5f
        }
    };

    public PlayerStats(Player player)
    {
        Timer timer = new()
        {
            Name = "UpdatePerSecond - PlayerStats",
            WaitTime = 1,
        };
        timer.Timeout += UpdatePerSecond;
        timer.Autostart = true;
        player.AddChild(timer);
    }

    public void Process(double delta)
    {

    }

    public List<Status> GetStatuses()
    {
        return _statuses;
    }

    public Status? GetStatus(StatusType type)
    {
        return _statuses.Find(status => status.type == type);
    }

    private void UpdatePerSecond()
    {
        foreach (Status status in _statuses)
        {
            if (status.lossMode == StatusLossMode.automatic && status.lossPerSecond != null)
            {
                float loss = status.lossPerSecond.Value;
                SetStatusValue(status.type, status.value - loss);
            }
        }
    }

    public bool SetStatusValue(Status status, float value)
    {
        status.value = Math.Clamp(value, status.minValue, status.maxValue);

        status.onValueChange?.Invoke();

        if(status.value == status.maxValue) {
            status.onReachMaxValue?.Invoke();
        } else if (status.value == status.minValue) {
            status.onReachMinValue?.Invoke();
        }

        return true;
    }

    public bool SetStatusValue(StatusType type, float value)
    {
        Status? status = GetStatus(type);

         if(status == null) return false;

        return SetStatusValue(status, value);
    }
}