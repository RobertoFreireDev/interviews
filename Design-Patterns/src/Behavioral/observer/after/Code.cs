namespace after;

public static class Code
{
    public static void Run()
    {
        var heatDisplay = new HeatDisplay();
        var forecastDisplay = new ForecastDisplay();

        var weatherData =  new WeatherData();

        weatherData.RegisterObserver(heatDisplay);
        weatherData.RegisterObserver(forecastDisplay);
        weatherData.RemoveObserver(heatDisplay);
        weatherData.RegisterObserver(heatDisplay);

        float temperature = 74.00f;  
        float humidity = 45.13f;  
        float pressure = 29.92f;  

        weatherData.SetMeasurements(temperature, humidity, pressure);
    }
}

public interface ISubject {
	public void RegisterObserver(IObserver o);
	public void RemoveObserver(IObserver o);
	public void NotifyObservers();
}

public interface IObserver {
	public void Update(float temperature, float humidity, float pressure);
}

public class WeatherData : ISubject
{
    private float _temperature;
	private float _humidity;
	private float _pressure;
    private List<IObserver> _observers;

    public WeatherData() {
		_observers = new List<IObserver>();
	}

    public void SetMeasurements(float temperature, float humidity, float pressure) {
		_temperature = temperature;
		_humidity = humidity;
		_pressure = pressure;
		NotifyObservers();
	}

    public void RegisterObserver(IObserver o)
    {
        _observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        _observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in _observers) {
			observer.Update(_temperature, _humidity, _pressure);
		}
    }
}

public class HeatDisplay : IObserver
{
    public void Print(float temperature)
    { 
        Console.WriteLine("HeatDisplay");
        Console.WriteLine($"Temperature: {temperature}.");
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        Print(temperature);
    }
}

public class ForecastDisplay : IObserver
{
    public void Display(float temperature, float humidity, float pressure)
    { 
        Console.WriteLine("ForecastDisplay");
        Console.WriteLine($"Temperature: {temperature}. Humidity: {humidity}. Pressure: {pressure}.");
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        Display(temperature, humidity, pressure);
    }
}