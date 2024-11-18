namespace EnterpriseWarehouse.Wasm.Api;

public class EnterpriseWarehouseApiWrapper(IConfiguration configuration) : IEnterpriseWarehouseApiWrapper
{
    public readonly EnterpriseWarehouseApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ProductDTO> CreateProduct(ProductCreateDTO newProduct) => await _client.ProductPOSTAsync(newProduct);
    public async Task<CellDTO> CreateCell(CellCreateDTO newCell) => await _client.CellPOSTAsync(newCell);
    public async Task<OrganizationDTO> CreateOrganization(OrganizationCreateDTO newOrganization) => await _client.OrganizationPOSTAsync(newOrganization);
    public async Task<SupplyDTO> CreateSupply(SupplyCreateDTO newSupply) => await _client.SupplyPOSTAsync(newSupply);

    public async Task<ProductDTO> UpdateProduct(int id, ProductCreateDTO newProduct) => await _client.ProductPUTAsync(id, newProduct);
    public async Task<CellDTO> UpdateCell(int id, CellCreateDTO newCell) => await _client.CellPUTAsync(id, newCell);
    public async Task<OrganizationDTO> UpdateOrganization(int id, OrganizationCreateDTO newOrganization) => await _client.OrganizationPUTAsync(id, newOrganization);
    public async Task<SupplyDTO> UpdateSupply(int id, SupplyCreateDTO newSupply) => await _client.SupplyPUTAsync(id, newSupply);

    public async Task DeleteProduct(int id) => await _client.ProductDELETEAsync(id);
    public async Task DeleteCell(int id) => await _client.CellDELETEAsync(id);
    public async Task DeleteOrganization(int id) => await _client.OrganizationDELETEAsync(id);
    public async Task DeleteSupply(int id) => await _client.SupplyDELETEAsync(id);

    public async Task<IEnumerable<ProductDTO>> GetAllProducts() => await _client.ProductAllAsync();
    public async Task<IEnumerable<CellDTO>> GetAllCells() => await _client.CellAllAsync();
    public async Task<IEnumerable<OrganizationDTO>> GetAllOrganizations() => await _client.OrganizationAllAsync();
    public async Task<IEnumerable<SupplyDTO>> GetAllSupplies() => await _client.SupplyAllAsync();

    public async Task<ProductDTO> GetProduct(int id) => await _client.ProductGETAsync(id);
    public async Task<CellDTO> GetCell(int id) => await _client.CellGETAsync(id);
    public async Task<OrganizationDTO> GetOrganization(int id) => await _client.OrganizationGETAsync(id);
    public async Task<SupplyDTO> GetSupply(int id) => await _client.SupplyGETAsync(id);
}
