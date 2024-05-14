using Godot;
using System.Diagnostics;

namespace GalaxyInvader.Component;
[GlobalClass]
public partial class SpawnerComponent : Node2D
{
	[Export]
	public PackedScene scene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }

	public Node spawn(Vector2 glbSpawnPosition, Node parent)
	{
		Debug.Assert(scene is PackedScene, "Error: The scene export was never set on this spawner component.");
		// # Instance the scene
		var instance = scene.Instantiate();
		// # Add it as a child of the parent
		parent.AddChild(instance);
		// # Update the global position of the instance.
		// # (This must be done after adding it as a child)
		instance.Set("global_position", glbSpawnPosition);
		// # Return the instance in case we want to perform any other operations
		// # on it after instancing it.
		return instance;
	}
}
