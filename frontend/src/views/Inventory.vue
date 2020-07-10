<template>
  <div class="inventory-container">
    <h1 class="inventory-title">Inventory Dashboard</h1>
    <p>
        Aau Abbey Abv Acid Acidic Additive Adjunct Aerobic Bacterial, abv wheat alpha cask imperial copper mash hop pitch, stout Barleywine bock lauter fermenting Anaerobic specific. Beer shelf krausen Barley kolsch weisse final crystal, black wit gravity Aau Amber Alpha stout heat, pub de chocolate finishing conditioned kettle. Brewhouse alpha back exchanger mouthfeel fermenting Barley biere, chiller extract bock wit hop microbrewery degrees, Aerobic infusion hoppy Acid kolsch Beer. Ipa real bunghole terminal Abbey dextrin rest alcohol, back conditioned fermenting specific keg plato saccharification, Bitter hoppy attenuation dopplebock Alcohol stout. Back hydrometer  priming lagering pump Barleywine rims Acid, heat bright extract fermenting infusion brewpub Balthazar beer caramel, finishing Anaerobic Beer Bacterial mash chiller Alcohol. Bitterness cold malt Abv trappist hop lambic priming, heat squares weisse biere hydrometer ibu, mash krug double krausen Attenuation hopping. Berliner cider specific brewpub Aau Anaerobic kettle anaerobic units conditioning priming, barley lauter hops secondary  finishing lagering carboy balthazar stout, saccharification Bottle dunkle attenuation Becher cask plato rims noble.
    </p>
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