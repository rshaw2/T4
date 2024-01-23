using Microsoft.AspNetCore.Mvc;
using t4.Model;
using t4.Data;
using t4.Filter;

namespace t4.Controllers
{
    [Route("api/[controller]")]
    public class Offer4Controller : ControllerBase
    {
        private readonly t4Context _context;

        public Offer4Controller(t4Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Offer4 model)
        {
            _context.Offer4.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            var filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            var query = _context.Offer4.AsQueryable();
            var result = FilterService<Offer4>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        [HttpGet]
        [Route("{entityId}")]
        public IActionResult GetById([FromRoute] string entityId)
        {
            var entityData = _context.Offer4.FirstOrDefault(entity => entity.Id4 == entityId);
            return Ok(entityData);
        }

        [HttpDelete]
        [Route("{entityId}")]
        public IActionResult DeleteById([FromRoute] string entityId)
        {
            var entityData = _context.Offer4.FirstOrDefault(entity => entity.Id4 == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Offer4.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        [HttpPut]
        [Route("{entityId}")]
        public IActionResult UpdateById(string entityId, [FromBody] Offer4 updatedEntity)
        {
            if (entityId != updatedEntity.Id4)
            {
                return BadRequest("Mismatched Id4");
            }

            var entityData = _context.Offer4.FirstOrDefault(entity => entity.Id4 == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(Offer4).GetProperties().Where(property => property.Name != "Id4").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}