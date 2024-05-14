using Godot;
using System;

public partial class gc : Node
{
	public static int margin = 8;
	// private static Variant _gameStats = GD.Load("res://globals/game_stats.tres");

	public static string SAVE_PATH = "user://savegame.cfg";
	public static string TEST_SAVE_PATH = "res://saves/savegame.cfg";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GrabageCollector();
	}

	private static void GrabageCollector()
	{
		GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
		GC.WaitForPendingFinalizers();
	}
}
