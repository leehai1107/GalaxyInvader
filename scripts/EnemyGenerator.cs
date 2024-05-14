using GalaxyInvader.Component;
using Godot;
using System;

public partial class EnemyGenerator : Node2D
{
	[Export]
	public PackedScene greenEnemyScene;
	[Export]
	public PackedScene yellowEnemyScene;
	[Export]
	public PackedScene pinkEnemyScene;

	[Export]
	public GameStats _gameStats;
	private Timer _greenEnemySpawnTimer;
	private Timer _yellowEnemySpawnTimer;
	private Timer _pinkEnemySpawnTimer;
	private SpawnerComponent _spawnerComponent;

	// Called when the node enters the scene tree for the first time.

	private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
	private int margin = gc.margin;


	public override void _Ready()
	{
		_greenEnemySpawnTimer = GetNode<Timer>("GreenEnemySpawnTimer");
		_yellowEnemySpawnTimer = GetNode<Timer>("YellowEnemySpawnTimer");
		_pinkEnemySpawnTimer = GetNode<Timer>("PinkEnemySpawnTimer");
		_spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");


		_greenEnemySpawnTimer.Connect("timeout", Callable.From(() => HandlerSpawn(greenEnemyScene, _greenEnemySpawnTimer)));
		_yellowEnemySpawnTimer.Connect("timeout", Callable.From(() => HandlerSpawn(yellowEnemyScene, _yellowEnemySpawnTimer, 3.0f)));
		_pinkEnemySpawnTimer.Connect("timeout", Callable.From(() => HandlerSpawn(pinkEnemyScene, _pinkEnemySpawnTimer, 7.0f)));

		_gameStats.Connect("score_changed", new Callable(this, "HandlerSpawnOnScoreChange"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void HandlerSpawnOnScoreChange(int new_score)
	{
		if (new_score > 10)
		{
			_yellowEnemySpawnTimer.ProcessMode = ProcessModeEnum.Inherit;
		}
		if (new_score > 50)
		{
			_pinkEnemySpawnTimer.ProcessMode = ProcessModeEnum.Inherit;
		}
	}

	public void HandlerSpawn(PackedScene enemyScene, Timer timer, float timeOffset = 1)
	{
		_spawnerComponent.scene = enemyScene;
		_spawnerComponent.spawn(new Vector2(GD.RandRange(margin, screenWidth - margin), -margin * 2), GetParent());
		var spawnRate = timeOffset / (0.5 + _gameStats.Score * 0.01f);

		timer.Start(spawnRate + GD.RandRange(0.25f, 0.5f));
	}
}
