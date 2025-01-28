
using Godot;
using System;

public partial class Chest : Item
{
    public PackedScene[] _potions;

    public override void Use()
    {
        Node2D node = _potions[new Random().Next(0, _potions.Length)].Instantiate<Node2D>();
		node.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(node);
		GD.Print("Chest opened!");
        base.Use();
    }
}