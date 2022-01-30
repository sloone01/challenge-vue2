import VueRouter from 'vue-router'
import Vue from 'vue';

Vue.use(VueRouter);

import AddStudent from "../pages/AddStudent";
import StudentsList from "../pages/StudentsList";
import MainPage from "../pages/MainPage";
import CountryList from "../pages/CountryList";
import AddCountry from "../pages/AddCountry";
import ClassList from "../pages/ClassList";
import AddClass from "../pages/AddClass";
const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        { path: '/', component :MainPage , name : "Home"},
        { path: '/AddStudent', component :AddStudent , name : "AddStudent"},
        { path: '/studentList', component :StudentsList , name : "StudentList"},
        { path: '/AddCountry', component :AddCountry , name : "AddCountry"},
        { path: '/CountryList', component :CountryList , name : "CountryList"},
        { path: '/AddClass', component :AddClass , name : "AddClass"},
        { path: '/ClassList', component :ClassList , name : "ClassList"}
    ],
  })

  export default router;
