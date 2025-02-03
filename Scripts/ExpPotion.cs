using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

public partial class ExpPotion : Item
{
	public override void Use(Player player)
	{	
		player._expValue += 50;
		player._expBar.Value = player._expValue;
		GD.Print("ExpPotion picked!");
		base.Use(player);
	}
}
