<!-- eslint-disable prettier/prettier -->
<template>
    <div class="button-link">
        <button @click="visitRoute">
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

  visitRoute() {
      console.log(this.link);
      this.$router.push({ name: `${this.link}`});
    }
}
</script>


<style lang="sass" scoped>

</style>