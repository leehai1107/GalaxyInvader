using Godot;
using System;

[GlobalClass]
public partial class PositionClampComponent : Node
{
	[Export]
	public Node2D actor;
	[Export]
	public int margin = gc.margin;

	private int lefBorder = 0;
	private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
	private int topBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
	private int bottomBorder = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		actor.SetIndexed("global_position:x", Mathf.Clamp(actor.GlobalPosition.X, lefBorder + margin, rightBorder - margin));
		actor.SetIndexed("global_position:y", Mathf.Clamp(actor.GlobalPosition.Y, bottomBorder + margin, topBorder - margin));
	}
}
