
using System.Text;

namespace CleanCrud.App.Services;

public partial class Client : IClient
{
    public HttpClient HttpClient
    {
        get
        {
            return _httpClient;
        }
    }

    private Task ProcessResponseAsync(HttpClient client_, HttpResponseMessage response_, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private Task PrepareRequestAsync(HttpClient client_, HttpRequestMessage request_, StringBuilder urlBuilder_, CancellationToken cancellationToken)
    {
        request_.Headers.Remove("Authorization");
        request_.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJkNTRmOTU2Yy05Yzk1LTQ1N2YtODQzYy1hZGNjNDdlNTIzNWUiLCJzdWIiOiJqY29zc2lvQHdmc2NvcnAuY29tIiwiZW1haWwiOiJqY29zc2lvQHdmc2NvcnAuY29tIiwidXNlcmlkIjoiamNvc3Npb0B3ZnNjb3JwLmNvbSIsIm5iZiI6MTcwNjA0MjgzMCwiZXhwIjoxNzA2MDcxNjMwLCJpYXQiOjE3MDYwNDI4MzAsImlzcyI6Imh0dHBzOi8vaWQuc2FtbXBsZS5jb20iLCJhdWQiOiJodHRwczovL3JlcHMuc2FtbXBsZS5jb20ifQ.CwLbCWaNQ3YMMnxdOPdAnyokB2ku40f5DhBNbXKSA3k");
        return Task.CompletedTask;
    }

    private Task PrepareRequestAsync(HttpClient client_, HttpRequestMessage request_, string url_, CancellationToken cancellationToken)
    {
        request_.Headers.Remove("Authorization");
        request_.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJkNTRmOTU2Yy05Yzk1LTQ1N2YtODQzYy1hZGNjNDdlNTIzNWUiLCJzdWIiOiJqY29zc2lvQHdmc2NvcnAuY29tIiwiZW1haWwiOiJqY29zc2lvQHdmc2NvcnAuY29tIiwidXNlcmlkIjoiamNvc3Npb0B3ZnNjb3JwLmNvbSIsIm5iZiI6MTcwNjA0MjgzMCwiZXhwIjoxNzA2MDcxNjMwLCJpYXQiOjE3MDYwNDI4MzAsImlzcyI6Imh0dHBzOi8vaWQuc2FtbXBsZS5jb20iLCJhdWQiOiJodHRwczovL3JlcHMuc2FtbXBsZS5jb20ifQ.CwLbCWaNQ3YMMnxdOPdAnyokB2ku40f5DhBNbXKSA3k");
        return Task.CompletedTask;
    }
}
