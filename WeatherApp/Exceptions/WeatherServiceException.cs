using System;

namespace WeatherApp.Exceptions
{
    [Serializable]
    public class WeatherServiceException : Exception
    {
        public WeatherServiceException(string message = null, Exception innerException = null) 
            : base(message, innerException)
        {
    
        }
    }
}