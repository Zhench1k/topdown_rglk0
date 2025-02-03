using Godot;
using System;

public partial class HealthPotion : Item
{
	public ProgressBar _healthBar;
	public int _healthValue;
	public override void Use(Player player)
	{
		_healthValue += new Random().Next(5, 20);
        player._healthValue = _healthValue;
        player._healthBar = _healthBar;
		GD.Print("HealthPotion picked!");
		base.Use(player);
	}
}
