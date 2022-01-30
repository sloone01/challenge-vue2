<template>
  <v-container data-app>
    <v-card color="white" class="mt-4">
    <response/>
    <h2>Students List</h2>
      <v-btn @click="addStudent" depressed>
        Add Student
      </v-btn>
    <v-data-table
        dense
        :loading="Loading"
        :items="Students"
         item-key="id"
        :items-per-page="5"
        :headers="Headers"
        :sort-by="['id']"
        :sort-desc="[true]"
    >
      <template v-slot:item.actions="{ item,index }">
        <v-row>
          <v-btn small class="ma-2" @click="editItem(item)" depressed>
            Update
          </v-btn>
            <v-btn
                small
                @click="deleteItem(item.id,index)"
                depressed
                class="mt-2"
                color="red"
            >
              Delete
            </v-btn>
        </v-row>

      </template>
    </v-data-table>
    </v-card>
    <edit-student-dailog @close="editDialog = false" :student="student" :edit-dialog="editDialog"/>

    <v-row class="mt-4">
      <v-col cols="12" md="6">
        <v-list
            subheader
        >
          <h3>Student By Class</h3>

          <v-list-item
              v-for="[cls,val] in classMap" :key='cls'
          >
            <v-list-item-avatar>
              <v-icon
                  class="grey lighten-1"
                  dark
              >
                mdi-folder
              </v-icon>
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title v-text="cls"></v-list-item-title>
            </v-list-item-content>

            <v-list-item-action>
              {{ val.length }}
            </v-list-item-action>
          </v-list-item>

          <v-divider inset></v-divider>

          <h3>Student By Country</h3>

          <v-list-item
              v-for="[cntry,val] in countryMap" :key='cntry'
          >
            <v-list-item-avatar>
              <v-icon
                  class="grey lighten-1"
                  dark
              >
                mdi-folder
              </v-icon>
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title v-text="cntry"></v-list-item-title>
            </v-list-item-content>

            <v-list-item-action>
              {{ val.length }}
            </v-list-item-action>
          </v-list-item>
        </v-list>
      </v-col>
      <v-col cols="12" md="6">
        <h3>Average Age : {{ AverageAge }}</h3>
      </v-col>

    </v-row>
  </v-container>

</template>

<script>
import getDataLists from "./code/getDataLists";
import {ref, watch} from "@vue/composition-api";
import EditStudentDailog from "./Dialogs/EditStudentDailog";
import useStudentObject from './code/student';
import Response from "./response";
import getHelper from "./code/helper";
export default {
  name: "StudentsList",
  components: {Response, EditStudentDailog },
  setup(_, { root }){
    const store = root.$store;
    const editDialog = ref(false);

    const { student } = useStudentObject();
    const { Students,Loading,Headers } = getDataLists();
    const { groupBy , getAge } = getHelper();
    const classMap = ref(new Map());
    const countryMap = ref(new Map());
    const AverageAge = ref(0)

    watch(Students, val => {
      classMap.value = groupBy(val,student => student.className)
      countryMap.value = groupBy(val,student => student.countryName)
      console.log(val.map(x => getAge(new Date(x.dateOfBirth))));
      AverageAge.value = val.map(x => getAge(new Date(x.dateOfBirth)))
          .reduce((a, b) => a + b) / Students.value.length
    }, { deep: true })

    const deleteItem = (id,index) => store.dispatch('student/deleteStudent',{ id, index})
    const addStudent = ()=> {root.$router.push({ name : "AddStudent"})}
    const editItem = (i) => {
      student.value.id = i.id;
      student.value.Name = i.name;
      student.value.DateOfBirth =new Date(i.dateOfBirth.toString("yyyy-MM-dd")).toISOString().substr(0, 10);
      student.value.ClassId = i.classId;
      student.value.CountryId = i.countryId;
      editDialog.value = true;
    }



    return {
      AverageAge,
      deleteItem,
      editDialog,
      addStudent,
      countryMap,
      classMap,
      editItem,
      Students,
      Headers,
      Loading,
      student
    }
  }
}
</script>

<style scoped>

</style>
