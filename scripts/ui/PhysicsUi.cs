using Godot;
using System;

public partial class PhysicsUi : Control
{
	private bool _is_menu_open;

	public override void _Ready()
	{
		_is_menu_open = false;
		SetAnchorsPreset(LayoutPreset.RightWide);
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
			SetAnchorsPreset(LayoutPreset.LeftWide, true);
		else
			SetAnchorsPreset(LayoutPreset.RightWide, true);
	}
}
