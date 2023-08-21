using Adidas.Interfaces;
using Adidas.Models;
using Adidas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adidas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iusuarioRepository.Listar());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuario = _iusuarioRepository.BuscarPorId(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _iusuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _iusuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _iusuarioRepository.Atualizar(id, usuario);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
