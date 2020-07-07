using ServiceInventories = SparkDrums.Services.Models.Inventories;
using SparkDrums.Data.Readers.Inventories;
using SparkDrums.Data.Writers.Inventories;
using System.Collections.Generic;
using SparkDrums.Services.Serialisation;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace SparkDrums.Services.Inventories
{
    public class InventoriesService : IInventoriesService
    {
        private IInventoriesReader _inventoriesReader { get; set; }

        private IInventoriesWriter _inventoriesWriter { get; set; }

        private ILogger<InventoriesService> _logger { get; set; }

        public InventoriesService(IInventoriesReader inventoriesReader, IInventoriesWriter inventoriesWriter, ILogger<InventoriesService> logger)
        {
            _inventoriesReader = inventoriesReader;
            _inventoriesWriter = inventoriesWriter;
            _logger = logger;
        }

        public IEnumerable<ServiceInventories.ProductInventory> GetCurrentProductInventory()
        {
            var entityProductInventories = _inventoriesReader.GetCurrentProductInventoryFromDb();
            var serviceProductInventories = entityProductInventories
                .Select(pi => InventoryMapper
                .SerialiseProductInventoryRecord(pi));
            return serviceProductInventories;
        }

        public ServiceInventories.ProductInventory GetProductInventoryRecordByProductId(int id)
        {
            var entityProductInventory = _inventoriesReader.GetProductInventoryRecordFromDbByProductId(id);
            var serviceProductInventory = InventoryMapper.SerialiseProductInventoryRecord(entityProductInventory);
            return serviceProductInventory;
        }

        public ServiceResponse<ServiceInventories.ProductInventory> DeleteProductInventoryRecord(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceInventories.ProductInventorySnapshot> GetSnapshotHistory()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);
            var entityPastWeeksSnapshotHistory = _inventoriesReader.GetSnapshotHistoryFromDb(oneWeekAgo);
            var servicePastWeeksSnapshotHistory = entityPastWeeksSnapshotHistory
                .Select(s => InventoryMapper
                .SerialiseProductInventorySnapshot(s));
            return servicePastWeeksSnapshotHistory;
        }

        // not a fan of the nested try/catch. Must be a better way
        public ServiceResponse<ServiceInventories.ProductInventory> UpdateQuantityAvailable(int productId, int adjustment)
        {
            var productInventory = _inventoriesReader.GetProductInventoryRecordFromDbByProductId(productId);
            var now = DateTime.Now;

            var response = new ServiceResponse<ServiceInventories.ProductInventory>()
            {
                Time = now
            };

            try
            {
                _inventoriesWriter.UpdateQuantityAvailableInDb(productId, adjustment);

                try
                {
                    productInventory.UpdatedOn = now;
                    _inventoriesWriter.AddProductInventorySnapshotToDb(productInventory);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Failed to create product inventory snapshot for product inventory record {productInventory.Id} pertaining to product {productId}. " +
                        $"Stack trace: {e.StackTrace}");
                }

                response.IsSuccessful = true;
                response.Data = InventoryMapper.SerialiseProductInventoryRecord(productInventory);
                response.Message = $"Quantity successfully updated to {productInventory.QuantityAvailable} for product inventory record {productInventory.Id} pertaining to product {productId}";
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Data = InventoryMapper.SerialiseProductInventoryRecord(productInventory);
                response.Message = $"Failed to update quanitity for product inventory record {productInventory.Id} pertaining to product {productId}. Stack trace: {e.StackTrace}";
            }

            return response;
        }
    }
}
