using System;
using System.Threading.Tasks;
using ATProject.TextSharer.API.Validator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TextSharer.Models;
using TextSharer.Services;

namespace TextSharer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextSharerController : ControllerBase
    {
        private readonly ITextSharerService _textSharerService;
        public readonly IRecaptchaValidator _recaptchaValidator;

        public TextSharerController(ITextSharerService textSharerService, IRecaptchaValidator recaptchaValidator)
        {
            _textSharerService = textSharerService;
            _recaptchaValidator = recaptchaValidator;

        }

        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            var textSharer = await _textSharerService.GetByCodeAsync(code).ConfigureAwait(false);
            if (textSharer == null)
            {
                return NotFound();
            }

            return Ok(textSharer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string text, string captchaResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_recaptchaValidator.IsRecaptchaValid(captchaResponse))
            {
                return BadRequest();
            }

            var textSharer = new TextItem(text);
            await _textSharerService.CreateAsync(textSharer).ConfigureAwait(false);

            return Ok(textSharer);
        }
    }
}
