namespace Pon.Site.Net.Api.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(string mensaje, Exception ex)
        {
            Mensaje = mensaje;
            Error = ex.Message;
        }

        public string Mensaje { get; set; }
        public string Error { get; set; }
    }
}
