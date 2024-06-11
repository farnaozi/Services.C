namespace Services.C.Core.Dtos
{
    public class ServiceResponse<T> : ServiceResponseBase
    {
        public T Data { get; set; }
    }
}
