using BulletShower;
using Godot;
using System;
using System.Collections.Generic;

public partial class Bullets : Node2D
{
	public readonly int Button_Count = 500;
	public readonly int Speed_min = 20;
	public readonly int Speed_max = 80;

	//public ImageTexture Bullet_Image = ResourceLoader.Load<ImageTexture>("res://bullet.png");
	public Texture2D Bullet_Image = new Texture2D();

	private List<Bullet> bullets = new List<Bullet>();
	public Rid Shape = new Rid();	


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Shape = PhysicsServer2D.CircleShapeCreate();
		PhysicsServer2D.ShapeSetData(Shape,8);
		Bullet_Image = GD.Load<Texture2D>("res://bullet.png");
        for (var i = 0; i < Button_Count; i++)
		{
			var model = new Bullet();
			model.speed = GD_Extension.Faker.Random.Int(Speed_min,Speed_max);
			model.body = PhysicsServer2D.BodyCreate();
			PhysicsServer2D.BodySetSpace(model.body,GetWorld2D().Space);
			PhysicsServer2D.BodyAddShape(model.body, Shape);
			PhysicsServer2D.BodySetCollisionMask(model.body,0);
			model.position = new Vector2(
				GD_Extension.Faker.Random.Float(0,GetViewportRect().Size.X+GetViewportRect().Size.Y),
				GD_Extension.Faker.Random.Float(0, GetViewportRect().Size.Y)
			);

			var transform2d = new Transform2D();
			transform2d.Origin = model.position;
			PhysicsServer2D.BodySetState(model.body,PhysicsServer2D.BodyState.Transform,transform2d);
			bullets.Add(model);

		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		QueueRedraw();
	}

    public override void _PhysicsProcess(double delta)
    {
		var transform2d = new Transform2D();
		var offset = GetViewportRect().Size.X + 16;
        foreach (var item in bullets)
        {
			item.position.X -= item.speed * (float)delta;
			if(item.position.X < -16)
			{
				item.position.X = offset;
			}

			transform2d.Origin = item.position;
			PhysicsServer2D.BodySetState(item.body, PhysicsServer2D.BodyState.Transform, transform2d);
        }

        base._PhysicsProcess(delta);	
    }

    public override void _Draw()
    {
		var offset = -Bullet_Image.GetSize();
		offset = offset /2;
		
        foreach (var item in bullets)
		{
			DrawTexture(Bullet_Image, item.position + offset);
		}
        base._Draw();
    }

    public override void _ExitTree()
    {
		foreach (var item in bullets)
		{
			PhysicsServer2D.FreeRid(item.body);
		}
		PhysicsServer2D.FreeRid(Shape);
        base._ExitTree();
    }
}


public class Bullet
{
    public Vector2 position = new Vector2();

    public float speed = 1.0f;

    public Rid body = new Rid();

}