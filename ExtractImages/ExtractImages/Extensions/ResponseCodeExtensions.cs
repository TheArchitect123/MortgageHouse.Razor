using Microsoft.AspNetCore.Http;
using System;

namespace ExtractImages.Extensions
{
    public static class ResponseCodeExtensions
    {
        public static string ResponseCodeFormatter(this HttpResponse response)
        {
            if (Convert.ToString(response.StatusCode).StartsWith("4"))
                return $"An error has occurred with the resource being invoked, \n Response Code: {response.StatusCode}";
            else if (Convert.ToString(response.StatusCode).StartsWith("5"))
                return $"An error has occurred with the specified machine {System.Environment.MachineName} \n Response Code: {response.StatusCode}";

            return "Action has completed successfully";
        }
    }

}
