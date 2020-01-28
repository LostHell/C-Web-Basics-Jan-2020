namespace SIS.HTTP
{
    public enum HttpResponseCode
    {
        OK = 200,
        MovedPermanently = 301,
        TemporaryRedirect = 307,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501
    }
}