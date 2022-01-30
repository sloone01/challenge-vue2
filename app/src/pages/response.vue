<template>
  <v-dialog
      v-model="showDialog"
      transition="dialog-bottom-transition"
      max-width="600"
  >

      <v-card>
        <v-toolbar
            :color="status ? '#05DE07' : '#FF3639'"
        >{{ title }}</v-toolbar>
        <v-card-text>
          <h2 class="mt-5">{{  message }}</h2>
        </v-card-text>
        <v-card-actions class="justify-end">
          <v-btn
              text
              @click="showDialog = false"
          >Close</v-btn>
        </v-card-actions>
      </v-card>
  </v-dialog>
</template>

<script>
import { ref, computed, watch } from '@vue/composition-api'

export default {
  setup(_, { root }) {
    const store = root.$store
    const showDialog = ref(false)
    const isHidden = ref(true)
    const status = ref(true)
    const message = ref(true)
    const title = ref('')

    const error = computed(() => store.getters['gui/getError'])
    const success = computed(() => store.getters['gui/getMessage'])

    watch(error, val => {
      title.value = 'ُError'
      message.value = val.message
      status.value = false
      showDialog.value = true
    }, { deep: true })

    watch(success, val => {
      title.value = 'DONE'
      message.value = val
      status.value = true
      showDialog.value = true
    }, { deep: true })

    return {
      title,
      showDialog,
      isHidden,
      status,
      message,
    }
  },
}
</script>
