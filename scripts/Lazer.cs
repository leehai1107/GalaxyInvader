using Godot;
using System;

public partial class Lazer : Node2D
{
	private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
	private ScaleComponent _scaleComponent;
	private FlashComponent _flashComponent;
	private HitboxComponent _hitboxComponent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		_scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
		_flashComponent = GetNode<FlashComponent>("FlashComponent");
		_hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");

		_scaleComponent.tween_scale();
		_flashComponent.flash();
		_visibleOnScreenNotifier2D.Connect("screen_exited", Callable.From(QueueFree));
		_hitboxComponent.Connect("hit_hurtbox", new Callable(this, "hitHandler"));

	}

	private void hitHandler(Variant any)
	{
		QueueFree();
	}

	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
}
