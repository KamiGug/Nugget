using Godot;
using System;

public partial class HorizontalLineUIResourceBar : AbstractResourceBar
{
	private float startingMeterWidth;
	private Vector2 startingMeterPosition;
	private TextureRect meter;
	private TextureRect background;
	private TextureRect shadow;

	public override void _Ready()
	{
		base._Ready();
		Node candidate = this.GetNode("Meter");
		if (candidate is null)
		{
			GD.PrintErr("Missing \"Meter\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Meter\" sprite from " + this.Name + ".");
		}
		else if (candidate is TextureRect candidateSprite)
		{
			meter = candidateSprite;
		}
		else
		{
			GD.PrintErr("Missing \"Meter\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Meter\" sprite from " + this.Name + ".");
		}
		startingMeterWidth = meter.GetRect().Size.X;
		startingMeterPosition = meter.Position;

		candidate = this.GetNode("Background");
		if (candidate is null)
		{
			GD.PrintErr("Missing \"Background\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Background\" sprite from " + this.Name + ".");
		}
		else if (candidate is TextureRect candidateSprite)
		{
			background = candidateSprite;
		}
		else
		{
			GD.PrintErr("Missing \"Background\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Background\" sprite from " + this.Name + ".");
		}

		candidate = this.GetNode("Shadow");
		if (candidate is null)
		{
			GD.PrintErr("Missing \"Shadow\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Shadow\" sprite from " + this.Name + ".");
		}
		else if (candidate is TextureRect candidateSprite)
		{
			shadow = candidateSprite;
		}
		else
		{
			GD.PrintErr("Missing \"Shadow\" sprite from " + this.Name + ".");
			throw new Exception("Missing \"Shadow\" sprite from " + this.Name + ".");
		}
	}

	public override void handleNewToolbarValue(int amountChanged)
	{
		Vector2 newScale = new((float)ResourceComponent.Current / ResourceComponent.Maximum, 1);
		Vector2 newPosition = new(startingMeterPosition.X - (1 - newScale.X) * startingMeterWidth / 2, startingMeterPosition.Y);
		meter.Scale = newScale;
		meter.Position = newPosition;
	}
}
