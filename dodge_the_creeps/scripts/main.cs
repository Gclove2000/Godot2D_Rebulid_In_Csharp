using Godot;
using System;
using DodgeTheCreeps;

public partial class main : Node
{
	// Called when the node enters the scene tree for the first time.
	public Timer ScoreTimer;
	public Timer MobTimer;

	[Export]
	public PackedScene MobSence { get; set; }

    public override void _Ready()
	{
		this.GetChildNode(ref ScoreTimer);
		this.GetChildNode(ref MobTimer);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnMobTimerTimeout()
	{
		//GD_Extensions.GD_Print("TimeOut!");

		var mob = MobSence.Instantiate();



	}
}
