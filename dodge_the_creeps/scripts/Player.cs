using Godot;
using System;
using DodgeTheCreeps;
public partial class Player : Area2D
{
    public int Speed = 10;
    public AnimatedSprite2D AnimatedSprite2D;
    public Vector2 Size { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD_Extensions.GD_Print("Hello Godot!");
        this.GetChildNode(ref AnimatedSprite2D);
        Size =  GetViewportRect().Size;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var move = GD_Extensions.GetMoveInput();
        AnimatedSprite2D.Animation = "right";
        if(move.Length() > 0)
        {
            //GD_Extensions.GD_Print(GD_Extensions.GetMoveInput());
            AnimatedSprite2D.Play();
        }
        else
        {
            AnimatedSprite2D.Stop();

        }
        Position += move.Normalized()*Speed*(float)delta;
        Position = Position.Clamp(Vector2.Zero, Size);

    }


}
