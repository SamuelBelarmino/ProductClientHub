namespace ProductClientHub.Communication.Responses
{
    public class ResponseErrorMensagesJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMensagesJson(String menssage)
        {
            Errors = new List<string> { menssage };
            //Errors = [menssage]; => construtor de lista simplificado do C# 12
        }

        public ResponseErrorMensagesJson(List<string> menssages)
        {
            Errors = menssages;
        }
    }
}
