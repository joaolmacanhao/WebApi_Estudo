using System.Text.Json.Serialization;

namespace WebApi_Estudo.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {

    Rh,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria,
    Estagiario
    }
}
