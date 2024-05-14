using Godot;
using System;

[GlobalClass]
[Tool]
public partial class GameStats : Resource
{
	[Export]
	public int Score
	{
		get => score; set
		{
			score = value;
			EmitSignal("score_changed", Score);
		}
	}

	[Export]
	public int HighScore = 0;
	[Signal]
	public delegate void score_changedEventHandler(int new_score);

	private int score = 0;

}
