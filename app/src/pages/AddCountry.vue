<template>
  <v-container data-app>
    <response/>
    <v-col cols="12" md="12">
      <v-form>
        <v-subheader>
          <h1>ٍAdd Country</h1>
        </v-subheader>

        <v-col cols="12" md="9">
          <v-text-field
              outlined
              dense
              v-model="general.Name"
              label="Name"
              :rules="nameRule"
          />
          <v-btn
              color="primary"
              class="ma-2"
              :disabled="Loading"
              :loading="Loading"
              @click="add()">
            <h3>Save</h3>
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
  name: "AddCountry",
  components: {Response},
  setup(_, {root}) {
    const store = root.$store
    const menue = ref(false)
    const { general } = useStudentObject()
    const { Countries, Loading} = getDataLists()
    const {required, nameRule} = getRulesList()


    const add = () => store.dispatch('country/addCountry', general.value);
    const goBack = () => {};
    return {
      Loading,
      Countries,
      required,
      nameRule,
      general,
      goBack,
      menue,
      add
    }
  }
}
</script>

<style scoped>

</style>
