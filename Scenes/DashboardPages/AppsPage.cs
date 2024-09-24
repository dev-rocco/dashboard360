using System;
using System.Drawing;
using Godot;

public partial class AppsPage : Control
{
	private Resource _config = GD.Load(Global.CONFIG_PATH);
	private PackedScene _animatedButtonPS = GD.Load<PackedScene>("res://Prefabs/AnimatedButton/AnimatedButton.tscn");
	private FileDialog _addAppDialog;
	
	public override void _Ready()
	{
		_addAppDialog = GetNode<FileDialog>("AddAppDialog");
	}

	public void GiveFocus()
	{
		Control firstNode = (Control)GetNode("Buttons").GetChildren()[0];
		firstNode.GrabFocus();
	}

	public void _on_add_app_pressed()
	{
		_addAppDialog.Visible = true;
	}
	public void _on_add_app_dialog_file_selected(string path)
	{
		GD.Print($"Adding app from path \"{path}\"");
		AnimatedButton newButton = _animatedButtonPS.Instantiate<AnimatedButton>();
		Node buttons = GetNode("Buttons");
		buttons.AddChild(newButton);
		buttons.MoveChild(newButton, 0);
		newButton.Text = path.Split("/")[path.Split("/").Length - 1];

		// Icon extractedIcon = Icon.ExtractAssociatedIcon(path);
		// Godot.Image extractedImage = (Godot.Image)extractedIcon.ToBitmap();
	}
}