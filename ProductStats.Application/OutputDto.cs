namespace ProductStats.Application
{
    public class OutputDto<T> where T : class
    {
        public T Results { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}