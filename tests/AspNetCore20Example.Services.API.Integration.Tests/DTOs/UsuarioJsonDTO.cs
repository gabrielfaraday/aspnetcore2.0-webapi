namespace AspNetCore20Example.Services.API.Integration.Tests.DTOs
{
    public class UsuarioJsonDTO
    {
        public bool success { get; set; }
        public DataDTO data { get; set; }
    }

    public class DataDTO
    {
        public ResultDTO result { get; set; }
        public int id { get; set; }
        public object exception { get; set; }
        public int status { get; set; }
        public bool isCanceled { get; set; }
        public bool isCompleted { get; set; }
        public bool isCompletedSuccessfully { get; set; }
        public int creationOptions { get; set; }
        public object asyncState { get; set; }
        public bool isFaulted { get; set; }
    }

    public class ResultDTO
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public UserDTO user { get; set; }
    }

    public class UserDTO
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public ClaimDTO[] claims { get; set; }
    }

    public class ClaimDTO
    {
        public string type { get; set; }
        public string value { get; set; }
    }

}
