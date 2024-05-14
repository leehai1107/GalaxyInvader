using Godot;
using System;

[GlobalClass]
public partial class TimedStateComponent : StateComponent
{
	[Export]
	public float duration = 1.0f;

	private Timer _timer = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(_timer);
		_timer.Connect("timeout", Callable.From(OnTimeout));

		Connect("enabled", Callable.From(() => _timer.Start(duration)));

	}

	private void OnTimeout()
	{
		EmitSignal("state_finished");
		Disable();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
