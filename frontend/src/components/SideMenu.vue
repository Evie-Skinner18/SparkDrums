<template>
  <div class="side-menu-container">
    <img id="logo" alt-text="The Spark Drums logo" src="@/assets/logo.png" />
    <h3>Management Portal</h3>
  </div>
</template>


<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  name: "SideMenu",
  components: {}
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

