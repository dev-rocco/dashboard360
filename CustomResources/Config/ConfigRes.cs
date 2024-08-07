using Godot;
using System;

public partial class ConfigRes : Resource
{
    [Export] public bool OSWarnPrevent = false;
    [Export] public string SteamLocation = "";
    [Export] public string XboxLocation = "";
}