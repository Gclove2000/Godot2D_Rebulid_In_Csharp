using Godot;
using System;
using GlowFor2d;
public partial class main : Node
{
	// Called when the node enters the scene tree for the first time.
	public WorldEnvironment WorldEnvironment;
	public Camera2D Camera2D;

	public override void _Ready()
	{
		GD_Extensions.GD_Print("Hello Godot!");
		this.GetChildNode(ref Camera2D);
		this.GetChildNode(ref WorldEnvironment);
        GD_Extensions.GD_Print("Hello Godot!");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
		
		if(@event is InputEventMouseMotion eventMouseMotion)
		{
			//Console.WriteLine("按钮事件");
			if(eventMouseMotion.ButtonMask > 0)
			{
				GD_Extensions.GD_Print("按钮点击事件");
				GD_Extensions.GD_Print(eventMouseMotion.Relative.X);
				Camera2D.Position = new Vector2(Camera2D.Position.X-eventMouseMotion.Relative.X,Camera2D.Position.Y);

            }
		}
		base._UnhandledInput(@event);
    }

}
