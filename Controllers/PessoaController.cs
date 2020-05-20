using System.Threading.Tasks;
using BaseApiEfDocker.Context;
using BaseApiEfDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseApiEfDocker.Controllers
{
    [ApiController]
    [Route("Pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly MSSQLContext context;
        private DbSet<Pessoa> pessoaCtx;
        
        public PessoaController(MSSQLContext context)
        {
            this.context = context;
            this.pessoaCtx = this.context.Set<Pessoa>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await pessoaCtx.ToListAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pessoa pessoa)
        {
            await pessoaCtx.AddAsync(pessoa);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}