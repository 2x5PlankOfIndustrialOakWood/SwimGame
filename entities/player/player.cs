using Godot;
using System;

public class player : KinematicBody2D
{
    [Export] public int speed;
    [Export] public int decaySpeed;
    [Export] public int rotSpeed;

    public int rotationDir = 0;

    public Vector2 velocity = new Vector2();

    public void GetInput(float delta)
    {
        velocity = new Vector2();
        
        rotationDir = 0;

        if (Input.IsActionPressed("ui_up"))
        {
            velocity = new Vector2(0, -speed).Rotated(Rotation);
            
        }

        //if (Input.IsActionPressed("ui_down"))
        //{
        //    velocity.y += 1;
        //}

        if (Input.IsActionPressed("ui_left"))
        {
            rotationDir -= 1;
        }

        if (Input.IsActionPressed("ui_right"))
        {
            rotationDir += 1;
        }

        velocity = velocity.Normalized() * delta * speed;
    }
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        AnimatedSprite animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        GetInput(delta);
        Rotation += rotationDir * rotSpeed * delta;
        velocity = MoveAndSlide(velocity);

        if (velocity.Length() > 0)
        {
            animatedSprite.Play("flying");
        }
        else
        {
            animatedSprite.Set("flying", 0);
            animatedSprite.Stop();
        }
    }
}
