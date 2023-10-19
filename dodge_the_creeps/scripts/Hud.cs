using Godot;
using System;
using DodgeTheCreeps;
using System.Threading.Tasks;

public partial class Hud : CanvasLayer
{

	[Signal]
	public delegate void StartGameEventHandler();

	public Label ScoreLabel;
	public Label MessageLabel;
	public Button StartButton;
	public Timer MessageTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.GetChildNode(ref ScoreLabel);
		this.GetChildNode(ref MessageLabel);
		this.GetChildNode(ref StartButton);
		this.GetChildNode(ref MessageTimer);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}


	public void ShowMessage(string text)
	{

		MessageLabel.Text = text;
		MessageLabel.Show();
		MessageTimer.Start();
	}

	public void ShowGameOver()
	{
        MessageTimer.Stop();

        MessageLabel.Text = "Game Over!";
		MessageLabel.Show();
	}

	public void SetSocre(int num)
	{
		ScoreLabel.Text = num.ToString();
	}

	public void  OnStartButtonPressed()
	{
		StartButton.Hide();
		EmitSignal(SignalName.StartGame);
    }

    public void OnMessageTimerTimeout() {
		MessageLabel.Hide();
	}
}
