using Godot;
using System;

[GlobalClass]
public partial class FlashComponent : Node
{
	[Export]
	public CanvasItem sprite;
	[Export]
	public Material flashMaterial;
	[Export]
	public float flashDuration = 0.2f;
	[Export]
	public Material defaultMaterial;

	private Timer _timer = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(_timer);

		defaultMaterial = sprite.Material;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public async void flash()
	{
		sprite.Material = flashMaterial;
		_timer.Start(flashDuration);

		await ToSignal(_timer, "timeout");

		sprite.Material = defaultMaterial;
	}
}
