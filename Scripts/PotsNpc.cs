using Godot;
using System;

public partial class PotsNpc : Conversation
{
	[Export] public AnimationPlayer _npcAnimation;

	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		_npcAnimation.Play("idle");
	}
	public override void StartConversation(Player player)
	{	
		player._expValue += 50;
		player._expBar.Value = player._expValue;
		GD.Print("ExpPotion gifted!");
		base.StartConversation(player);
	}
}
