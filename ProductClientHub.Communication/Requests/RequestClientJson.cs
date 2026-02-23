namespace ProductClientHub.Communication.Requests
{
    public class RequestClientJson
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        //para variveis int caso não seja passado valor, o default é 0
        public int Age { get; set; }
    }
}
