<template>
    <transition name="modal-fade">
    </transition>
</template>


<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({ name: "SparkDrumsModal" })
export default class SparkDrumsModal extends Vue{
    private close(): void {
        this.$emit("close");
    }
}

</script>


<style lang="scss" scoped>
@import "@/scss/global.scss";

.modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.6);
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>