using Godot;
using System;

[GlobalClass]
public partial class MoveComponent : Node
{
	[Export]
	public Node2D actor;
	[Export]
	public Vector2 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		actor.Translate(new Vector2(velocity.X * (float)delta, velocity.Y * (float)delta));
	}
}
