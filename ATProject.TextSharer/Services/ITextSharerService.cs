using System.Collections.Generic;
using System.Threading.Tasks;
using TextSharer.Models;

namespace TextSharer.Services
{
    public interface ITextSharerService
    {
        Task<TextItem> GetByCodeAsync(string code);
        Task<TextItem> CreateAsync(TextItem text);
    }
}
