using Godot;
using System;

public partial class Item : Area2D
{
	public virtual void Use()
	{
		GetParent().QueueFree();
	}
}
