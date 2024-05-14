using Godot;
using System;

[GlobalClass]
public partial class HurtboxComponent : Area2D
{
	public bool IsInvincible
	{
		get => isInvincible;
		private set
		{
			isInvincible = value;
			foreach (var child in GetChildren())
			{
				if (child is not CollisionShape2D && child is not CollisionPolygon2D)
				{
					continue;
				}
				child.SetDeferred("disabled", IsInvincible);
			}
		}
	}

	private bool isInvincible;

	[Signal]
	public delegate void hurtEventHandler(Variant hitbox);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
