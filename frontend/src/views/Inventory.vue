<template>
  <div class="inventory-container">
    <h1 class="inventory-title">Inventory Dashboard</h1>
    <hr />
    <div class="inventory-actions">
      <spark-drums-button @click.native="showNewProductModal" id="add-new-product-button">
        Add new product
      </spark-drums-button>
      <spark-drums-button @click.native="showReceiveShipmentModal" id="receive-shipment-button">
        Receive new shipment
      </spark-drums-button>
    </div>
    <table id="inventory-table" class="table">
      <tr>
        <th>Item</th>
        <th>Quantity</th>
        <th>Unit Price</th>
        <th>Taxable</th>
        <th>Delete</th>
      </tr>
      <tr v-for="item in inventoryItems" :key="item.id">
        <td>{{ item.product.name }}</td>
        <td>{{ item.quantityAvailable }}</td>
        <td>{{ item.product.price | price }}</td>
        <td>{{ getIsTaxableString(item.product.isTaxable) }}</td>
        <td>X</td>
      </tr>
    </table>
    <new-product-modal v-if="isNewProductVisible" />
    <shipment-modal v-if="isShipmentVisible" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SparkDrumsButton from "../components/SparkDrumsButton.vue";
import { IProductInventory } from "../types/Product";

@Component({ name: "Inventory", components: { SparkDrumsButton } })
export default class Inventory extends Vue {

  isNewProductVisible = false;
  isShipmentVisible = false;
  inventoryItems: IProductInventory[] = [];

  created(): void {
    this.setupProductInventoryItems();
  }

  private getIsTaxableString(isTaxable: boolean): string {
    const isTaxableString = isTaxable ? "Yes" : "No";
    return isTaxableString;
  }

  // private showNewProductModal(): void {

  // }

  // private showShipmentModal(): void {

  // }

  private setupProductInventoryItems(): void {
      this.inventoryItems = [
          {
              id: 1,
              product: { 
                  id: 1, name: "Emmental", description: "Da good Swiss", 
                  price: 4.50, category: "Cheeses", isOnSale: true,
                  isTaxable: true, isArchived: true,  
                  createdOn: new Date(), updatedOn: new Date()
                  },
              quantityAvailable: 4,
              idealQuantity: 5,
              createdOn: new Date(), 
              updatedOn: new Date()
          },
          {
              id: 2,
              product: { 
                  id: 2, name: "Stilton", description: "Da good smelly boi", 
                  price: 3, category: "Cheeses", isOnSale: false,
                  isTaxable: true, isArchived: true,  
                  createdOn: new Date(), updatedOn: new Date()
                  },
              quantityAvailable: 10,
              idealQuantity: 50,
              createdOn: new Date(), 
              updatedOn: new Date()
          }
      ];
  }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.inventory-title {
  color: $spark-drums-green;
  text-align: left;
}

.inventory-container {
  color: $medium-wood;
}

#inventory-table {
  width: 100%;
  max-width: 100%;
  margin-bottom: 2rem;
  border-collapse: collapse;

  tr {
    border-bottom: 1px solid #eee;
    transition: background-color 0.3s;

    &:hover {
      background-color: #f5f5f5;
      transition: background-color 0.3s;

    }
  }

  td {
    padding: 1.2rem;
  }

  th {
    background-color: #f5f5f5;
    padding: 1.2rem;
    border-bottom: 2px solid $spark-drums-green
  }
}
</style>
