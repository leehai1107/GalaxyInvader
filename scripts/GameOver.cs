using Godot;
using System;

public partial class GameOver : Control
{
	private Label _scoreValueLabel;
	private Label _hightscoreValueLabel;

	private string SavePath = gc.SAVE_PATH;

	[Export]
	public GameStats gameStats;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_scoreValueLabel = GetNode<Label>("%ScoreValueLabel");
		_hightscoreValueLabel = GetNode<Label>("%HightscoreValueLabel");

		LoadHighScore();
		if (gameStats.Score > gameStats.HighScore)
		{
			gameStats.HighScore = gameStats.Score;
			SaveHighScore();
		}
		_scoreValueLabel.Text = gameStats.Score.ToString();
		_hightscoreValueLabel.Text = gameStats.HighScore.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			gameStats.Score = 0;
			GetTree().ChangeSceneToFile("res://sences/menu.tscn");
		}
	}

	private void LoadHighScore()
	{
		ConfigFile config = new();
		Error err = config.Load(SavePath);

		if (err != Error.Ok)
		{
			return;
		}
		gameStats.HighScore = (int)config.GetValue("game", "high_score", 0);
	}

	private void SaveHighScore()
	{
		ConfigFile config = new();
		config.SetValue("game", "high_score", gameStats.HighScore);
		config.Save(SavePath);

	}
}
