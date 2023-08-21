using Adidas.Models;
namespace Adidas.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Atualizar(int id, Usuario usuario);
        void Cadastrar(Usuario usuario);
        void Deletar(int id);
        void Login(string Email, string Senha);


    }
}
