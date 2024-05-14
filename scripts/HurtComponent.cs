using Godot;
using System;

[GlobalClass]
public partial class HurtComponent : Node
{
	[Export]
	public StatsComponent _statsComponent;
	[Export]
	public HurtboxComponent _hurtboxComponent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// # Connect the hurt signal on the hurtbox component to an anonymous function
		// # that removes health equal to the damage from the hitbox
		_hurtboxComponent.Connect("hurt", new Callable(this, "hurtHandler"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void hurtHandler(HitboxComponent hitbox)
	{
		_statsComponent.Health -= (int)hitbox.damage;
		// GD.Print("Current health: " + _statsComponent.health);
		// GD.Print("Hitbox damage: " + hitbox.damage);
	}
}
