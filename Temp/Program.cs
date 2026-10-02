using System.Device.Gpio;

int pin = 22;

Console.WriteLine($"Using pin {pin}");

var gpio = new GpioController();
var dht11Reader = new Dht11Reader(pin);

try
{
    while (true)
    {
        var result = dht11Reader.ReadDht11();

        if (result != null)
        {
            var (humidity, temperature) = result.Value;

            var tempInFahrenheit = (temperature * 9 / 5) +32;

            //Console.WriteLine($"Temperature: { temperature}℃, Humidity: {humidity}%" );
            Console.WriteLine($"Temperature: {tempInFahrenheit}F, Humidity: {humidity}%" );
        }

        Thread.Sleep(1000);
    }
}
finally
{
    gpio.Dispose();
}