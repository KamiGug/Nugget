using Godot;
using System;

public abstract partial class AbstractIngameEntity : CharacterBody2D
{
    public virtual void Destroy()
    {
        GD.Print("I, " + this.Name + ", am fallen");
    }
}
