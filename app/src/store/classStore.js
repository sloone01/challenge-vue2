import { http as axios } from '../axios/axios'

const state = {
  classList : []
}

const getters = {
  getClasses: st1 => st1.classList
}

const actions = {
  async addClass({ commit }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const resp = await axios.post('Class', data)
      commit('ADD_CLASS', resp)
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Class Added Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: e }, { root: true })
      return Promise.reject(e)
    }
  },
  async deleteClass({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.delete('Class?id='+data.id)
      dispatch("fetchCLasses");
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Class Delteted Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: e }, { root: true })
      return Promise.reject(e)
    }
  },
  async updateClass({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.put('Class',data)
      dispatch("fetchCLasses");
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Class Updated Succefully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: 'problem Happende' }, { root: true })
      return Promise.reject(e)
    }
  },

  async fetchCLasses({ commit }) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const response = await axios.get('Class')
      commit('gui/SET_LOADING', false, { root: true })
      commit('SET_CLASS_LIST', response.data)
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', e, { root: true })
    }
  },

}

const mutations = {
  ADD_CLASS: (st4, data) => st4.classList.push(data),
  SET_CLASS_LIST: (st4, data) => st4.classList = data,

}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}
