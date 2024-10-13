using EnterpriseWarehouse.API.Services;
using EnterpriseWarehouse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouse.API.Controllers;

/// <summary>
/// Контроллер для управления ячейками склада.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CellController(CellService service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех ячеек склада.
    /// </summary>
    /// <returns>Список всех ячеек склада.</returns>
    /// <response code="200">Список успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<Cell>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Получает информацию о ячейке склада по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ячейки.</param>
    /// <returns>Ячейка склада с указанным идентификатором.</returns>
    /// <response code="200">Ячейка найдена и возвращена успешно.</response>
    /// <response code="404">Ячейка с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<Cell> Get(int id)
    {
        var cell = service.GetById(id);
        if (cell == null)
        {
            return NotFound();
        }
        return Ok(cell);
    }

    /// <summary>
    /// Добавляет новую ячейку на склад.
    /// </summary>
    /// <param name="newCell">Информация о новой ячейке.</param>
    /// <returns>Созданная ячейка склада.</returns>
    /// <response code="200">Ячейка успешно добавлена.</response>
    [HttpPost]
    public ActionResult<Cell> Post(Cell newCell)
    {
        return Ok(service.Add(newCell));
    }

    /// <summary>
    /// Обновляет информацию о существующей ячейке.
    /// </summary>
    /// <param name="newCell">Обновлённая информация о ячейке.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="200">Ячейка успешно обновлена.</response>
    /// <response code="404">Ячейка с указанным идентификатором не найдена.</response>
    [HttpPut]
    public ActionResult Put(Cell newCell)
    {
        var result = service.Update(newCell);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет ячейку склада по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор ячейки.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Ячейка успешно удалена.</response>
    /// <response code="404">Ячейка с указанным идентификатором не найдена.</response>
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
