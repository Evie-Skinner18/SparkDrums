<template>
  <div class="side-menu-container">
    <router-link to="/">
      <img id="logo" alt-text="The Spark Drums logo" src="@/assets/logo.png" />
    </router-link>
    <h3>Management Portal</h3>
    <spark-drums-button id="inventoryButton" :link="'inventory'">Inventory</spark-drums-button>
    <spark-drums-button id="customersButton" :link="'customers'">Manage Customers</spark-drums-button>
    <!-- in his API Wes has separate controller method that looks like this
    
      [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceModel invoice)

        to generate an invoice. This front end is for admin user not customer.
     -->
    <spark-drums-button id="invoiceButton" :link="'invoice/new'">Create Invoice</spark-drums-button>
    <spark-drums-button id="ordersButton" :link="'orders'">Orders</spark-drums-button>
  </div>
</template>


<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SparkDrumsButton from "./SparkDrumsButton.vue";

@Component({
  name: "SideMenu",
  components: { SparkDrumsButton }
})
export default class SideMenu extends Vue {}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

  .side-menu-container {
      background-color: $spark-drums-red;
      height: 100vh;
      width: $menu-width;
      display: flex;
      flex-direction: column;
      padding: 0.8rem;
      box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
      box-sizing: border-box;
      color: $spark-drums-background;
  }

  #logo {
    width: 100%;
  }
</style>>

