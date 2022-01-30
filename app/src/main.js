import Vue from 'vue'
import App from './App.vue'
import router from './router/router'
import vuetify from './vuetify/vuetify'
import Vuex from "vuex";
import store from './store/index'
import VueCompositionAPI from '@vue/composition-api'
import response from "./pages/response";


Vue.use(VueCompositionAPI)
Vue.use(Vuex);
Vue.config.productionTip = false
Vue.component(response);


new Vue({
  vuetify,
  router,
  store,
  render: h => h(App),
}).$mount('#app')
