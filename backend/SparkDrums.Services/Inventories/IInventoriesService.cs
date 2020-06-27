using System.Collections.Generic;
using ServiceInventories = SparkDrums.Services.Models.Inventories;

namespace SparkDrums.Services.Inventories
{
    // ProductsService already has a CreateProductInventoryRecord
    public interface IInventoriesService
    {
        IEnumerable<ServiceInventories.ProductInventory> GetAllProductInventoryRecords();

        ServiceInventories.ProductInventory GetProductInventoryRecordById(int id);

        ServiceResponse<ServiceInventories.ProductInventory> DeleteProductInventoryRecord(int id);


        IEnumerable<ServiceInventories.ProductInventorySnapshot> GetAllProductInventorySnapshots();

        ServiceInventories.ProductInventorySnapshot GetProductInventorySnapshotById(int id);

        ServiceResponse<ServiceInventories.ProductInventorySnapshot> CreateProductInventorySnapshot(ServiceInventories.ProductInventorySnapshot snapshot);

        ServiceResponse<ServiceInventories.ProductInventorySnapshot> DeleteProductInventorySnapshot(int id);
    }
}
