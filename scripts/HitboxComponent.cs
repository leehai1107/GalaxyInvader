using Godot;
using System;

[GlobalClass]
public partial class HitboxComponent : Area2D
{
	[Export]
	public float damage = 1.0f;

	[Signal]
	public delegate void hit_hurtboxEventHandler(Variant hurtbox);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("area_entered", new Callable(this, "onHurtboxEntered"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onHurtboxEntered(HurtboxComponent hurtbox)
	{
		if (hurtbox is not HurtboxComponent)
		{
			return;
		}

		if (hurtbox.IsInvincible)
		{
			return;
		}

		EmitSignal("hit_hurtbox", hurtbox);

		hurtbox.EmitSignal("hurt", this);
	}
}
