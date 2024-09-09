using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export]
	public Node2D FollowObject { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (FollowObject == null)
		{
			SetProcess(false);
			SetPhysicsProcess(false);
			GD.PrintErr("Camera is not following any Node");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Position = FollowObject.Position.Lerp(this.Position, 0.4f);
	}
}
