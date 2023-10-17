using Godot;
using System;
using DodgeTheCreeps;
public partial class Player : Area2D
{
    public int Speed = 200;
    public AnimatedSprite2D AnimatedSprite2D;
    public Vector2 Size { get; set; }
    public Vector2 Move { get; set; } = new Vector2();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Move = GD_Extensions.GetMoveInput();

        GD_Extensions.GD_Print("Hello Godot!");
        this.GetChildNode(ref AnimatedSprite2D);
        Size =  GetViewportRect().Size;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        AnimatedSprite2D.FlipV = Move.Y > 0;
        AnimatedSprite2D.FlipH = Move.X < 0;
        var move = GD_Extensions.GetMoveInput();

        //AnimatedSprite2D.Animation = "right";
        if (move.Length() > 0)
        {
            Move = move;
            //GD_Extensions.GD_Print(GD_Extensions.GetMoveInput());
            AnimatedSprite2D.Play();
        }
        else
        {
            AnimatedSprite2D.Stop();

        }
        Position += move.Normalized()*Speed*(float)delta;
        Position = Position.Clamp(Vector2.Zero, Size);
        #region 控制图像翻转
        if (move.X != 0)
        {
            AnimatedSprite2D.Animation = "right";

        }else if(move.Y != 0)
        {
            AnimatedSprite2D.Animation = "up";
        }

        #endregion

    }


}
