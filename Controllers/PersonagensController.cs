using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            _appDbcontext.DBZ.Add(personagem);
            await _appDbcontext.SaveChangesAsync();

            return Ok(personagem);
        }

        [HttpGet]

        public async Task<IActionResult> GetPersonagens()
        {
            var personagens = await _appDbcontext.DBZ.ToListAsync();

            if (personagens == null || !personagens.Any())
                return NotFound("Nenhum personagem encontrado.");

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonagemById(int id)
        {
            var personagem = await _appDbcontext.DBZ.FindAsync(id);

            if (personagem == null)
                return NotFound($"Personagem com ID {id} não encontrado.");

            return Ok(personagem);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatePersonagem(int id, Personagem personagem)
        {
            if (id != personagem.Id)
                return BadRequest("ID do personagem não corresponde.");

            var personagemExistente = await _appDbcontext.DBZ.FindAsync(id);
            if (personagemExistente == null)
                return NotFound($"Personagem com ID {id} não encontrado.");

            // Atualiza os campos necessários
            personagemExistente.Nome = personagem.Nome;
            personagemExistente.Poder = personagem.Poder;
            personagemExistente.Raca = personagem.Raca;
            // Adicione outros campos conforme necessário

            _appDbcontext.Entry(personagemExistente).State = EntityState.Modified;
            await _appDbcontext.SaveChangesAsync();

            return Ok(personagemExistente);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbcontext.DBZ.FindAsync(id);
            if (personagem == null)
                return NotFound($"Personagem com ID {id} não encontrado.");

            _appDbcontext.DBZ.Remove(personagem);
            await _appDbcontext.SaveChangesAsync();

            return Ok($"Personagem com ID {id} deletado com sucesso.");
        }
    }
}