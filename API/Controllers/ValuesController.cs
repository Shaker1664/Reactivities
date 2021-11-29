using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

        //POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(Value createValue)
        {
            var value = new Value()
            {
                Id = createValue.Id,
                Name = createValue.Name
            };

            _context.Values.Add(value);

            await _context.SaveChangesAsync();

            return Ok(value);
        }

        //PUT api/value/4
        [HttpPut("{id}")]
        public ActionResult Put(int id, Value editValue)
        {
            return Ok();
        }

    }
}