using Godot;
using System;

public partial class ExpPotion : Item
{
	public Label _label;
	public int _lvl;
	public override void Use()
	{
		_label.Text = $"Lvl: {_lvl}";
		GD.Print("ExpPotion picked!");
		base.Use();
	}
}
