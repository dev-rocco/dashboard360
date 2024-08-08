using Godot;
using System;

public partial class Dashboard360 : Control
{
	private HBoxContainer _pages;
	private HBoxContainer _pageNames;
	[Export] private Control _currentPrimary;

	private Camera2D _cam;

	public void SwitchPrimary(Control newPrimary)
	{
		_currentPrimary = newPrimary;
		_cam.GlobalPosition = _currentPrimary.GetNode<Control>("CameraTarget").GlobalPosition;
	}

	public override void _Ready()
	{
		_pages = GetNode<HBoxContainer>("Pages");
		_pageNames = GetNode<HBoxContainer>("StaticElements/PageNames");

		foreach (Node i in _pages.GetChildren())
		{
			Label newLabel = new Label();
			newLabel.Text = ((string)i.Name).ToLower();
			_pageNames.AddChild(newLabel);
		}

		_cam = GetNode<Camera2D>("Camera2D");
		_currentPrimary.Call("give_focus");
		_cam.ResetSmoothing();
	}

	// TODO:
	//	• Pause app when unfocused (https://www.reddit.com/r/godot/comments/bpmwf7/how_to_detect_if_game_lost_focus)
	//	• Grab window focus when Steam closes (https://forum.godotengine.org/t/how-to-grab-focus-in-the-running-project/47237)
}
