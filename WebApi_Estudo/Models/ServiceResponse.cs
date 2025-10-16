namespace WebApi_Estudo.Models
{
    public class ServiceResponse<T>//Classe genérica
    {
        public T? Data { get; set; } //indica que pode ser nulo
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
