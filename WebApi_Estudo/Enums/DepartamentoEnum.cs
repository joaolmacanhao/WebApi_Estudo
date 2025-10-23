using System.Text.Json.Serialization;

namespace WebApi_Estudo.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {

    Rh = 10,
    Financeiro = 20,
    Compras = 30,
    Atendimento = 40,
    Zeladoria = 50,
    Estagiario = 60
    }
}
