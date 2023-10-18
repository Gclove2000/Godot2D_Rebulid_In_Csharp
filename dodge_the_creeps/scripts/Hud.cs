using Godot;
using System;
using DodgeTheCreeps;
using System.Threading.Tasks;

public partial class Hud : CanvasLayer
{
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

	public async Task ShowGameOver()
	{
		ShowMessage("Game Over!");
		await ToSignal(MessageTimer, "timeout");
		MessageLabel.Text = "Dodge the Creeps!";
		MessageLabel.Show();
        GD_Extensions.GD_Print("开始等待3s");
        await Task.Delay(3000);
		GD_Extensions.GD_Print("等待3s");
		StartButton.Show();
		//return Task.CompletedTask;
	}

	public async void  OnStartButtonPressed()
	{
        StartButton.Hide();
        await ShowGameOver();
        GD_Extensions.GD_Print("异步事件结束");
    }

    public void OnMessageTimerTimeout() { 

	}
}
