using EnterpriseWarehouse.API.DTO;
using EnterpriseWarehouse.Domain.Entities;

namespace EnterpriseWarehouse.API.Services;

public class OrganizationService : IEntityService<Organization, OrganizationCreateDTO, OrganizationDTO>
{
    private readonly List<Organization> _organizations = [];

    private int _id = 1;

    public List<Organization> GetAll() => _organizations;

    public Organization? GetById(int id) =>_organizations.FirstOrDefault(o => o.Id == id);

    public bool Add(OrganizationCreateDTO newOrganization)
    {
        var organization = new Organization
        {
            Id = _id++,
            Name = newOrganization.Name,
            Address = newOrganization.Address
        };
        _organizations.Add(organization);
        return true;
    }

    public bool Delete(int id)
    {
        var organization = GetById(id);
        if (organization == null)
        {
            return false;
        }
        _organizations.Remove(organization);
        return true;
    }

    public bool Update(OrganizationDTO updatedOrganization)
    {
        var organization = GetById(updatedOrganization.Id);
        if (organization == null)
        {
            return false;
        }
        organization.Address = updatedOrganization.Address;
        organization.Name = updatedOrganization.Name;
        return true;
    }
}
