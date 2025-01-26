using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private int _lvl = 0;
    [Export] private Label _label;

    [Export]
    public float Speed = 200.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("right"))
        {
            velocity.X += 1;
        }
        if (Input.IsActionPressed("left"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("down"))
        {
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("up"))
        {
            velocity.Y -= 1;
        }

        velocity = velocity.Normalized() * Speed;
        Velocity = velocity;
        MoveAndSlide();
    }
	public void _PotionPicked(Area2D area)
	{
		_label.Text = $"Lvl: {++_lvl}";
		GD.Print("Potion picked!");	
	}
}