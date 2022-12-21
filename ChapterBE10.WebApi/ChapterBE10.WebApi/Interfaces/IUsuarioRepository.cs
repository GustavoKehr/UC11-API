using ChapterBE10.WebApi.Models;

namespace ChapterBE10.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        void Cadastrar(Usuario usuario);
        void Atualizar(int Id, Usuario usuario);
        void Deletar(int Id);
        Usuario BuscarPorId(int Id);
        //Usuario Login(string email, string senha);
    }


}
