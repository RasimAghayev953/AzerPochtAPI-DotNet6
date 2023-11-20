using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzerPocht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzerPochtController : ControllerBase{

          
        private readonly DataPost _datapost;

        public AzerPochtController(DataPost datapost)
        {
            _datapost = datapost;
        }


        [HttpGet]
        public async Task<ActionResult<List<AzerPochtModel>>> Get()
        {
          
            return Ok(await _datapost.AzerPochtModels.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AzerPochtModel>> Get(int id)
        {
            var poct=await _datapost.AzerPochtModels.FindAsync(id);
            if (poct == null)
                return BadRequest("Tapilmadi");
            
            return Ok(poct);
        }


        [HttpPost]
        public async Task<ActionResult<List<AzerPochtModel>>> AddPost(AzerPochtModel poct) {
            _datapost.AzerPochtModels.Add(poct);
            await _datapost.SaveChangesAsync();

            return Ok(await _datapost.AzerPochtModels.ToListAsync());
             
        }
        [HttpPut]
        public async Task<ActionResult<List<AzerPochtModel>>> UpdatePost(AzerPochtModel request)
        {
            var dbPost = await _datapost.AzerPochtModels.FindAsync(request.Id);
            if (dbPost == null)
                return BadRequest("Tapilmadi");
            return BadRequest("Tapilmadi");
            dbPost.PostNum = request.PostNum;
            dbPost.PostPlace = request.PostPlace;
            await _datapost.SaveChangesAsync();

            return Ok(await _datapost.AzerPochtModels.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AzerPochtModel>> DeletePost(int id)
        {
            var dbPost = await _datapost.AzerPochtModels.FindAsync(id);
            if (dbPost == null)
                return BadRequest("Tapilmadi");
            _datapost.AzerPochtModels.Remove(dbPost);
            await _datapost.SaveChangesAsync();
            return Ok(await _datapost.AzerPochtModels.ToListAsync());
        }




    }
}
