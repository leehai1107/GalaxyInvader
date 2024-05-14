using Godot;
using System;

[GlobalClass]
public partial class ShakeComponent : Node
{
	[Export]
	public Node2D node;
	[Export]
	public float shakeAmount = 2.0f;
	[Export]
	public float shakeDuration = 0.4f;

	private float shake = 0.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		node.Position = new Vector2((float)GD.RandRange(-shake, shake), (float)GD.RandRange(-shake, shake));
	}

	public void tween_shake()
	{
		shake = shakeAmount;

		Tween tween = GetTree().CreateTween();

		tween.TweenProperty(this, "shake", 0.0f, shakeDuration).FromCurrent();
	}

}
