<template>
  <div id="app">
    <div class="app-menu">
      <side-menu />
    </div>
    <div class="app-content">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SideMenu from "@/components/SideMenu.vue";
@Component({
  name: "App",
  components: { SideMenu }
})
export default class App extends Vue {}
</script>

<style lang="scss">
@import "@/scss/global.scss";

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: $spark-drums-navy;
  background-color: $spark-drums-background;
  display: flex;

  .app-menu {
    position: fixed;
  }

  .app-content {
    padding: 1.2rem;
    width: 90%;
    // use $menu-width to avoid overlapping with SideMenu component
    margin: 1rem auto 1rem $menu-width;
    text-align: left;
  }
}

// we're displaying all of this on an index.html page so margin 0 gets rid of any margin left over from that
* {
  margin: 0;
}

a {
  text-decoration: none;
  color: $spark-drums-blue;
}
</style>
