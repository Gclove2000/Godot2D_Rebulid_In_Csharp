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
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if(@event is InputEventMouseMotion)
		{
			var new_event = (InputEventMouseMotion)@event;
			GD_Extensions.GD_Print(Camera2D.Position.X);
			Camera2D.Position.X = Mathf.Clamp(Camera2D.Position.X + new_event.Relative.X, -1000, 0);

		}
        base._UnhandledInput(@event);
    }

}
