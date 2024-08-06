extends Control

func _ready():
	get_node("HBoxContainer/Left/PlayRecent").grab_focus()

func _on_steam_pressed():
	OS.execute("steam", PackedStringArray(["steam://open/bigpicture"]))
