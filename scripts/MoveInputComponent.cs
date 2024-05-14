using Godot;
using System;

namespace GalaxyInvader.Component;
[GlobalClass]
public partial class MoveInputComponent : Node
{
	[Export]
	public MoveComponent moveComponent;
	[Export]
	public MoveStatsComponent moveStats;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }

	public override void _Input(InputEvent evnt)
	{
		float inputAxisX = Input.GetAxis("ui_left", "ui_right");
		float inputAxisY = Input.GetAxis("ui_up", "ui_down");
		moveComponent.velocity = new Vector2(inputAxisX * moveStats.speed, inputAxisY * moveStats.speed);
	}
}
