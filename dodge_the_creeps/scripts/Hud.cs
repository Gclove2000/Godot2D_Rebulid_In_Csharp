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
        //ShowMessage("Game Over!");
        //await ToSignal(MessageTimer, "timeout");
        //MessageLabel.Text = "Dodge the Creeps!";
        StartButton.Hide();
        //MessageLabel.Show();
		GD_Extensions.GD_Print("开始等待3s");
        await Task.Delay(3000);
		GD_Extensions.GD_Print("等待3s");
		//StartButton.Show();
		//return Task.CompletedTask;
	}

	public  async void  OnStartButtonPressed()
	{
        //MessageLabel.Show();

        GD_Extensions.GD_Print("异步事件开始");
        //await Task.Delay(1000 * 3);
        await ShowGameOver();
        GD_Extensions.GD_Print("异步事件结束");
        //StartButton.Hide();
        //GD_Extensions.GD_Print("异步事件开始");
        //ShowGameOver().Wait();
        //GD_Extensions.GD_Print("异步事件结束");
    }

    public void OnMessageTimerTimeout() { 

	}
}
