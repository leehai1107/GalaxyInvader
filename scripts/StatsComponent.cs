using Godot;
using System;
using System.Dynamic;

[GlobalClass]
public partial class StatsComponent : Node
{
	[Export]
	public int Health
	{
		get => health;
		set
		{
			health = value;
			EmitSignal("health_change");
			// GD.Print("Current health: " + Health);
			if (Health <= 0)
			{
				EmitSignal("no_health");
				// GD.Print("Game over");
			}
		}
	}
	public int health = 1;

	[Signal]
	public delegate void health_changeEventHandler();
	[Signal]
	public delegate void no_healthEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
