using Godot;
using System;

public partial class Item : Area2D
{
	public virtual void Use(Player player)
	{
		GetParent().QueueFree();
	}
}
