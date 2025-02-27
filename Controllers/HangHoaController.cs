using GoodsAPI.Data;
using GoodsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HangHoaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangHoa>>> GetAll()
        {
            return await _context.Goods.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HangHoa>> GetById(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();
            return hangHoa;
        }

        [HttpPost]
        public async Task<ActionResult> Create(HangHoa hangHoa)
        {
            _context.Goods.Add(hangHoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = hangHoa.MaHangHoa }, hangHoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, HangHoa hangHoa)
        {
            if (id != hangHoa.MaHangHoa) return BadRequest();
            _context.Entry(hangHoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();
            _context.Goods.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}/update-note")]
        public async Task<ActionResult> UpdateGhiChu(string id, [FromBody] string ghiChu)
        {
            var hangHoa = await _context.Goods.FindAsync(id);
            if (hangHoa == null) return NotFound();
            hangHoa.GhiChu = ghiChu;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
