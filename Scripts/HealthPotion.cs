using Godot;
using System;

public partial class HealthPotion : Area2D
{
	public void PotionPicked(ProgressBar _healthBar, ref int _healthValue)
	{
		_healthValue += new Random().Next(5, 20);
		_healthBar.Value = _healthValue;
		GD.Print("HealthPotion picked!");
	}
}
