
using Godot;
using System;

public partial class Chest : Area2D
{
    [Export] private PackedScene[] _potions;
    private bool _playerInArea = false;

    public override void _Ready()
    {
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Player)
        {
            _playerInArea = true;
			GD.Print("Player entered the area");
        }
    }

    private void OnBodyExited(Node2D body)
    {
        if (body is Player)
        {
			GD.Print("Player exited the area");
            _playerInArea = false;
        }
    }

    public override void _Process(double delta)
    {
		if (_playerInArea)
        {
            GD.Print("Player is in the area");
        }
        if (_playerInArea && Input.IsActionJustPressed("interact"))
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {	
        Node2D node = _potions[new Random().Next(0, _potions.Length)].Instantiate<Node2D>();
		node.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(node);
		GD.Print("Chest opened!");
		GetParent().QueueFree();
    }
}