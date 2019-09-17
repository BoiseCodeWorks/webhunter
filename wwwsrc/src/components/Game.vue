<template>
  <div class="hello">
    <h1>Welcome {{game.player.name}}</h1>
    <p>Room: {{game.currentRoom.name}}</p>
    <p>Description: {{game.currentRoom.description}}</p>
    <form @submit.prevent="sendInput()">
      <label for>></label>
      <input type="text" v-model.trim="input" />
    </form>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String
  },
  data() {
    return {
      input: ""
    };
  },
  computed: {
    game() {
      return this.$store.state.game;
    }
  },
  methods: {
    sendInput() {
      if (!this.input || this.input.length == 0) {
        return;
      }
      let input = {
        command: this.input.split(" ")[0],
        options: this.input.substr(this.input.indexOf(" ") + 1).trim()
      };
      this.$store.dispatch("sendInput", input);
    }
  }
};
</script>