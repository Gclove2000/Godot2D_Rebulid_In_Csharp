using BulletShower;
using Godot;
using System;

public partial class Player : Area2D
{
	// Called when the node enters the scene tree for the first time


	public int TouchCount = 0;
	public AnimatedSprite2D Animate;


    public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		this.GetChildNode(ref Animate);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

    public override void _Input(InputEvent @event)
    {
		if(@event is InputEventMouseMotion)
		{
			var mouseEvent = (@event as InputEventMouseMotion);
			Position = mouseEvent.Position;
		}
        base._Input(@event);
    }

	public void _on_body_shape_entered(Rid body_rid,Node2D body,int body_shape_index,int local_shape_index)
	{
		TouchCount++;
		if (TouchCount > 0)
		{
			Animate.Frame = 1;

        }
    }

	public void _on_body_shape_exited(Rid body_rid, Node2D body, int body_shape_index, int local_shape_index)
	{
        TouchCount--;
        if (TouchCount == 0)
        {
            Animate.Frame = 0;

        }
    }
}
