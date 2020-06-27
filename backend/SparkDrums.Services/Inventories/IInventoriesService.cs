using System.Collections.Generic;
using ServiceInventories = SparkDrums.Services.Models.Inventories;

namespace SparkDrums.Services.Inventories
{
    // ProductsService already has a CreateProductInventoryRecord
    public interface IInventoriesService
    {
        IEnumerable<ServiceInventories.ProductInventory> GetCurrentProductInventory();

        ServiceInventories.ProductInventory GetProductInventoryRecordById(int id);

        ServiceResponse<ServiceInventories.ProductInventory> DeleteProductInventoryRecord(int id);


        IEnumerable<ServiceInventories.ProductInventorySnapshot> GetSnapshotHistory();

        ServiceResponse<ServiceInventories.ProductInventory> UpdateQuantityAvailable(int id, int adjustment);

        void CreateProductInventorySnapshot();
    }
}
