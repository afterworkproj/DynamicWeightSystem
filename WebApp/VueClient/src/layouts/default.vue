<template>
  <v-layout class="rounded rounded-md">
    <v-app id="main-app">
      <v-app-bar>
        <v-app-bar-nav-icon @click="toggleDrawer" />
        <v-app-bar-title>Application</v-app-bar-title>
        <v-spacer />

        <!-- switch theme mode-->
        <v-btn icon @click="toggleTheme">
          <v-icon>
            {{ curTheme === 'dark' ? 'fas fa-sun' : 'fas fa-moon' }}
          </v-icon>
        </v-btn>
      </v-app-bar>

      <v-navigation-drawer v-model="drawer">
        <NavigationItems />
      </v-navigation-drawer>

      <v-main class="ma-3">
        <router-view />
      </v-main>

      <AppFooter />
    </v-app>
  </v-layout>
</template>

<script lang="ts" setup>
import { useTheme } from 'vuetify';
import { useStorage } from '@vueuse/core';
import NavigationItems from '@/components/NavigationItems.vue';
import AppFooter from '@/components/AppFooter.vue';

const theme = useTheme();

const drawer = useStorage('drawer', true);
const curTheme = useStorage('theme', 'dark');

const toggleDrawer = () => {
  drawer.value = !drawer.value;
};

const toggleTheme = () => {
  curTheme.value = curTheme.value === 'dark' ? 'light' : 'dark';
  theme.global.name.value = curTheme.value;
};

onMounted(() => {
  theme.global.name.value = curTheme.value;
});
</script>
