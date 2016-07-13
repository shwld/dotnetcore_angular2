using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using core_angular2.Models;

namespace core_angular2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DefaultContext _Db { get; set; }
        public ValuesController(IOptions<ConfigData> optionsAccessor)
        {
            this._Db = DefaultContext.GetBy(optionsAccessor.Value.DefaultConnectionString);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var note = this._Db.Notes.First();
            return $"note: id={note.Id}, name={note.Name}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
