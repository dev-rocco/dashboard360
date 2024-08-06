using Godot;
using System;

public partial class Dashboard360 : Control
{
	private HBoxContainer _pages;
	[Export] private int _initialPageIndex = 0; // home page

	public override void _Ready()
	{
		_pages = GetNode<HBoxContainer>("Pages");
	}
}
