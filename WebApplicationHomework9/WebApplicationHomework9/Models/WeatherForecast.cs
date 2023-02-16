namespace WebApplicationHomework9.Models
{
    /// <summary>
    /// Прогноз погоды
    /// </summary>
    public class WeatherForecast
    {

        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateTime Date { get; set; } // член класса, который
                                           // называется авто свойство
                                           // время измерения

        /*
        // Конструкция выше заменяет поля, методы и свойства из Java,
        // которые ниже
        private DateTime date;

        public DateTime GetDate()
        {
            return date;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }
        */

        /// <summary>
        /// Температура в градус Цельсия
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Температура в градус Форенгейта
        /// </summary>
        public int TemperatureF
        {
            get { return 32 + (int)(TemperatureC / 0.555); }
        }

        // Создадим конструктор для WeatherHolder
        public WeatherForecast(DateTime date, int temperatureC)
        {
            Date = date;
            TemperatureC = temperatureC;
        }
    }
}
