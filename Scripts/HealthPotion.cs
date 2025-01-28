using Godot;
using System;

public partial class HealthPotion : Item
{
	public ProgressBar _healthBar;
	public int _healthValue;
	public override void Use()
	{
		_healthBar.Value = _healthValue;
		GD.Print("HealthPotion picked!");
		base.Use();
	}
}
