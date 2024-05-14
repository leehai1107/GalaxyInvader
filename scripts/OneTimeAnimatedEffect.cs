using Godot;
using System;

[GlobalClass]
[Tool]
public partial class OneTimeAnimatedEffect : AnimatedSprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// # Free this node when the animation is finished
		Connect("animation_finished", Callable.From(QueueFree));
		Connect("animation_looped", Callable.From(QueueFree));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
