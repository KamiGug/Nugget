using Godot;
using System;

public abstract partial class AbstractCharacter : AbstractIngameEntity
{
	[Export]
	public float WalkVelocity = 300.0f;
	[Export]
	public Vector2 DirectionVector = new(0, 0);

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Velocity.Lerp(DirectionVector * WalkVelocity, 0.5f);
		MoveAndSlide();
	}

	public override void Destroy()
	{
		GD.Print("I, the AbstractCharacter, " + this.Name + ", am fallen");
	}
}
