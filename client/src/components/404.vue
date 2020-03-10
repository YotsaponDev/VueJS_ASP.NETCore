<style>
.outer {
  display: table;
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
}

.middle {
  display: table-cell;
  vertical-align: middle;
}

.inner {
  margin-left: auto;
  margin-right: auto;
  width: 400px;
  /*whatever width you want*/
}
</style>

<template>
<div class="outer">
  <div class="middle">
    <div class="inner">
      <h1>404</h1>
      <h5>Page not found</h5><br>
      <b-button variant="outline-secondary" @click="$router.push({name: 'index'})">กลับหน้าหลัก</b-button>
    </div>
  </div>
</div>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  import layout from '../components/layout'
  export default {
    components: {
      layout
    },
    data() {
        return {
               
        }
      },
    mounted(){

    },
  }
</script>