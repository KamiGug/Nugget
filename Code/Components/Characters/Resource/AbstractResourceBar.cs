using Godot;
using System;

public abstract partial class AbstractResourceBar : AbstractComponent2D
{
    [Export]
    public AbstractResource ResourceComponent { get; set; } = null;
    public override void _Ready()
    {
        base._Ready();
        if (ResourceComponent is null)
        {
            GD.PrintErr("Unable to find the resource! Consider pointing to it in the Godot Editor.");
            throw new Exception("Unable to find the resource! Consider pointing to it in the Godot Editor.");
        }
        else if (ResourceComponent is AbstractResource)
        {
        }
        else
        {
            GD.PrintErr("Unable to find the resource! Consider pointing to it in the Godot Editor.");
            throw new Exception("Unable to find the resource! Consider pointing to it in the Godot Editor.");
        }
        ResourceComponent.ResourceChanged += this.handleNewToolbarValue;
    }

    public abstract void handleNewToolbarValue(int amountChanged);
}
