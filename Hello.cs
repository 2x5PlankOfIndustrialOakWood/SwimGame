using Godot;
using System;

public class Hello : Node2D
{
    public override void _Ready()
    {
        GD.Print("Hello World");
    }

    public override void _Process(float delta)
    {
        if(Input.IsActionPressed("ui_accept"))
        {
            GD.Print("Enter Pressed");
        }
    }
}
