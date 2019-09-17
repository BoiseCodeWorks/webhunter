<template>
  <div class="home">
    <game v-if="game.id" />
    <form v-else @submit.prevent="createGame">
      <label for="name">What is your name?</label>
      <input type="text" v-model="user.name" autofocus="true" />
    </form>
    <div class="error">{{displayError}}</div>
  </div>
</template>

<script>
import Game from "@/components/Game.vue";

export default {
  name: "home",
  data() {
    return {
      user: { name: "" }
    };
  },
  computed: {
    game() {
      return this.$store.state.game;
    },
    error() {
      return this.$store.state.error;
    },
    displayError() {
      var e = this.error;
      if (typeof e == "string") {
        return e;
      }
      var message = "";
      if (e.errors) {
        Object.keys(e.errors).forEach(k => {
          message += `${k}: ${e.errors[k]}`;
        });
      }
      return message;
    }
  },
  methods: {
    createGame() {
      this.$store.dispatch("createGame", this.user);
    }
  },
  components: {
    Game
  }
};
</script>


<style>
#app {
  height: 100vh;
  padding: 1em;
  background: #3e3e3e;
  color: #42b983 !important;
  font-family: "Press Start 2P", cursive;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

input {
  background: transparent !important;
  border: none;
  margin-left: 1em;
  color: whitesmoke;
}
input:focus {
  outline: none !important;
}

.error {
  color: #ca2727;
}
</style>
