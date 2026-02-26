using Godot;
using System;

public partial class PhysicsUi : Control
{
	[Export] private RigidBody2D _box;
	[Export] private RigidBody2D _ball;
	[Export] private CharacterBody2D _player;

	private bool _is_menu_open;

	public override void _Ready()
	{
		if (_box is null)
			GD.PushError("[PhysicsUI] _box is null.");
		if (_ball is null)
			GD.PushError("[PhysicsUI] _ball is null.");
		if (_player is null)
			GD.PushError("[PhysicsUI] _player is null.");

		_is_menu_open = false;
		SetAnchorsPreset(LayoutPreset.LeftWide, true);
	}
	public override void _UnhandledKeyInput(InputEvent @event)
	{
		if (@event.IsActionPressed("menu"))
			ToggleMenu();
	}

	void ToggleMenu()
	{
		_is_menu_open = !_is_menu_open;
		GD.Print("[PhysicsUI] Toggling menu open: " + _is_menu_open);
		if (_is_menu_open)
			SetAnchorsPreset(LayoutPreset.RightWide, true);
		else
			SetAnchorsPreset(LayoutPreset.LeftWide, true);
	}

	void OnMassValueChanged(float new_value, string body_name)
	{
		switch (body_name)
		{
			case "box":
				_box.Mass = new_value;
				break;
			case "ball":
				_ball.Mass = new_value;
				break;
			default:
				break;
		}
	}

	void OnFrictionSliderValueChanged(float new_value, string body_name)
	{
		switch (body_name)
		{
			case "box":
				_box.PhysicsMaterialOverride.Friction = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Friction = new_value;
				break;
			default:
				break;
		}
	}

	void OnBounceSliderValueChanged(float new_value, string body_name)
	{
		switch (body_name)
		{
			case "box":
				_box.PhysicsMaterialOverride.Bounce = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Bounce = new_value;
				break;
			default:
				break;
		}
	}

	void OnAbsorbentToggled(bool new_value, string body_name)
	{
		switch (body_name)
		{
			case "box":
				_box.PhysicsMaterialOverride.Absorbent = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Absorbent = new_value;
				break;
			default:
				break;
		}
	}
}
