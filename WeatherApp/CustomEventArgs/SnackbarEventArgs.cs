namespace WeatherApp.CustomEventArgs
{
    public class SnackbarEventArgs : System.EventArgs
    {
        public string Message { get; }

        public SnackbarEventArgs(string message)
        {
            Message = message;
        }
    }
}