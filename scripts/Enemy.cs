using GalaxyInvader.Component;
using Godot;
using System;
public partial class Enemy : Node2D
{
	private MoveComponent _moveComponent;
	private StatsComponent _statsComponent;
	private ScaleComponent _scaleComponent;
	private FlashComponent _flashComponent;
	private ShakeComponent _shakeComponent;
	private HurtboxComponent _hurtboxComponent;
	private HitboxComponent _hitboxComponent;
	private DestroyedComponent _destroyedComponent;
	private ScoreComponent _scoreComponent;
	private VisibleOnScreenNotifier2D _visibleOnScreenNotifier2D;


	private Node _states;
	private StateComponent _fireState;
	private SpawnerComponent _projectileSpawnerComponent;

	private TimedStateComponent _moveDownState;
	private TimedStateComponent _moveSideState;
	private TimedStateComponent _pauseState;
	private MoveComponent _moveSideComponent;
	private VariablePitchAudioStreamPlayer _audioStreamPlayer;

	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		_moveComponent = GetNode<MoveComponent>("MoveComponent");
		_statsComponent = GetNode<StatsComponent>("StatsComponent");
		_scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
		_flashComponent = GetNode<FlashComponent>("FlashComponent");
		_shakeComponent = GetNode<ShakeComponent>("ShakeComponent");
		_hurtboxComponent = GetNode<HurtboxComponent>("HurtboxComponent");
		_hitboxComponent = GetNode<HitboxComponent>("HitboxComponent");
		_destroyedComponent = GetNode<DestroyedComponent>("DestroyedComponent");
		_scoreComponent = GetNode<ScoreComponent>("ScoreComponent");
		_visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		_audioStreamPlayer = GetNode<VariablePitchAudioStreamPlayer>("VariablePitchAudioStreamPlayer");

		_states = GetNode("States");

		_moveDownState = GetNode<TimedStateComponent>("%MoveDownState");
		_moveSideState = GetNode<TimedStateComponent>("%MoveSideState");
		_pauseState = GetNode<TimedStateComponent>("%PauseState");
		_moveSideComponent = GetNode<MoveComponent>("%MoveSideComponent");
		_fireState = GetNode<StateComponent>("%FireState");
		_projectileSpawnerComponent = GetNode<SpawnerComponent>("%ProjectileSpawnerComponent");



		// _scaleComponent.tween_scale();
		// _flashComponent.flash();
		// _shakeComponent.tween_shake();
		_visibleOnScreenNotifier2D.Connect("screen_exited", Callable.From(() => QueueFree()));
		_hurtboxComponent.Connect("hurt", new Callable(this, "hurtHandler"));
		_statsComponent.Connect("no_health", Callable.From(() => no_healthHandler(0)));
		_hitboxComponent.Connect("hit_hurtbox", new Callable(this, "hit_hurtboxHandler"));
		_moveComponent.velocity.X = GD.RandRange(-20, 20);


		// GD.Print("PinkEnemy name: " + this.Name);

		if (Name == "PinkEnemy")
		{

			foreach (StateComponent state in _states.GetChildren())
			{
				state.Disable();
			}

			_moveSideComponent.velocity.X = GD.RandRange(-20, 20);

			_moveDownState.Connect("state_finished", Callable.From(() => _moveSideState.Enable()));
			_moveSideState.Connect("state_finished", Callable.From(() => FireStateHandler()));
			_pauseState.Connect("state_finished", Callable.From(() => _moveDownState.Enable()));
			_fireState.Connect("state_finished", Callable.From(() => _pauseState.Enable()));

			_moveDownState.Enable();
		}
	}

	private void FireStateHandler()
	{
		_fireState.Enable();
		_scaleComponent.tween_scale();
		_projectileSpawnerComponent.spawn(GlobalPosition, GetParent());
		_fireState.Disable();
		_fireState.EmitSignal("state_finished");
	}

	private void hurtHandler(Variant any)
	{
		_scaleComponent.tween_scale();
		_flashComponent.flash();
		_shakeComponent.tween_shake();

		_audioStreamPlayer.PlayWithVariance();
	}

	private void hit_hurtboxHandler(Variant any)
	{
		_destroyedComponent.Destroy();
	}

	private void no_healthHandler(int adjustAmount)
	{
		_scoreComponent.AdjustScore(adjustAmount);
		// QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
