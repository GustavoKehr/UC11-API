using ChapterBE10.WebApi.Models;

namespace ChapterBE10.WebApi.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();
        void Cadstrar(Livro livro); 
        void Atualizar(int id, Livro livro);
        void Deletar(int id);
        Livro BuscarPorId(int id);
        Livro BuscarPorTitulo(string titulo);
       
    }
}
