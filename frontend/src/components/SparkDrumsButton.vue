<!-- eslint-disable prettier/prettier -->
<template>
    <div class="button-container">
                                                            <!-- the full-width class will be applied when isFullWidth prop is true -->
        <button @click="visitRoute" class="button-link" v-bind:class="['spark-drums-button', { 'full-width': isFullWidth }]">
            <!-- when SparkDrumsButton renders, whatever's between its opening and closing tags will render in place of this slot -->
            <slot></slot>
        </button>
    </div>
</template>

<script lang="ts">
// eslint-disable prettier/prettier
// import Vue from "vue";
// import Component from "vue-class-component";
import { Vue, Component, Prop } from "vue-property-decorator";

@Component({
    name: "SparkDrumsButton",
    components: {},
})
export default class SparkDrumsButton extends Vue {
  @Prop(String)
  link?: string;

  @Prop({ required: false, type: Boolean, default: false })
  isFullWidth: boolean;

  visitRoute() {
      console.log(this.link);
      this.$router.push({ name: `${this.link}`});
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.button-container {
  margin-top: 2%;
}

.button-link {
    background: $spark-drums-background;
    color: $ebony-wood;
    font-size: 85%;
    box-shadow: none;
    padding: 3%;
    width: 100%;
    height: 100%;

    &:hover {
        background: $light-wood;
        transition: background-color 1s;
    }
    &:disabled {
        background: $steel;
    }
    &:active {
        background: $spark-drums-red;
    }
    &:focus {
        border: $spark-drums-navy;
    }
}

.full-width {
  display: block;
  width: 100%;
}
</style>
