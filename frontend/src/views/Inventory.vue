<template>
  <div class="inventory-container">
    <h1 class="inventory-title">Inventory Dashboard</h1>
    <hr>
    <table>
        <tr>
            <th>Item </th>
            <th>Quantity </th>
            <th>Unit Price </th>
            <th>Taxable </th>
            <th>Delete </th>      
        </tr>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
    name: "Inventory",
    components: {}
})

export default class Inventory extends Vue {}
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