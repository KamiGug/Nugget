using System;
using System.Runtime.CompilerServices;
using Godot;


abstract public partial class AbstractComponent : Node
{
	// public Node Parent { get; set; }
	public override void _Ready()
	{
		Node candidate = this.GetParent();
		if (candidate is null)
		{
			GD.PrintErr("The " + this.Name + " component does not have a parent.");
			throw new Exception("The " + this.Name + " component does not have a parent.");
		}
		// if (candidate is AbstractIngameEntity)
		// {

		// }
		// else
		// {
		// 	Parent = candidate;
		// }
	}
}