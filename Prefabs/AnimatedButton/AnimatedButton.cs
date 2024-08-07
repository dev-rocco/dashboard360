using Godot;
using System;

public partial class AnimatedButton : Button
{
    private bool _enlarged = false;
    [Export] private Vector2 _targetScale = new Vector2(1.1f, 1.1f);

    private AnimationPlayer _anim;

    public override void _Ready()
    {
        PivotOffset = CustomMinimumSize / 2f;
        _anim = GetNode<AnimationPlayer>("AnimationPlayer");
        TextureRect shadow = GetNode<TextureRect>("Shadow");
        // shadow.Size = CustomMinimumSize + (new Vector2(50f, 50f) * (CustomMinimumSize / new Vector2(200f, 200f)));
        shadow.Position = Size / -10f;
    }
    public override void _Process(double delta)
    {
        if (_enlarged)
            Scale = Scale.Lerp(_targetScale, 10f * (float)delta);
        else
            Scale = Scale.Lerp(new Vector2(1f, 1f), 10f * (float)delta);
    }

    public void _on_focus_entered()
    {
        _enlarged = true;
        _anim.Play("enlarge");
        ZIndex += 5;
    }
    public void _on_focus_exited()
    {
        _enlarged = false;
        _anim.Play("shrink");
        ZIndex -= 5;
    }
}
