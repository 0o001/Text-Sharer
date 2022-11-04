using System.Collections.Generic;
using System.Threading.Tasks;
using TextSharer.Models;

namespace TextSharer.Repository
{
    public interface ITextSharerRepository
    {
        Task<TextItem> GetByCodeAsync(string code);
        Task<TextItem> CreateAsync(TextItem text);
    }
}
