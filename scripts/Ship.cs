using GalaxyInvader.Component;
using Godot;
using System;

namespace GalaxyInvader.Entity;
public partial class Ship : Node2D
{
	private Marker2D _leftMuzzle;
	private Marker2D _rightMuzzle;
	private SpawnerComponent _spawner;
	private Timer _timer;
	private ScaleComponent _scaleComponent;
	private MoveComponent _moveComponent;
	private AnimatedSprite2D _animatedSprite2D;
	private AnimatedSprite2D _animatedSprite2DFlame;
	private VariablePitchAudioStreamPlayer _audioStreamPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_leftMuzzle = GetNode<Marker2D>("LeftMuzzle");
		_rightMuzzle = GetNode<Marker2D>("RightMuzzle");
		_spawner = GetNode<SpawnerComponent>("SpawnerComponent");
		_timer = GetNode<Timer>("FireRateTimer");
		_scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
		_moveComponent = GetNode<MoveComponent>("MoveComponent");
		_animatedSprite2D = GetNode<AnimatedSprite2D>("Anchor/AnimatedSprite2D");
		_animatedSprite2DFlame = GetNode<AnimatedSprite2D>("Anchor/AnimatedSprite2DFlame");
		_audioStreamPlayer = GetNode<VariablePitchAudioStreamPlayer>("VariablePitchAudioStreamPlayer");

		_timer.Connect("timeout", Callable.From(fireLasers));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		animateTheShip();
	}

	private void fireLasers()
	{
		_audioStreamPlayer.PlayWithVariance();
		_spawner.spawn(_leftMuzzle.GlobalPosition, GetParent());
		_spawner.spawn(_rightMuzzle.GlobalPosition, GetParent());
		_scaleComponent.tween_scale();
	}

	private void animateTheShip()
	{
		if (_moveComponent.velocity.X < 0)
		{
			_animatedSprite2D.Play("bank_left");
			_animatedSprite2DFlame.Play("bank_left");
		}
		else if (_moveComponent.velocity.X > 0)
		{
			_animatedSprite2D.Play("bank_right");
			_animatedSprite2DFlame.Play("bank_right");
		}
		else
		{
			_animatedSprite2D.Play("center");
			_animatedSprite2DFlame.Play("center");
		}
	}

}
