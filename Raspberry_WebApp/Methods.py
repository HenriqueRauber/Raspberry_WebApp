﻿import sys
import winsound

def PrintHello(): 
	frequency = 2500  # Set Frequency To 2500 Hertz
	duration = 1000  # Set Duration To 1000 ms == 1 second
	winsound.Beep(frequency, duration)
	print "Hello"

def HelloWorld():
	frequency = 2500  # Set Frequency To 2500 Hertz
	duration = 1000  # Set Duration To 1000 ms == 1 second
	winsound.Beep(frequency, duration)
	return "Hello World"