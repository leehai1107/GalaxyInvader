using Godot;
using System;

public partial class SpaceBackground : ParallaxBackground
{
	private ParallaxLayer _spaceLayer;
	private ParallaxLayer _farStarsLayer;
	private ParallaxLayer _closeStarsLayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_spaceLayer = GetNode<ParallaxLayer>("%SpaceLayer");
		_farStarsLayer = GetNode<ParallaxLayer>("%FarStarsLayer");
		_closeStarsLayer = GetNode<ParallaxLayer>("%CloseStarsLayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_spaceLayer.SetIndexed("motion_offset:y", _spaceLayer.MotionOffset.Y + 2 * delta);
		_farStarsLayer.SetIndexed("motion_offset:y", _farStarsLayer.MotionOffset.Y + 5 * delta);
		_closeStarsLayer.SetIndexed("motion_offset:y", _closeStarsLayer.MotionOffset.Y + 20 * delta);
	}
}
