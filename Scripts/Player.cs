using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public int _lvl = 0;
    public int _healthValue = 100;
    public int _expValue = 0;
    public Item _currentItem;
    public Conversation _currentNpc;
    [Export] private AnimationPlayer _animationPlayer;
    [Export] public Sprite2D Sprite;
    [Export] public PackedScene[] _potions;
    [Export] public ProgressBar _healthBar;
    [Export] public ProgressBar _expBar;
    [Export] public Label _label;
    [Export] public float Speed = 200.0f;


    public override void _Ready()
    {
        _healthBar.Value = _healthValue;
        _expBar.Value = _expValue;
        _label.Text = $"Lvl: {_lvl}";
    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("right"))
        {
            Sprite.FlipH = true;
            velocity.X += 1;
        }
        if (Input.IsActionPressed("left"))
        {
            Sprite.FlipH = false;
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

        if (_currentItem != null && Input.IsActionJustPressed("interact"))
        {
            _currentItem.Use(this);
        }
        
        if (_currentNpc != null && Input.IsActionJustPressed("interact"))
        {
            _currentNpc.StartConversation(this);
        }
       

        if (velocity == Vector2.Zero)
        {
            if (!_animationPlayer.IsPlaying() || _animationPlayer.CurrentAnimation != "idle_breathe")
            {
                _animationPlayer.Play("idle_breathe");
            }
        }
        else
        {
            _animationPlayer.Stop();
        }
        if (_expValue == 100)
		{
			_expValue = 0;
			_expBar.Value = _expValue;
			_label.Text = $"Lvl: {++_lvl}";
		}
    }


    private void _OnAreaExited(Area2D area)
    {
        if (area is Item item)
        {
            _currentItem = null;
        }
        if (area is Conversation npc)
        {
            _currentNpc = null;
        }
    }


	public void _OnAreaEntered(Area2D area)
	{
        if (area is PotsNpc potsNpc)
        {
            _currentNpc = potsNpc;
        }
        else if (area is ExpPotion expPotion)
        {
            _currentItem = expPotion;
        }  
        else if (area is HealthPotion healthPotion)
        {
            _currentItem = healthPotion;
        }
        else if (area is Chest chest)
        {
            chest._potions = _potions;
            _currentItem = chest;
        } 
	}
}