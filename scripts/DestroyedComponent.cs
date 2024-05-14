using GalaxyInvader.Component;
using Godot;
using System;

[GlobalClass]
public partial class DestroyedComponent : Node
{
	[Export]
	public Node2D actor;
	[Export]
	public StatsComponent _statsComponent;
	[Export]
	public SpawnerComponent _spawnerComponent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_statsComponent.Connect("no_health", Callable.From(Destroy));
	}

	public void Destroy()
	{
		// # create an effect (from the spawner component) and free the actor
		_spawnerComponent.spawn(actor.GlobalPosition, actor.GetParent());
		// GD.Print(actor.Name);
		actor.QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
