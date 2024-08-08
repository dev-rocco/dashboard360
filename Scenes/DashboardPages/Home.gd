extends Control

var config = ResourceLoader.load(Global.CONFIG_PATH)
var in_submenu = false

func _unhandled_input(_event):
	if (Input.is_action_pressed("ui_cancel") && in_submenu):
		become_primary()
		give_focus()

func _on_steam_pressed():
	OS.execute(config.SteamLocation, PackedStringArray(["steam://open/bigpicture"]))
func _on_xbox_pressed():
	OS.execute(ProjectSettings.globalize_path("res://launch_xbox_app.bat"), PackedStringArray([config.XboxLocation]))
func _on_apps_pressed():
	for i in get_tree().get_nodes_in_group("HomePageButton"):
		i.focus_mode = FOCUS_NONE
	for i in get_tree().get_nodes_in_group("AppsPageButton"):
		i.focus_mode = FOCUS_ALL
	
	get_parent().get_parent().SwitchPrimary(get_node("AppsPage"))
	get_node("AppsPage").give_focus()
	in_submenu = true

func become_primary():
	for i in get_tree().get_nodes_in_group("HomePageButton"):
		i.focus_mode = FOCUS_ALL
	for i in get_tree().get_nodes_in_group("AppsPageButton"):
		i.focus_mode = FOCUS_NONE
	
	get_parent().get_parent().SwitchPrimary(self)
	in_submenu = false

func give_focus():
	get_node("Buttons/Left/PlayRecent").grab_focus()
