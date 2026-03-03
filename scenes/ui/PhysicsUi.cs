using Godot;
using System;

public partial class PhysicsUi : Control
{
	[Export] private RigidBody2D _box;
	[Export] private Slider _box_mass_slider;
	[Export] private SpinBox _box_mass_spinbox;
	[Export] private Slider _box_friction_slider;
	[Export] private SpinBox _box_friction_spinbox;
	[Export] private Slider _box_bounce_slider;
	[Export] private SpinBox _box_bounce_spinbox;

	[Export] private RigidBody2D _ball;
	[Export] private Slider _ball_mass_slider;
	[Export] private SpinBox _ball_mass_spinbox;
	[Export] private Slider _ball_friction_slider;
	[Export] private SpinBox _ball_friction_spinbox;
	[Export] private Slider _ball_bounce_slider;
	[Export] private SpinBox _ball_bounce_spinbox;

	[Export] private Area2D _gravity_area;

	private bool _is_menu_open;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Amagar menu
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
		GD.Print("[PhysicsUI]: Menu toggled: " + _is_menu_open);
		if (_is_menu_open)
		{
			SetAnchorsPreset(LayoutPreset.RightWide, true);
		}
		else
		{
			SetAnchorsPreset(LayoutPreset.LeftWide, true);
		}
	}

	void OnMassChanged(float new_value, string body_selected)
	{
		switch (body_selected)
		{
			case "box":
				_box.Mass = new_value;
				_box_mass_slider.Value = new_value;
				_box_mass_spinbox.Value = new_value;
				break;
			case "ball":
				_ball.Mass = new_value;
				_ball_mass_slider.Value = new_value;
				_ball_mass_spinbox.Value = new_value;
				break;
			default:
				GD.PushWarning("[PhysicsUI] Warning: body name not recognised (" + body_selected + ").");
				break;
		}
	}

	void OnFrictionChanged(float new_value, string body_selected)
	{
		switch (body_selected)
		{
			case "box":
				_box.PhysicsMaterialOverride.Friction = new_value;
				_box_friction_slider.Value = new_value;
				_box_friction_spinbox.Value = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Friction = new_value;
				_ball_friction_slider.Value = new_value;
				_ball_friction_spinbox.Value = new_value;
				break;
			default:
				GD.PushWarning("[PhysicsUI] Warning: body name not recognised (" + body_selected + ").");
				break;
		}
	}

	void OnBounceChanged(float new_value, string body_selected)
	{
		switch (body_selected)
		{
			case "box":
				_box.PhysicsMaterialOverride.Bounce = new_value;
				_box_bounce_slider.Value = new_value;
				_box_bounce_spinbox.Value = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Bounce = new_value;
				_ball_bounce_slider.Value = new_value;
				_ball_bounce_spinbox.Value = new_value;
				break;
			default:
				GD.PushWarning("[PhysicsUI] Warning: body name not recognised (" + body_selected + ").");
				break;
		}
	}

	void OnAbsorbentToggled(bool new_value, string body_selected)
	{
		switch (body_selected)
		{
			case "box":
				_box.PhysicsMaterialOverride.Absorbent = new_value;
				break;
			case "ball":
				_ball.PhysicsMaterialOverride.Absorbent = new_value;
				break;
			default:
				GD.PushWarning("[PhysicsUI] Warning: body name not recognised (" + body_selected + ").");
				break;
		}
	}

	private void OnGravityAreaAccelerationChanged(float new_value)
	{
		_gravity_area.Gravity = new_value;
	}

	private void OnGravityAreaDirectionChanged(float new_value, bool x)
	{
		if (x)
			_gravity_area.GravityDirection = new Vector2(new_value, _gravity_area.GravityDirection.Y);
		else
			_gravity_area.GravityDirection = new Vector2(_gravity_area.GravityDirection.X, new_value);
	}
}
