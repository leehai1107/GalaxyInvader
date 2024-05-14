using Godot;
using System;

public partial class World : Node2D
{
	private Node2D _ship;
	private Label _scoreLabel;
	[Export]
	public GameStats _gameStats;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ship = GetNode<Node2D>("Ship");
		_scoreLabel = GetNode<Label>("ScoreLabel");

		_ship.Connect("tree_exiting", Callable.From(tree_exitingHandler));
		update_scoreLabel(_gameStats.Score);
		_gameStats.Connect("score_changed", new Callable(this, "update_scoreLabel"));
	}

	private async void tree_exitingHandler()
	{
		await ToSignal(GetTree().CreateTimer(0.5), "timeout");

		GetTree().ChangeSceneToFile("res://sences/game_over.tscn");
	}

	private void update_scoreLabel(int new_score)
	{
		_scoreLabel.Text = "Score: " + new_score;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
