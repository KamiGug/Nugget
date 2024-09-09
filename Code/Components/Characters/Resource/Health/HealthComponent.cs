using Godot;
using System;

public partial class HealthComponent : AbstractResource
{
	public override void _Ready()
	{
		base._Ready();
		Node candidateParent = this.GetParent();
		if (candidateParent is null)
		{
			throw new Exception(this.Name + " has no parent!");
		}
		if (candidateParent is AbstractIngameEntity entity)
		{
			this.ResourceDepleted += entity.Destroy; //Connect("HealthDepleted", Character.Destroy);
		}
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Debug_DealDamage"))
		{
			this.Adjust(-1000);
		}
		if (Input.IsActionJustPressed("Debug_HealDamage"))
		{
			this.Adjust(1000);
		}
	}
}
