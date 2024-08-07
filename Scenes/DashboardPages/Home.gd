extends Control

var config = ResourceLoader.load(Global.CONFIG_PATH)

func _on_steam_pressed():
	OS.execute(config.SteamLocation, PackedStringArray(["steam://open/bigpicture"]))

func _on_xbox_pressed():
	OS.execute(ProjectSettings.globalize_path("res://launch_xbox_app.bat"), PackedStringArray([config.XboxLocation]))

func become_primary():
	get_parent().get_parent().SwitchPrimary(self)

func give_focus():
	get_node("Buttons/Left/PlayRecent").grab_focus()
