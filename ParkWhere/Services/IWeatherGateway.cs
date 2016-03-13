using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkWhere.Services
{
    interface IWeatherGateway
    {
        string GetCurrentWeather(string location);
    }
}
