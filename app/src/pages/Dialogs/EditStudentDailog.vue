<template>
  <v-row justify="center">
    <v-dialog
        v-model="editDialog"
        persistent
        max-width="600px"
    >
      <v-card>
        <v-card-title>
          <span class="text-h5">Edit Student</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" md="11">
                <v-form>
                  <v-col cols="12" md="12">
                    <v-text-field
                        outlined
                        dense
                        v-model="student.Name"
                        label="Full Name"
                        :rules="nameRule"
                    />
                  </v-col>

                  <v-col cols="12" md="12">
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

                  <v-col cols="12" md="12">
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

                  <v-col cols="12" md="12">
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
                  </v-col>

                </v-form>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
              color="blue darken-1"
              text
              @click="close()"
          >
            Close
          </v-btn>
          <v-btn
              color="blue darken-1"
              text
              @click="update"
          >
            Update
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import getDataLists from "../code/getDataLists";
import getRulesList from "../code/rules";
import { ref } from "@vue/composition-api";


export default {
  name: "Dialog",
  props :{
    editDialog : {
      required : true,
      type : Boolean
    },
    student : {
      required: true,
      type : Object
    }
  },
  setup(props, { root , emit})
  {
    const menue = ref(false)
    const { Classes,Countries,Loading}  = getDataLists();
    const { required, nameRule } = getRulesList()
    const update = async () => {
      try {
        await root.$store.dispatch('student/updateStudent', props.student)
        emit('close');
      }catch (e) {console.log(e);}
    }
    const close = () => emit('close')
    return {
      Countries,
      required,
      nameRule,
      Loading,
      Classes,
      update,
      close,
      menue,
    }

  }
}
</script>

<style scoped>

</style>
