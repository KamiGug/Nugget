using Godot;
using System;

public partial class AbstractResource : AbstractComponent
{
    [Signal]
    public delegate void ResourceChangedEventHandler(int amount);
    [Signal]
    public delegate void ResourceDepletedEventHandler();
    [Export]
    public int Maximum { get; protected set; } = 10000;
    [Export]
    public int Current { get; protected set; } = -1;

    public override void _Ready()
    {
        base._Ready();
        if (Current < 0)
        {
            Current = Maximum;
        }
        else if (Current > Maximum)
        {
            Current = Maximum;
        }
    }

    public void Adjust(int amount)
    {
        this.Current = Current + amount;
        if (Current <= 0)
        {
            amount = Current * -1;
            Current = 0;
            EmitSignal(SignalName.ResourceDepleted);
        }
        else if (Current > Maximum)
        {
            amount -= Current - Maximum;
            Current = Maximum;
        }
        EmitSignal(SignalName.ResourceChanged, amount);
    }
}
