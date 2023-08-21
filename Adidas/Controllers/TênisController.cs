using Adidas.Models;
using Adidas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adidas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TênisController : ControllerBase
    {
        private readonly TênisRepository _TênisRepository;
        public TênisController(TênisRepository TênisRepository)
        {
            _TênisRepository = TênisRepository;
        }
        [HttpGet]
        public IActionResult Listar() 
        {
            try
            {
                return Ok(_TênisRepository.Listar());
                    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorNome(int id) 
        {
            try
            {
                Tênis Tênis = _TênisRepository.BuscarPorNome(id);

                if(Tênis == null)
                {
                    return NotFound();
                }
                return Ok(Tênis);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Tênis tênis)
        {
            try
            {
                _TênisRepository.Cadastrar(tênis);
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
                _TênisRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception) 
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tênis tênis)
        {
            try
            {
                _TênisRepository.Atualizar(id, tênis);
                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
