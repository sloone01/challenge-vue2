<template>
  <v-container data-app>
    <response/>
    <v-col cols="12" md="12">
      <v-form>
        <v-subheader>
          <h1>ٍAdd New Student</h1>
        </v-subheader>

        <v-col cols="12" md="9">
          <v-text-field
              outlined
              dense
              v-model="student.Name"
              label="Full Name"
              :rules="nameRule"
          />
        </v-col>

        <v-col cols="12" md="9">
          <v-autocomplete
              outlined
              label="Country"
              item-text="name"
              item-value="id"
              dense
              v-model="student.CountryId"
              :items="Countries"
          ></v-autocomplete>
        </v-col>

        <v-col cols="12" md="9">
          <v-autocomplete
              outlined
              label="Class"
              item-text="name"
              item-value="id"
              dense
              v-model="student.ClassId"
              :items="Classes"
          ></v-autocomplete>
        </v-col>

        <v-col cols="12" md="9">
          <v-menu
              v-model="menue"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                  outlined
                  dense
                  v-model="student.DateOfBirth"
                  label="Date Of Birth"
                  readonly
                  v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker
                v-model="student.DateOfBirth"
                @input="menue = false"
            ></v-date-picker>
            <v-spacer></v-spacer>
          </v-menu>

          <v-btn
              color="primary"
              class="ma-2"
              :disabled="Loading"
              :loading="Loading"
              @click="add()">
            <v-icon left>mdi-checkbox-marked-circle-outline</v-icon>
            <h3>Add Student</h3>
          </v-btn>
        </v-col>


      </v-form>
    </v-col>

  </v-container>
</template>

<script>
import getRulesList from './code/rules';
import {ref} from '@vue/composition-api';
import getDataLists from "./code/getDataLists";
import useStudentObject from './code/student';
import Response from "./response";

export default {
  name: "AddStudent",
  components: {Response},
  setup(_, {root}) {
    const store = root.$store
    const menue = ref(false)
    const { student } = useStudentObject()
    const { Countries, Classes, Loading} = getDataLists()
    const {required, nameRule} = getRulesList()


    const add = () => store.dispatch('student/addStudent', student.value);
    const goBack = () => {};
    return {
      Loading,
      Countries,
      Classes,
      required,
      nameRule,
      student,
      goBack,
      menue,
      add
    }
  }
}
</script>

<style scoped>

</style>
