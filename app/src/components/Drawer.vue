<template>
      <v-navigation-drawer
          height="100%"
          absolute
          permanent
          dark
          left
      >
        <template v-slot:prepend>
          <v-list-item two-line>

            <v-list-item-content>
              <v-list-item-title>Salim Alismaili</v-list-item-title>
              <v-list-item-subtitle>Full Stack developer</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>
        </template>

        <v-divider></v-divider>

        <v-list
            dense
            nav
        >
          <v-list-item
              v-for="item in items"
              :key="item.title"
              :to="item.path"
              link
          >
            <v-list-item-icon>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
</template>

<script>
export default {
  name: "Drawer",
  data () {
    return {
      items: [
        { title: 'Home', icon: 'mdi-home-city' , path : "/" },
        { title: 'Students List', icon: 'mdi-person', path : "StudentList" },
        { title: 'Countries List', icon: 'mdi-person', path : "CountryList" },
        { title: 'Classes List', icon: 'mdi-person', path : "ClassList" },

      ],
    }
  },
}
</script>

<style scoped>

</style>
