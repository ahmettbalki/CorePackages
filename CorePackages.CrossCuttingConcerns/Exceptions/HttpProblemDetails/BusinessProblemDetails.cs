using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CorePackages.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Rule violation";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://google.com/business";
    }
}
