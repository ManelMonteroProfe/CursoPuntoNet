using DemoProvinciasCrud.Data;
using DemoProvinciasCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProvinciasCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvinciasController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProvinciasController(AppDbContext db) => _db = db;

    // READ (todas): GET /api/provincias
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _db.Provincias
            .OrderBy(p => p.IdProvincia)
            .Select(p => new { idprovincia = p.IdProvincia, provincia = p.Nombre })
            .ToListAsync();

        return Ok(lista);
    }

    // READ (una): GET /api/provincias/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var p = await _db.Provincias.FindAsync(id);
        if (p is null) return NotFound(new { mensaje = "Provincia no encontrada" });

        return Ok(new { idprovincia = p.IdProvincia, provincia = p.Nombre });
    }

    // CREATE: POST /api/provincias
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProvinciaCreateDto dto)
    {
        if (dto.idprovincia <= 0) return BadRequest(new { mensaje = "El idprovincia debe ser > 0" });
        if (string.IsNullOrWhiteSpace(dto.provincia)) return BadRequest(new { mensaje = "La provincia es obligatoria" });

        var existe = await _db.Provincias.AnyAsync(x => x.IdProvincia == dto.idprovincia);
        if (existe) return Conflict(new { mensaje = "Ya existe una provincia con ese id" });

        var entidad = new Provincia { IdProvincia = dto.idprovincia, Nombre = dto.provincia.Trim() };

        _db.Provincias.Add(entidad);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = entidad.IdProvincia },
            new { idprovincia = entidad.IdProvincia, provincia = entidad.Nombre });
    }

    // UPDATE: PUT /api/provincias/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProvinciaUpdateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.provincia)) return BadRequest(new { mensaje = "La provincia es obligatoria" });

        var entidad = await _db.Provincias.FindAsync(id);
        if (entidad is null) return NotFound(new { mensaje = "Provincia no encontrada" });

        entidad.Nombre = dto.provincia.Trim();
        await _db.SaveChangesAsync();

        return Ok(new { idprovincia = entidad.IdProvincia, provincia = entidad.Nombre });
    }

    // DELETE: DELETE /api/provincias/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await _db.Provincias.FindAsync(id);
        if (entidad is null) return NotFound(new { mensaje = "Provincia no encontrada" });

        _db.Provincias.Remove(entidad);
        await _db.SaveChangesAsync();

        return NoContent(); // 204
    }
}
