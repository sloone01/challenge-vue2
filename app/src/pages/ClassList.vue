<template>
  <v-container data-app>
    <v-card color="white">
    <response/>
    <h2>Class List</h2>
      <v-btn @click="addClass" depressed>
        Add Class
      </v-btn>
    <v-data-table
        dense
        :loading="Loading"
        :items="Classes"
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

    <edit-class-dialog
        @close="editDialog = false"
        :class_r="general"
        :edit-dialog="editDialog"></edit-class-dialog>
  </v-container>

</template>

<script>
import getDataLists from "./code/getDataLists";
import { ref } from "@vue/composition-api";
import EditClassDialog from "./Dialogs/EditClassDialog";
import useGeneralObjects from './code/student';
import Response from "./response";

export default {
  name: "CountryList",
  components: {Response, EditClassDialog },
  setup(_, { root }){
    const store = root.$store;
    const { general } = useGeneralObjects();
    const editDialog = ref(false);
    const { Classes,Loading,Headers2 } = getDataLists();
    const addClass = () => root.$router.push({name : "AddClass"})

    const deleteItem = (id,index) => store.dispatch('classStore/deleteClass',{ id , index})
    const editItem = (i) => {
      general.value.id = i.id;
      general.value.Name = i.name;
      editDialog.value = true;
    }



    return {
      deleteItem,
      editDialog,
      addClass,
      editItem,
      Headers2,
      Classes,
      Loading,
      general,
    }
  }
}
</script>

<style scoped>

</style>
