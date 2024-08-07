extends Control

var config

func _ready():
	print(OS.get_data_dir())

	get_node("Blackout").set_visible(true)
	get_node("OSWarnText/Label").set_text(get_node("OSWarnText/Label").text.replace("[OS]", OS.get_name()))

	# Check config for warn prevention
	if (!FileAccess.file_exists(Global.CONFIG_PATH)):
		config = load("res://CustomResources/Config/ConfigRes.cs").new()
		ResourceSaver.save(config, Global.CONFIG_PATH)
	else:
		config = ResourceLoader.load(Global.CONFIG_PATH)


	# If warn prevention is false and operating system is not Windows, show OSWarnText before intro
	if (OS.get_name() != "Windows" && config.OSWarnPrevent == false):
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
	config.OSWarnPrevent = value;
	ResourceSaver.save(config, Global.CONFIG_PATH)
	print("Saved PreventWarn preference as "+str(value))

func _on_proceed_pressed():
	get_node("AnimationPlayer").play("fadetointro")
