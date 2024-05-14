using Godot;
using System;

public partial class PinkEnemyProjectile : Node2D
{
	private HitboxComponent _hitboxComponent;
	private ScaleComponent _scaleComponent;
	private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hitboxComponent = GetNode<HitboxComponent>("Anchor/HitboxComponent");
		_scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
		_visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");

		_scaleComponent.tween_scale();
		_visibleOnScreenNotifier2D.Connect("screen_exited", Callable.From(QueueFree));
		_hitboxComponent.Connect("hit_hurtbox", new Callable(this, "hitHandler"));
	}

	private void hitHandler(Variant any)
	{
		QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
