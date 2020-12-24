<template>
    <spark-drums-modal @close="close">hello</spark-drums-modal>
</template>


<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SparkDrumsButton from "../components/SparkDrumsButton.vue";
import SparkDrumsModal from "../components/SparkDrumsModal.vue";

@Component({ name: "ShipmentModal", components: { SparkDrumsButton, SparkDrumsModal } })
export default class ShipmentModal extends Vue{
    
}
</script>


<style lang="scss" scoped>

</style>