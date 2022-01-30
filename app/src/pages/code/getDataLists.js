import Vue from 'vue';
import VueCompositionAPI from "@vue/composition-api";
import  { computed } from '@vue/composition-api'
import store from '../../store'
Vue.use(VueCompositionAPI);


export default function getDataLists() {
    store.dispatch('country/fetchCountries');
    store.dispatch('classStore/fetchCLasses');
    store.dispatch('student/fetchStudentList');

    const Countries =  computed(() => store.getters['country/getCountries'])
    const Classes =  computed(() => store.getters['classStore/getClasses'])
    const Students =  computed(() => store.getters['student/getStudentList'])
    const Loading = computed(() => store.getters['gui/getLoading'])


    const Headers = [ { text : 'Id', value : "id"},
        { text : 'Name', value : "name"},
     { text : 'Date of Birth', value : "dateOfBirth"},
     { text : 'Class', value : "countryName"},
     { text : 'Country', value : "className"},
     { text : 'Actions', value : "actions"}
    ]
    const Headers2 = [ { text : 'Id', value : "id"},
        { text : 'Name', value : "name"},
        { text : 'Actions', value : "actions"}]

    return {Countries,Classes,Students,Loading,Headers,Headers2}
}


