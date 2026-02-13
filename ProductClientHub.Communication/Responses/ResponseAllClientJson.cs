namespace ProductClientHub.Communication.Responses
{
    public class ResponseAllClientJson
    {
        public List<ResponseShortClientJson> Clients { get; set; } = [];
        //usar array vazio para inicializar a lista é uma boa prática para evitar null reference exceptions
        //usar [] em vez de new List<ResponseShortClientJson>() é uma sintaxe mais concisa e moderna introduzida em C# 9.0
    }
}
