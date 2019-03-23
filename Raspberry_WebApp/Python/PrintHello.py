import sys 
#import RPi.GPIO as gpio
#import time
import winsound
    
def PrintHello(): 
    #gpio.setmode(gpio.BCM)
    #gpio.setup(14, gpio.OUT)
    #for i in range(3):
    #    gpio.output(14, gpio.HIGH)
    #    time.sleep(.300)
    #    gpio.output(14, gpio.LOW)
    #    time.sleep(.500)
    #gpio.cleanup()
	frequency = 2500  # Set Frequency To 2500 Hertz
	duration = 1000  # Set Duration To 1000 ms == 1 second
	winsound.Beep(frequency, duration)
    return 'funcionou'

print(PrintHello())
