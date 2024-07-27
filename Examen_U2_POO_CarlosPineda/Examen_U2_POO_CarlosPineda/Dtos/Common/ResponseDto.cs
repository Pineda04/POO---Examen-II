namespace Examen_U2_POO_CarlosPineda.Dtos.Common
{
    public class ResponseDto <T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public bool Status {  get; set; }
    }
}