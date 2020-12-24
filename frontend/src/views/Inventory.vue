<template>
  <div class="inventory-container">
    <h1 class="inventory-title">Inventory Dashboard</h1>
    <hr />
    <table id="inventory-table" class="table">
      <tr>
        <th>Item</th>
        <th>Quantity</th>
        <th>Unit Price</th>
        <th>Taxable</th>
        <th>Delete</th>
      </tr>
      <tr v-for="item in inventoryItems" :v-bind="id">
        hello
      </tr>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({ name: "Inventory" })
import { IProductInventory } from "../types/Product";
export default class Inventory extends Vue {
  inventoryItems: IProductInventory[] = [];


  private setupProductInventoryItems(): void {
      this.inventoryItems = [
          {
              id: 1,
              product: { 
                  id: 1, name: "Emmental", description: "Da good Swiss", 
                  price: 4.50, category: "Cheeses", isOnSale: true,  
                  createdOn: new Date(), updatedOn: new Date()
                  }

          },

      ]
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
</style>
