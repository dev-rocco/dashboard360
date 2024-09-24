using System;
using Godot;

public partial class AnimatedButton : Button
{
    private bool _enlarged = false;
    [Export] private Vector2 _targetScale = new Vector2(1.1f, 1.1f);
    [Export] private float _scaleChangeSpeedMultiplier = 1f;
    private bool _buttonBeingHeld = false; // Used to prevent glitch caused by selecting another UI element while holding a button down

    private AnimationPlayer _anim;

    public override void _Ready()
    {
        PivotOffset = CustomMinimumSize / 2f;
        _anim = GetNode<AnimationPlayer>("AnimationPlayer");
        TextureRect shadow = GetNode<TextureRect>("Shadow");
        shadow.Position = Size / -10f;
    }
    public override void _Process(double delta)
    {
        // TODO: Only scale while current scale is not desired rather than every frame to save processing time. Not a huge issue right now but could cause performance issues when many buttons are present in the scene.
        // TODO: Explore whether tweens would be a better option than lerping for this use-case.
        // Also, devise a solution to scale the button without scaling the actual button node (while still providing easy access to its class functions) as directly changing the scale of UI elements seems to be discouraged.
        Scale = _enlarged ? Scale.Lerp(_targetScale, 10f * (float)delta * _scaleChangeSpeedMultiplier) : Scale = Scale.Lerp(new Vector2(1f, 1f), 10f * (float)delta * _scaleChangeSpeedMultiplier);
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

        // Properly revert scale if selected menu item is switched while select is held
        if (_buttonBeingHeld)
            _on_button_up();
    }

    public void _on_button_down()
    {
        _scaleChangeSpeedMultiplier *= 4.5f;
        _targetScale /= 1.3f;
        _buttonBeingHeld = true;
    }
    public void _on_button_up()
    {
        if (_buttonBeingHeld)
        {
            _scaleChangeSpeedMultiplier /= 4.5f;
            _targetScale *= 1.3f;
            _buttonBeingHeld = false;
        }
    }
}
