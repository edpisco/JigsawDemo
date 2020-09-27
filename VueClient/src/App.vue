<template>
  <div id="app">
    <div class="project-info">
      <h1>Jigsaw Mini Project - Ed Piper</h1>
      <p>Double click on a node to generate a child</p>
    </div>
    <Demo></Demo>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Demo from './components/Demo.vue';

@Component({
  components: {
    Demo
  },
})
export default class App extends Vue {}
</script>


<style>
html,
body {
  position: fixed;
  margin: 0;
  padding: 0;
  width: 100%;
  height: 100%;
  background-color: white;
  touch-action: none;
  overscroll-behavior-y: contain;
  overflow: hidden;
  font-family: Tahoma, Verdana, sans-serif;
  font-size: 12px;
  color: #333333;
}
.project-info {
  margin: 5px;
}
</style>

