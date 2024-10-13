using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.API.Services;
using EnterpriseWarehouse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouse.API.Controllers;

/// <summary>
/// Контроллер для управления поставками.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController(SupplyService service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех поставок.
    /// </summary>
    /// <returns>Список всех поставок.</returns>
    /// <response code="200">Список успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<Supply>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Возвращает информацию о поставке по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор поставки.</param>
    /// <returns>Поставка с указанным идентификатором.</returns>
    /// <response code="200">Поставка найдена и возвращена успешно.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<Supply> Get(int id)
    {
        var supply = service.GetById(id);
        if (supply == null)
        {
            return NotFound();
        }
        return Ok(supply);
    }

    /// <summary>
    /// Добавляет новую поставку.
    /// </summary>
    /// <param name="newSupply">Информация о новой поставке.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="200">Поставка успешно добавлена.</response>
    /// /// <response code="404">Поставка не была добавлена.</response>
    [HttpPost]
    public ActionResult<Supply> Post(SupplyCreateDTO newSupply)
    {
        var result = service.Add(newSupply);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Обновляет информацию о существующей поставке.
    /// </summary>
    /// <param name="newSupply">Обновлённая информация о поставке.</param>
    /// <returns>Результат операции обновления.</returns>
    /// <response code="200">Поставка успешно обновлена.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
    [HttpPut]
    public ActionResult Put(SupplyDTO newSupply)
    {
        var result = service.Update(newSupply);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет поставку по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор поставки.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Поставка успешно удалена.</response>
    /// <response code="404">Поставка с указанным идентификатором не найдена.</response>
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
