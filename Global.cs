using Godot;
using System;

public partial class Global : Node
{
    public static const string CONFIG_PATH = "user://config.dat";

    private const string[] _CONFIG_VAR_NAMES = { "OSWarnPrevent", "SteamLocation", "XboxLocation" };
    public static int GetConfigVarIndex(string name)
    {
        foreach (int i in _CONFIG_VAR_NAMES)
            if (i == name) return i;
        
        return -1;
    }
}
