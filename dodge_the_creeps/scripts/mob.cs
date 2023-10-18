using Godot;
using System;
using DodgeTheCreeps;
public partial class mob : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.

	public AnimatedSprite2D AnimatedSprite2D;
	public override void _Ready()
	{
		this.GetChildNode(ref AnimatedSprite2D);
		var mob_animation = AnimatedSprite2D.SpriteFrames.GetAnimationNames();
		var index = GD_Extensions.Faker.Random.Int(0, mob_animation.Length - 1);
		AnimatedSprite2D.Animation =mob_animation[index] ;
		AnimatedSprite2D.Play();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnVisibleOnScreenEnabler2dScreenExited()
	{
		GD_Extensions.GD_Print("Exits !");
		QueueFree();
	}
}
