<template>
  <input v-model="message" />
  <button @click="addWords(message)" class="btn">Add Words</button>
  <ul v-for="word in words">
    <li>{{ word }}</li>
  </ul>
</template>

<script>
export default {
  name: "App",

  data() {
    return {
      message: "Hello World",
      words: []
    };
  },

  methods: {
    addWords(val) {
      this.words.push(val);
    }
  }
}
</script>

<style>
.btn {
  color: #fff;
  background-color: blue;
}
</style>