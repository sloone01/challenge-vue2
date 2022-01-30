<template>
<div>
    <v-app-bar/>
    <v-row>
      <v-col cols="12" md="3">
        <drawer/>
      </v-col>
      <v-col cols="12" md="9">
        <v-app>
          <router-view/>
        </v-app>
      </v-col>
    </v-row>
</div>
</template>

<script>
import Drawer from './components/Drawer'
export default {
  name: 'App',
  components :{
    Drawer,
  },
    data: () => ({
      loading: false,
      selection: 1,
    }),

    methods: {
      reserve () {
        this.loading = true

        setTimeout(() => (this.loading = false), 2000)
      },
    },
  }

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
