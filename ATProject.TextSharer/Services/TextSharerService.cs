using System.Collections.Generic;
using System.Threading.Tasks;
using TextSharer.Models;
using TextSharer.Repository;

namespace TextSharer.Services
{
    public class TextSharerService : ITextSharerService
    {
        private readonly ITextSharerRepository _textSharerRepository;

        public TextSharerService(ITextSharerRepository textSharerRepository)
        {
            _textSharerRepository = textSharerRepository;
        }

        public Task<TextItem> GetByCodeAsync(string code)
        {
            return _textSharerRepository.GetByCodeAsync(code);
        }

        public Task<TextItem> CreateAsync(TextItem text)
        {
            return _textSharerRepository.CreateAsync(text);
        }
    }
}
