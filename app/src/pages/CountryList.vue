<template>
  <v-container data-app>
    <v-card color="white">
    <response/>
    <h2>Countries List</h2>
      <v-btn @click="addCountry" depressed>
        Add Country
      </v-btn>
    <v-data-table
        dense
        :loading="Loading"
        :items="Countries"
         item-key="id"
        :items-per-page="5"
        :headers="Headers2"
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
                class="ma-2"
                color="red"
            >
              Delete
            </v-btn>
        </v-row>

      </template>
    </v-data-table>
    </v-card>
    <edit-country-dialog @close="editDialog = false" :country="general" :edit-dialog="editDialog"></edit-country-dialog>
  </v-container>

</template>

<script>
import getDataLists from "./code/getDataLists";
import { ref } from "@vue/composition-api";
import EditCountryDialog from "./Dialogs/EditCountryDialog";
import useGeneralObjects from './code/student';
import Response from "./response";

export default {
  name: "CountryList",
  components: {Response, EditCountryDialog },
  setup(_, { root }){
    const store = root.$store;
    const { general } = useGeneralObjects();
    const editDialog = ref(false);

    const { Countries,Loading,Headers2 } = getDataLists();
    const addCountry = () => root.$router.push({name : "AddCountry"})

    const deleteItem = (id,index) => store.dispatch('country/deleteCountry',{ id, index })
    const editItem = (i) => {
      general.value.id = i.id;
      general.value.Name = i.name;
      editDialog.value = true;
    }



    return {
      deleteItem,
      editDialog,
      addCountry,
      editItem,
      Countries,
      Headers2,
      Loading,
      general
    }
  }
}
</script>

<style scoped>

</style>
