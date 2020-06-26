using System;

namespace SparkDrums.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }

        public T Data { get; set; }
    }
}
