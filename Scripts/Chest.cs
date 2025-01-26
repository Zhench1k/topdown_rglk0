using Godot;
using System;

public partial class Chest : Area2D
{
	[Export] private PackedScene[] _potions;
	public void OpenChest()
	{	
		Node2D node = _potions[new Random().Next(0, _potions.Length)].Instantiate<Node2D>();
		node.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(node);
		GD.Print("Chest opened!");
		GetParent().QueueFree();
	}
}
