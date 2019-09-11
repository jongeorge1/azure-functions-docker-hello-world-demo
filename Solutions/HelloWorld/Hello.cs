namespace HelloWorldDemo
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;

    public static class HelloWorld
    {
        [FunctionName("Hello")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello")] HttpRequest req)
        {
            string name = null;

            if (req.Query.TryGetValue("name", out StringValues value))
            {
                name = value[0];
            }

            if (string.IsNullOrEmpty(name))
            {
                name = "World";
            }

            return new ContentResult
            {
                Content = "Hello, " + name,
                ContentType = "text/plain",
                StatusCode = 200,
            };
        }
    }
}
