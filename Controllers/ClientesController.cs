using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly DbContext _dbContext;

    public ClientesController(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult ObtenerDatos()
    {
        var datos = _dbContext.Set<Clientes>().ToList();
        return Ok(datos);
    }
}
