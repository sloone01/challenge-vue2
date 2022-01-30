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
                        v-model="class_r.Name"
                        label="Full Name"
                        :rules="nameRule"
                    />
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
    class_r : {
      required: true,
      type : Object
    }
  },
  setup(props, { root , emit})
  {
    const menue = ref(false)
    const { Loading }  = getDataLists();
    const { required, nameRule } = getRulesList()
    const update = async () => {
      try {
        await root.$store.dispatch('classStore/updateClass', props.class_r)
        emit('close');
      }catch (e) {console.log(e);}
    }
    const close = () => emit('close')
    return {
      required,
      nameRule,
      Loading,
      update,
      close,
      menue,
    }

  }
}
</script>

<style scoped>

</style>
