using EntityInventories = SparkDrums.Data.Models.Inventories;
using ServiceInventories = SparkDrums.Services.Models.Inventories;


namespace SparkDrums.Services.Serialisation
{
    public static class InventoryMapper
    {
        public static ServiceInventories.ProductInventory SerialiseProductInventoryRecord(EntityInventories.ProductInventory entityInventoryRecord)
        {
            var serviceInventoryRecord = new ServiceInventories.ProductInventory()
            {
                Id = entityInventoryRecord.Id,
                Product = ProductMapper.SerialiseProduct(entityInventoryRecord.Product),
                IdealQuantity = entityInventoryRecord.QuantityAvailable,
                QuantityAvailable = entityInventoryRecord.QuantityAvailable,
                CreatedOn = entityInventoryRecord.CreatedOn,
                UpdatedOn = entityInventoryRecord.UpdatedOn
            };

            return serviceInventoryRecord;
        }

        public static EntityInventories.ProductInventory SerialiseProductInventoryRecord(ServiceInventories.ProductInventory serviceInventoryRecord)
        {
            var entityInventoryRecord = new EntityInventories.ProductInventory()
            {
                Id = serviceInventoryRecord.Id,
                Product = ProductMapper.SerialiseProduct(serviceInventoryRecord.Product),
                IdealQuantity = serviceInventoryRecord.QuantityAvailable,
                QuantityAvailable = serviceInventoryRecord.QuantityAvailable,
                CreatedOn = serviceInventoryRecord.CreatedOn,
                UpdatedOn = serviceInventoryRecord.UpdatedOn
            };

            return entityInventoryRecord;
        }


        public static ServiceInventories.ProductInventorySnapshot SerialiseProductInventorySnapshot(EntityInventories.ProductInventorySnapshot entitySnapshot)
        {
            var serviceSnapshot = new ServiceInventories.ProductInventorySnapshot()
            {
                Id = entitySnapshot.Id,
                Product = ProductMapper.SerialiseProduct(entitySnapshot.Product),
                QuantityAvailable = entitySnapshot.QuantityAvailable,
                SnapshotTime = entitySnapshot.SnapshotTime
            };

            return serviceSnapshot;
        }

        public static EntityInventories.ProductInventorySnapshot SerialiseProductInventorySnapshot(ServiceInventories.ProductInventorySnapshot serviceSnapshot)
        {
            var entitySnapshot = new EntityInventories.ProductInventorySnapshot()
            {
                Id = serviceSnapshot.Id,
                Product = ProductMapper.SerialiseProduct(serviceSnapshot.Product),
                QuantityAvailable = serviceSnapshot.QuantityAvailable,
                SnapshotTime = serviceSnapshot.SnapshotTime
            };

            return entitySnapshot;
        }
    }
}
