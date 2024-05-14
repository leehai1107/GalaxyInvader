using Godot;
using System;

[GlobalClass]
public partial class StateComponent : Node
{
	[Signal]
	public delegate void enabledEventHandler();
	[Signal]
	public delegate void disabledEventHandler();
	[Signal]
	public delegate void state_finishedEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Enable()
	{
		EmitSignal("enabled");
		ProcessMode = ProcessModeEnum.Inherit;
	}

	public void Disable()
	{
		EmitSignal("disabled");
		ProcessMode = ProcessModeEnum.Disabled;
	}
}
