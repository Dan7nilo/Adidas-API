using Adidas.Contexts;
using Adidas.Models;

namespace Adidas.Repositories
{
    public class TênisRepository
    {
        private readonly AdidasContext _context;
        public TênisRepository(AdidasContext context)
        {
            _context = context;
        }
        public List<Tênis> Listar()
        {
            return _context.Tênis.ToList();
        }
        public Tênis BuscarPorNome(int id)
        {
            return _context.Tênis.Find(id);
        }
        public void Cadastrar(Tênis tênis)
        {
            _context.Tênis.Add(tênis);
            _context.SaveChanges();
        }
        public void Deletar(int id)
        {
            Tênis tênis = _context.Tênis.Find(id);
            _context.Tênis.Remove(tênis);
            _context.SaveChanges();
        }
        public void Atualizar(int id,Tênis tênis)
        {
            Tênis Tênisbuscado = _context.Tênis.Find(id);
            if(Tênisbuscado != null)
            {
                Tênisbuscado.Nome = tênis.Nome;
                Tênisbuscado.Tamanho = tênis.Tamanho;
                Tênisbuscado.Disponivel = tênis.Disponivel;
            }
            _context.Tênis.Update(Tênisbuscado);
            _context.SaveChanges();
        }
    }
}
