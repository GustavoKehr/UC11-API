using Chapter.WebApi.Contexts;
using ChapterBE10.WebApi.Interfaces;
using ChapterBE10.WebApi.Models;

namespace ChapterBE10.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ChapterContext _chapterContext;
        public UsuarioRepository(ChapterContext context)
        {
            _chapterContext = context;
        }
        public void Atualizar(int Id, Usuario usuario)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(Id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email= usuario.Email;
                usuarioBuscado.Senha= usuario.Senha;
                usuarioBuscado.Tipo= usuario.Tipo;
            }

            _chapterContext.Usuarios.Update(usuarioBuscado);
            _chapterContext.SaveChanges();
        }

        public Usuario BuscarPorId(int Id)
        {
            return _chapterContext.Usuarios.Find(Id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _chapterContext.Usuarios.Add(usuario);
            _chapterContext.SaveChanges();
        }

        public void Deleter(int Id)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(Id);
            _chapterContext.Usuarios.Remove(usuarioBuscado);
            _chapterContext.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _chapterContext.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
