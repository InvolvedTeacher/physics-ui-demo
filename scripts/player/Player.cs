using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private float _speed = 400.0f;
	[Export] private float _jump_velocity = -600.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity += GetGravity() * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = _jump_velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("left", "right");
		if (direction == 0)
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _speed);
		else
			velocity.X = direction * _speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
