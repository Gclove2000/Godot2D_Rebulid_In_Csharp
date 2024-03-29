using Godot;
using System;
using TileMap_isometric;
public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		var input_vector = GD_Extensions.GetMoveInput() * Speed;
		GD_Extensions.GD_Print(input_vector );
		//GD_Extensions.GD_Print(velocity);
		Velocity = input_vector;
		MoveAndSlide();
	}

    public override void _Ready()
    {
		GD_Extensions.GD_Print("项目实例化");
        base._Ready();
    }
}
