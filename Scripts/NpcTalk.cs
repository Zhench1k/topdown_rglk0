using Godot;
using System;

public partial class Conversation : Area2D
{
	public virtual void StartConversation(Player player)
	{
		GD.Print("Conversation started!");
	}
}
