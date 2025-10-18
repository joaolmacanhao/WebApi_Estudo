using System.Text.Json.Serialization;

namespace WebApi_Estudo.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Matutino,
        Vespertino,
        Noturno
    }
}
