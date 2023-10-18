using Godot;
using System;
using DodgeTheCreeps;
using Bogus;

public partial class main : Node
{
	// Called when the node enters the scene tree for the first time.
	public Timer ScoreTimer;
	public Timer MobTimer;
	public PathFollow2D MobPathFollow2D;


	[Export]
	public PackedScene MobSence { get; set; }

    public override void _Ready()
	{
		this.GetChildNode(ref ScoreTimer);
		this.GetChildNode(ref MobTimer);
		this.GetChildNode(ref MobPathFollow2D, "MobPath/"+nameof(MobPathFollow2D));
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnMobTimerTimeout()
	{
		//GD_Extensions.GD_Print("TimeOut!");
		//创建实体对象,默认返回是场景，我们需要改成父节点类型
		var mob = MobSence.Instantiate<mob>();

		//设置随机位置
		MobPathFollow2D.Progress = GD.Randi();

		//设置方向
		mob.Position = MobPathFollow2D.Position;
        GD_Extensions.GD_Print(MobPathFollow2D.Position);

        var direction = MobPathFollow2D.Rotation + Math.PI / 2;
		direction += GD_Extensions.Faker.Random.Double(-Math.PI/4,Math.PI/4);
		mob.Rotation = (float)direction;

		var vector =new Vector2(GD_Extensions.Faker.Random.Float(150,250),0);
		mob.LinearVelocity = vector.Rotated((float)direction);
		AddChild(mob);

    }
}
