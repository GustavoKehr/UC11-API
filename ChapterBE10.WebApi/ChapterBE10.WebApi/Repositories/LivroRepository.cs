using Chapter.WebApi.Contexts;
using ChapterBE10.WebApi.Interfaces;
using ChapterBE10.WebApi.Models;

namespace ChapterBE10.WebApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        private readonly ChapterContext _chapterContext;
        public LivroRepository(ChapterContext context)
        {
            _chapterContext= context;   
        }
        public List<Livro> Ler()
        {
            return _chapterContext.Livros.ToList();
        }
    }
}
