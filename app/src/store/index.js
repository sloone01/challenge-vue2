import Vue from 'vue';
import Vuex from 'vuex'

Vue.use(Vuex);

import gui from './gui'
import student from './student'
import country from "./country";
import classStore from "./classStore"


export default new Vuex.Store({
    modules: {
        gui,
        student,
        country,
        classStore
    }
})
