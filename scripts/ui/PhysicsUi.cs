using Godot;
using System;

public partial class PhysicsUi : Control
{
	[Export] private RigidBody2D _box;

	private bool _is_menu_open;

	public override void _Ready()
	{
		if (_box is null)
			GD.PushError("[PhysicsUI] _box is null.");
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

	void OnMassValueChanged(float new_value)
	{
		_box.Mass = new_value;
	}

	void OnFrictionSliderValueChanged(float new_value)
	{
		_box.PhysicsMaterialOverride.Friction = new_value;
	}

	void OnBounceSliderValueChanged(float new_value)
	{
		_box.PhysicsMaterialOverride.Bounce = new_value;
	}

	void OnAbsorbentToggled(bool new_value)
	{
		_box.PhysicsMaterialOverride.Absorbent = new_value;
	}
}
