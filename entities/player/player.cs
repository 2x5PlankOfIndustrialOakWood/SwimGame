using Godot;
using System;

public class player : KinematicBody2D
{
    [Export] public int speed;
    [Export] public int decaySpeed;
    [Export] public int rotSpeed;

    public Vector2 velocity = new Vector2();

    public void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.y -= 1;
        }

        if (Input.IsActionPressed("ui_down"))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed("ui_left"))
        {
            GD.Print("left");
        }

        if (Input.IsActionPressed("ui_right"))
        {
            GD.Print("right");
        }

        velocity = velocity.Normalized() * speed;
    }
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }
}
