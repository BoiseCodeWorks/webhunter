import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

let _api = axios.create({
  baseURL: location.port.includes("8080") ? "https://localhost:5001/api" : "/api"
})


Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    game: {},
    error: {}
  },
  mutations: {
    setGame(state, game = {}) {
      Object.keys(game).forEach(k => {
        let value = game[k]
        Vue.set(state.game, k, value)
      })
    },
    setError(state, error) {
      state.error = error
    }
  },
  actions: {
    async createGame({ commit }, user) {
      try {
        commit('setError', {})
        let res = await _api.post("games", user)
        commit('setGame', res.data)
      } catch (e) { commit("setError", e.response.data) }
    },
    async getGame({ commit }, gameId) {
      try {
        commit('setError', {})
        let res = await _api.get("games/" + gameId)
        commit('setGame', res.data)
      } catch (e) { commit("setError", e.response.data) }
    },
    async getGames({ commit }) {
      try {
        commit('setError', {})
        let res = await _api.get("games")
        commit('setGame', res.data)
      } catch (e) { commit("setError", e.response.data) }
    },
    async sendInput({ state, commit }, input) {
      try {
        commit('setError', {})
        let res = await _api.put("games/" + state.game.id, input)
        commit('setGame', res.data)
      } catch (e) { commit("setError", e.response.data) }
    }
  }
})
