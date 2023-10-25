using Godot;
using System;
using SceneInstancingDemo;

public partial class BallFactory : Node
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public PackedScene Ball_Scene { get; set; }
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if (@event.IsEcho())
		{
			return;
		}
		if(@event is InputEventMouseButton inputEventMouseButton && @event.IsPressed())
		{
			GD_Extensions.GD_Print("鼠标点击");
			if(inputEventMouseButton.ButtonIndex == MouseButton.Left)
			{
				GD_Extensions.GD_Print("鼠标左键点击");
				var position = inputEventMouseButton.Position;
				AddBall(position);

            }
		}
        base._UnhandledInput(@event);	
    }

    private void AddBall(Vector2 pisition)
	{
		var model = Ball_Scene.Instantiate<RigidBody2D>();
		model.Position = pisition;


        AddChild(model);
	}
}
