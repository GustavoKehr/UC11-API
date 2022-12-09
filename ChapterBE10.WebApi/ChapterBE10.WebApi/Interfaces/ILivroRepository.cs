using ChapterBE10.WebApi.Models;

namespace ChapterBE10.WebApi.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();
    }
}
