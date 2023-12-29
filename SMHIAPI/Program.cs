using SMHIAPI;
using System.Text.Json;

var client = new HttpClient();
var endpoint = new Uri("https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/16.158/lat/58.5812/data.json");
var result = client.GetAsync(endpoint).Result; 
var json = result.Content.ReadAsStringAsync().Result; 
var weather = JsonSerializer.Deserialize<Weather>(json);

if (weather != null)
{
    Console.WriteLine("This weather app will show you the weather please choose how many days you want to see \n");
    int.TryParse(Console.ReadLine(), out int answer);

    foreach (var forecast in weather.timeSeries)
    {
        for (global::System.Int32 i = 0; i < answer; i++)
        {
            
        
       
        
            if (forecast.validTime.Day - i == DateTime.Today.Day)
            {
                var dayofweek = forecast.validTime.DayOfWeek;
                var date = forecast.validTime.Day;
                var time = forecast.validTime.TimeOfDay;
                var unit = forecast.parameters[10].unit;
                var degree = forecast.parameters[10].values[0];
                Console.WriteLine(dayofweek + " " + date + " " + time + " " + degree + unit);
            }
        }

        //if (answer == 2)
        //{
        //    if (forecast.validTime.Day - 1 == DateTime.Today.Day)
        //    {
        //        var dayofweek = forecast.validTime.DayOfWeek;
        //        var date = forecast.validTime.Day;
        //        var time = forecast.validTime.TimeOfDay;
        //        var unit = forecast.parameters[10].unit;
        //        var degree = forecast.parameters[10].values[0];
        //        Console.WriteLine(dayofweek + " " + date + " " + time + " " + degree + unit);
        //    }
        //} 
        //if (answer == 3)
        //{
        //        var dayofweek = forecast.validTime.DayOfWeek;
        //        var date = forecast.validTime.Day;
        //        var time = forecast.validTime.TimeOfDay;
        //        var unit = forecast.parameters[10].unit;
        //        var degree = forecast.parameters[10].values[0];
        //        Console.WriteLine(dayofweek + " " + date + " " + time + " " + degree + unit);
        //}
    }
}



