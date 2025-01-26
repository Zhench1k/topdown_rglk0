using Godot;
using System;

public partial class ExpPotion : Area2D
{
	public void PotionPicked( Label _label, ref int _lvl)
	{
		_label.Text = $"Lvl: {++_lvl}";
		GD.Print("ExpPotion picked!");
	}
}
