using Godot;
using System;

public partial class AnimatedButton : Button
{
    private bool _enlarged = false;
    [Export] private Vector2 _targetScale = new Vector2(1.1f, 1.1f);

    public override void _Ready()
    {
        PivotOffset = CustomMinimumSize / 2;
    }
    public override void _Process(double delta)
    {
        if (_enlarged)
            Scale = Scale.Lerp(_targetScale, 10f * (float)delta);
        else
            Scale = Scale.Lerp(new Vector2(1, 1), 10f * (float)delta);
    }

    public void _on_focus_entered()
    {
        _enlarged = true;
        ZIndex += 1;
    }
    public void _on_focus_exited()
    {
        _enlarged = false;
        ZIndex -= 1;
    }
}
