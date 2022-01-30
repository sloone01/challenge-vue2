import { http as axios } from '../axios/axios'

const state = {
  countryList : []
}

const getters = {
  getCountries: st1 => st1.countryList
}

const actions = {
  async addCountry({ commit }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const resp = await axios.post('Countries', data)
      commit('ADD_COUNTRY', resp)
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Country Added Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: e }, { root: true })
      return Promise.reject(e)
    }
  },
  async updateCountry({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.put('Countries', data)
      dispatch('fetchCountries');
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Country Updated Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: e }, { root: true })
      return Promise.reject(e)
    }
  },
  async deleteCountry({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.delete('Countries?id='+ data.id)
      dispatch('fetchCountries');
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Country Deleted Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: 'problem Happende' }, { root: true })
      return Promise.reject(e)
    }
  },
  async fetchCountries({ commit }) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const response = await axios.get('Countries')
      commit('gui/SET_LOADING', false, { root: true })
      commit('SET_COUNTRY_LIST', response.data)
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', e, { root: true })
    }
  },

}

const mutations = {
  ADD_COUNTRY: (st4, data) => st4.countryList.push(data),
  SET_COUNTRY_LIST: (st4, data) => st4.countryList = data,

}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}
