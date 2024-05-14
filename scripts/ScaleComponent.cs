using Godot;
using System;

[GlobalClass]
public partial class ScaleComponent : Node
{
	[Export]
	public Node2D actor;
	[Export]
	public Vector2 scaleAmount = new Vector2(1.5f, 1.5f);
	[Export]
	public float scaleDuration = 0.4f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void tween_scale()
	{
		// # We are going to scale the sprite using a tween (so we can make is smooth)
		// # First we create the tween and set it's transition type and easing type
		Tween tween = GetTree().CreateTween().SetTrans(Tween.TransitionType.Expo).SetEase(Tween.EaseType.Out);

		// # Next we scale the sprite from its current scale to the scale amount (in 1/10th of the scale duration)
		tween.TweenProperty(actor, "scale", scaleAmount, scaleDuration * 0.1).FromCurrent();
		// # Finally we scale back to a value of 1 for the other 9/10ths of the scale duration
		// # Consider that we always scale back to a value of 1, you could store the starting scale amount for the sprite
		// # as well for games where your character doesn't start with a scale of 1
		tween.TweenProperty(actor, "scale", Vector2.One, scaleDuration * 0.9).From(scaleAmount);

	}

}
