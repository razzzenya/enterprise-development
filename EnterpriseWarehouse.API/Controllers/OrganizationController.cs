using EnterpriseWarehouse.API.Services;
using EnterpriseWarehouse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouse.API.Controllers;

/// <summary>
/// Контроллер для управления организациями.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrganizationController(OrganizationService service) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех организаций.
    /// </summary>
    /// <returns>Список всех организаций.</returns>
    /// <response code="200">Список успешно возвращён.</response>
    [HttpGet]
    public ActionResult<IEnumerable<Organization>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Возвращает информацию об организации по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор организации.</param>
    /// <returns>Организация с указанным идентификатором.</returns>
    /// <response code="200">Организация найдена и возвращена успешно.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<Organization> Get(int id)
    {
        var organization = service.GetById(id);
        if (organization == null)
        {
            return NotFound();
        }
        return Ok(organization);
    }

    /// <summary>
    /// Добавляет новую организацию.
    /// </summary>
    /// <param name="newOrganization">Информация о новой организации.</param>
    /// <returns>Созданная организация.</returns>
    /// <response code="200">Организация успешно добавлена.</response>
    [HttpPost]
    public ActionResult<Organization> Post(Organization newOrganization)
    {
        return Ok(service.Add(newOrganization));
    }

    /// <summary>
    /// Обновляет информацию о существующей организации.
    /// </summary>
    /// <param name="newOrganization">Обновлённая информация об организации.</param>
    /// <returns>Результат операции обновления.</returns>
    /// <response code="200">Организация успешно обновлена.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
    [HttpPut]
    public ActionResult Put(Organization newOrganization)
    {
        var result = service.Update(newOrganization);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет организацию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор организации.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="200">Организация успешно удалена.</response>
    /// <response code="404">Организация с указанным идентификатором не найдена.</response>
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
