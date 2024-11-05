using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CorePackages.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(string detail)
    {
        Title = "Internal Server Error ";
        Detail = "Internal Server Error";
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://google.com/internal";
    }
}
