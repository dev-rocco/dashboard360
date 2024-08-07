using Godot;
using System;

public partial class ConfigRes : Resource
{
    [Export] public bool OSWarnPrevent = false;
    [Export] public string SteamLocation = "C:\\Program Files (x86)\\Steam\\steam.exe";
    [Export] public string XboxLocation = "C:\\Users\\rocco\\Desktop\\Xbox.lnk";
}