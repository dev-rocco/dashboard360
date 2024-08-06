extends Control

func _ready():
	print(OS.get_data_dir())

	get_node("Blackout").set_visible(true)
	get_node("OSWarnText/Label").set_text(get_node("OSWarnText/Label").text.replace("[OS]", OS.get_name()))

	# Check config for warn prevention
	var file
	if (!FileAccess.file_exists("user://config.dat")):
		file = FileAccess.open("user://config.dat", FileAccess.WRITE)
		file.store_8(0)
		file.close()
	file = FileAccess.open("user://config.dat", FileAccess.READ)


	# If warn prevention is false and operating system is not Windows, show OSWarnText before intro
	if (OS.get_name() != "Windows" && file.get_8() == 0):
		file.close()
		get_node("OSWarnText").set_visible(true)
		get_node("IntroGraphic").set_visible(false)
		get_node("AnimationPlayer").play("fadein")
	else:
		get_node("OSWarnText").set_visible(false)
		get_node("IntroGraphic").set_visible(true)
		get_node("AnimationPlayer").play("intro")

func end_intro():
	get_tree().change_scene_to_file("res://Scenes/Dashboard360.tscn")

func _on_prevent_warn_toggled(value):
	var file = FileAccess.open("user://config.dat", FileAccess.WRITE)
	file.store_8(value)
	file.close()
	print("Saved PreventWarn preference as "+str(value))

func _on_proceed_pressed():
	get_node("AnimationPlayer").play("fadetointro")
