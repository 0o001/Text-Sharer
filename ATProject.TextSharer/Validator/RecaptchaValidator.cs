using ATProject.TextSharer.API.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace ATProject.TextSharer.API.Validator
{
    public class RecaptchaValidator : IRecaptchaValidator
    {
        private const string GoogleRecaptchaAddress = "https://www.google.com/recaptcha/api/siteverify";

        public readonly IConfiguration Configuration;

        public RecaptchaValidator(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool IsRecaptchaValid(string token)
        {
            using var client = new HttpClient();
            var response = client.GetStringAsync($@"{GoogleRecaptchaAddress}?secret={Configuration["Google:SecretKey"]}&response={token}").Result;
            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

            return recaptchaResponse.Success;
        }

    }
}
