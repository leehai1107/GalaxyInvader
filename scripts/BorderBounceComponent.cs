using GalaxyInvader.Component;
using Godot;
using System;
using System.ComponentModel;

[GlobalClass]
public partial class BorderBounceComponent : Node
{
	[Export]
	public int margin = gc.margin;
	[Export]
	public Node2D actor;
	[Export]
	public MoveComponent _moveComponent;

	private int lefBorder = 0;
	private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// # If the actor's x position is less than the left border plus the margin,
		// # bounce off the left side of the screen
		if (actor.GlobalPosition.X < lefBorder + margin)
		{
			// # Prevent the actor for going past the border + the margin
			actor.Set("global_position:x", lefBorder + margin);
			// # When bouncing we use the .bounce function which takes a wall normal
			// # This wall normal is the direction of the face of the wall
			// # (it's a bit counter intuitive but a wall on the left would have a wall face with a normal of RIGHT)
			_moveComponent.velocity = _moveComponent.velocity.Bounce(Vector2.Right);
		}
		else if (actor.GlobalPosition.X > rightBorder - margin)
		/*# If the actor's x position is greater than the right border plus the margin,
	# bounce off the right side of the screen */
		{
			// # Prevent the actor for going past the border + the margin
			actor.Set("global_position:x", rightBorder - margin);
			// # When bouncing we use the .bounce function which takes a wall normal
			// # This wall normal is the direction of the face of the wall
			// # (it's a bit counter intuitive but a wall on the left would have a wall face with a normal of RIGHT)
			_moveComponent.velocity = _moveComponent.velocity.Bounce(Vector2.Left);

		}
	}
}
