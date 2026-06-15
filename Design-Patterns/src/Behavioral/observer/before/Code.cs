namespace before;

public static class Code
{
    public static void Run()
    {
        var heatDisplay = new HeatDisplay();
        var forecastDisplay = new ForecastDisplay();

        var weatherData =  new WeatherData(heatDisplay,forecastDisplay);

        float temperature = 74.00f;  
        float humidity = 45.13f;  
        float pressure = 29.92f;  

        weatherData.SetMeasurements(temperature, humidity, pressure);
    }
}

public class WeatherData
{
    private float _temperature;
	private float _humidity;
	private float _pressure;
    private HeatDisplay _heatDisplay;
	private ForecastDisplay _forecastDisplay;

    public WeatherData(
        HeatDisplay heatDisplay,
        ForecastDisplay forecastDisplay)
    {
        _heatDisplay = heatDisplay;
        _forecastDisplay = forecastDisplay;
    }

    public void SetMeasurements(float temperature, float humidity, float pressure) {
		_temperature = temperature;
		_humidity = humidity;
		_pressure = pressure;
		InformMeasurementsChanged();
	}

    public void InformMeasurementsChanged() {
		_heatDisplay.Print(_temperature);
        _forecastDisplay.Display(_temperature,_humidity,_pressure);
	}
}

public class HeatDisplay
{
    public void Print(float temperature)
    { 
        Console.WriteLine("HeatDisplay");
        Console.WriteLine($"Temperature: {temperature}.");
    }
}

public class ForecastDisplay 
{
    public void Display(float temperature, float humidity, float pressure)
    { 
        Console.WriteLine("ForecastDisplay");
        Console.WriteLine($"Temperature: {temperature}. Humidity: {humidity}. Pressure: {pressure}.");
    }
}