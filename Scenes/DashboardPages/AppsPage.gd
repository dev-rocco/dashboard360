extends Control

var config = ResourceLoader.load(Global.CONFIG_PATH)

func _on_add_app_pressed():
	# get_node("Buttons").add_child()
	pass

func give_focus():
	get_node("Buttons").get_children()[0].grab_focus()