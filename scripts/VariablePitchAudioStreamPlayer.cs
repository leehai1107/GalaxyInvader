using Godot;
using System;

[GlobalClass]
public partial class VariablePitchAudioStreamPlayer : AudioStreamPlayer
{
	[Export]
	public float minPitch = 0.6f;
	[Export]
	public float maxPitch = 1.2f;
	[Export]
	public bool autoPlayWithVariance = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (autoPlayWithVariance)
		{
			PlayWithVariance(0.0f);
		}
	}

	public void PlayWithVariance(float fromPosition = 0.0f)
	{
		PitchScale = (float)GD.RandRange(minPitch, maxPitch);
		Play(fromPosition);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
