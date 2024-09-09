using Godot;
using System;

public partial class PlayerMovementComponent : AbstractComponent
{
	public AbstractCharacter Character { get; set; }
	public override void _Ready()
	{
		base._Ready();
		Node candidate = this.GetParent();
		if (candidate is null)
		{
			throw new Exception("Missing parent from " + this.Name + ".");
		}
		else if (candidate is AbstractCharacter candidateCharacter)
		{
			Character = candidateCharacter;
		}
		else
		{
			throw new Exception("Parent named " + candidate.Name + " of the " + this.Name + " is not an AbstractCharacter.");
		}
	}

	public override void _Process(double delta)
	{
		Vector2 tmpDirection =
		new Vector2
		(
			Input.GetActionStrength("PlayerRight") - Input.GetActionStrength("PlayerLeft"),
			Input.GetActionStrength("PlayerDown") - Input.GetActionStrength("PlayerUp")
		);
		if (tmpDirection != Vector2.Zero)
		{
			tmpDirection = tmpDirection.Normalized();
		}
		Character.DirectionVector = tmpDirection;
	}

	// public override void _PhysicsProcess(double delta)
	// {

	// }
}
