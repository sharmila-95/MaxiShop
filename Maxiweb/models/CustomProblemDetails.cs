using Microsoft.AspNetCore.Mvc;

namespace Maxiweb.models
{
    public class CustomProblemDetails:ProblemDetails
    {

        public IDictionary<string, string[]> Errors { get; set; }= new Dictionary<string, string[]>();
    }
}
