using System.Device.Gpio;

Console.WriteLine("Blinking LED. Press Ctrl+C to end.");

int led = 17;
int button = 18;

Console.WriteLine($"UsingGPIO pin {led} for the LED.");
Console.WriteLine($"UsingGPIO pin {button} for the button.");

using var controller = new GpioController();

controller.OpenPin(button, PinMode.Input);
controller.OpenPin(led, PinMode.Output);

Console.WriteLine($"Is Led open: {controller.IsPinOpen(led)}");
Console.WriteLine($"Is Led mode supported: {controller.IsPinModeSupported(led, PinMode.Output)}");

Console.WriteLine($"Is button open: {controller.IsPinOpen(button)}");
Console.WriteLine($"Is button mode supported: {controller.IsPinModeSupported(button, PinMode.Input)}");

//Console.WriteLine($"IsPinModeSupported: {controller.IsPinModeSupported(led, PinMode.Output)}");

// pulling up the button to HIGH level  


Console.WriteLine();

bool ledOn = true;

while (true)
{
    if (controller.Read(button) == PinValue.Low)
        controller.Write(led, PinValue.High);
    else
        controller.Write(led, PinValue.Low);
}