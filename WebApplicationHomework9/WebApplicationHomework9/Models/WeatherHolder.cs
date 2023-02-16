// Хранилище погоды
namespace WebApplicationHomework9.Models
{
    public class WeatherHolder
    {
        // Создадим коллекцию, где будут храниться данные о погоде
        private List<WeatherForecast> _values;

        // Далее создадим конструктор для инициализации коллекции
        public WeatherHolder()
        {
            _values = new List<WeatherForecast>();
        }

        // Далее создаём методы холдера
        /// <summary>
        /// Этот метод добавляет новые показания по температуре
        /// </summary>
        /// <param name="date">Дата фиксации показателя по
        ///                    температуре</param>
        /// <param name="temperatureC">Показатель температуры</param>
        public void Add(DateTime date, int temperatureC)
        {
            // Добавляем новый объект показатель по температуре
            _values.Add(new WeatherForecast(date, temperatureC));

        }

        // Если надо обновить данные по температуре создаём новый
        // метод
        /// <summary>
        /// Обновить показатель температуры
        /// </summary>
        /// <param name="date">Дата фиксации показания
        ///                    температуры</param>
        /// <param name="temperatureC">Новый показатель
        ///                            температуры</param>
        public void Update(DateTime date, int temperatureC)
        {
            foreach(WeatherForecast item in _values)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return;
                }
            }
        }

        // Создадим метод получения информации, когда нам необходимо
        // вернуть в коллекцию показатели нашей температуры
        /// <summary>
        /// Получить показатели температуры за временной период
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns></returns>
        public List<WeatherForecast> Get(DateTime dateFrom,
                                         DateTime dateTo)
        {
            /*
            // Обычный метод
            List<WeatherForecast> list = new List<WeatherForecast>();

            foreach (WeatherForecast item in _values)
            {
                if (item.Date >= dateFrom && item.Date <= dateTo)
                {
                    list.Add(item);
                }
            }

            return list;
            */

            // Воспользуемся здесь лямда выражением
            return _values.FindAll(item => item.Date >= dateFrom &&
                                   item.Date <= dateTo);
        }

        /// <summary>
        /// Задание
        /// Доработать метод Delete
        /// </summary>
        /// <param name="date">Дата которую нужно удалить</param>
        public void Delete(DateTime date)
        {
            foreach (WeatherForecast item in _values)
            {
                if (item.Date == date)
                {
                    _values.Remove(item);
                    return;
                }
            }
        }
    }
}
