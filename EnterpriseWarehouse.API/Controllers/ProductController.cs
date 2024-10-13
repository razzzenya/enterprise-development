using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.API.Services;
using EnterpriseWarehouse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouse.API.Controllers;

/// <summary>
/// Контроллер для управления продуктами.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductService service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех продуктов.
    /// </summary>
    /// <returns>Список всех продуктов.</returns>
    /// <response code="200">Список успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Возвращает информацию о продукте по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Продукт с указанным идентификатором.</returns>
    /// <response code="200">Продукт найден и возвращён успешно.</response>
    /// <response code="404">Продукт с указанным идентификатором не найден.</response>
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = service.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    /// <summary>
    /// Добавляет новый продукт.
    /// </summary>
    /// <param name="newProduct">Информация о новом продукте.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="200">Продукт успешно добавлен.</response>
    /// /// <response code="404">Продукт не был добавлен.</response>
    [HttpPost]
    public ActionResult Post(ProductCreateDTO newProduct)
    {
        var result = service.Add(newProduct);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Обновляет информацию о существующем продукте.
    /// </summary>
    /// <param name="newProduct">Обновлённая информация о продукте.</param>
    /// <returns>Результат операции обновления.</returns>
    /// <response code="200">Продукт успешно обновлён.</response>
    /// <response code="404">Продукт с указанным идентификатором не найден.</response>
    [HttpPut]
    public ActionResult Put(ProductDTO newProduct)
    {
        var result = service.Update(newProduct);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Продукт успешно удалён.</response>
    /// <response code="404">Продукт с указанным идентификатором не найден.</response>
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
