// ExcelController.cs

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[Route("api/excel")]
[ApiController]
public class ExcelController : ControllerBase
{
    private readonly DbContext _dbContext;

    public ExcelController(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("upload")]
    public IActionResult UploadExcel(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se proporcionó ningún archivo o el archivo está vacío.");
            }

            var clientesData = ProcessExcelFile(file);

            SaveDataToDatabase(clientesData);

            return Ok(new { Message = "Datos importados y almacenados exitosamente." });
        }
        catch (FormatException ex)
        {
            return StatusCode(500, $"Error de formato al procesar el archivo Excel: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    private List<Cliente> ProcessExcelFile(IFormFile file)
    {
        var clientesList = new List<Cliente>();

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            stream.Position = 0;

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.First();

                var headerRow = worksheet.Cells["A1:AH1"]
                    .Select(cell => cell.Text)
                    .ToList();

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var cliente = new Cliente();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        var property = typeof(Cliente).GetProperty(headerRow[col - 1]);

                        if (property != null)
                        {
                            var value = worksheet.Cells[row, col].Text;

                            // Manejar valores nulos o vacíos en la columna 'vendor'
                            if (property.Name == "vendor")
                            {
                                if (string.IsNullOrEmpty(value))
                                {
                                    // Puedes proporcionar un valor predeterminado o manejar de otra manera
                                    value = "ValorPorDefecto";
                                }
                            }

                            try
                            {
                                property.SetValue(cliente, Convert.ChangeType(value, property.PropertyType));
                            }
                            catch (Exception ex)
                            {
                                // Manejar el error de conversión aquí
                                Console.WriteLine($"Error al convertir '{value}' a {property.PropertyType.Name}: {ex.Message}");
                            }
                        }
                    }

                    clientesList.Add(cliente);
                }
            }
        }

        return clientesList;
    }

    private void SaveDataToDatabase(List<Cliente> clientesList)
    {
        try
        {
            _dbContext.Datos.AddRange(clientesList);
            _dbContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
            // Agrega más lógica de manejo de excepciones según sea necesario
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al guardar en la base de datos: {ex}");
            throw;
        }
    }
}
 