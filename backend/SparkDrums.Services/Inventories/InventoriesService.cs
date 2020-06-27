using ServiceInventories = SparkDrums.Services.Models.Inventories;
using SparkDrums.Data.Readers.Inventories;
using SparkDrums.Data.Writers.Inventories;
using System.Collections.Generic;

namespace SparkDrums.Services.Inventories
{
    public class InventoriesService : IInventoriesService
    {
        private IInventoriesReader _inventoriesReader { get; set; }

        private IInventoriesWriter _inventoriesWriter { get; set; }

        public InventoriesService(IInventoriesReader inventoriesReader, IInventoriesWriter inventoriesWriter)
        {
            _inventoriesReader = inventoriesReader;
            _inventoriesWriter = inventoriesWriter;
        }

        public ServiceResponse<ServiceInventories.ProductInventorySnapshot> CreateProductInventorySnapshot(ServiceInventories.ProductInventorySnapshot snapshot)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<ServiceInventories.ProductInventory> DeleteProductInventoryRecord(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<ServiceInventories.ProductInventorySnapshot> DeleteProductInventorySnapshot(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceInventories.ProductInventory> GetAllProductInventoryRecords()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceInventories.ProductInventorySnapshot> GetAllProductInventorySnapshots()
        {
            throw new System.NotImplementedException();
        }

        public ServiceInventories.ProductInventory GetProductInventoryRecordById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceInventories.ProductInventorySnapshot GetProductInventorySnapshotById(int id)
        {
            throw new global::System.NotImplementedException();
        }
    }
}
