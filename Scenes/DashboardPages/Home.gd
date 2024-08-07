extends Control

func _ready():
	get_node("Buttons/Left/PlayRecent").grab_focus()

func _on_steam_pressed():
	OS.execute("steam", PackedStringArray(["steam://open/bigpicture"]))
