import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Inventory from "../views/Inventory.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "home",
    component: Inventory
  },
  {
    path: "/inventory",
    name: "inventory",
    component: Inventory
  },
  {
    path: "/customers",
    name: "customers",
    // component: Customers
  },
  {
    path: "/invoice/new",
    name: "invoice/new",
    // component: Invoice
  },
  {
    path: "/orders",
    name: "orders",
    // component: Orders
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
