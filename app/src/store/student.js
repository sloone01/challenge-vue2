import { http as axios } from '../axios/axios'

const state = {
  studentList : []
}

const getters = {
  getStudentList: st1 => st1.studentList
}

const actions = {
  async addStudent({ commit }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const resp = await axios.post('students', data)
      commit('ADD_STUDENT', resp.data)
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Student Added Succesfully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: 'Problem Happend While Adding' }, { root: true })
      return Promise.reject(e)
    }
  },
  async updateStudent({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.put('students', data)
      dispatch('fetchStudentList');
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Student Updated Succesfully', { root: true })
      return Promise.resolve(true)
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: 'Problem Happend While Updating' }, { root: true })
      return Promise.reject(e)
    }
  },
  async deleteStudent({ commit,dispatch }, data) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      await axios.delete('students?id='+data.id)
      dispatch('fetchStudentList');
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_MESSAGE', 'Deleted Succesfully', { root: true })
      return Promise.resolve()
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', { description: e, message: 'Problem while deleting' }, { root: true })
      return Promise.reject(e)
    }
  },
  async fetchStudentList({ commit }) {
    commit('gui/SET_LOADING', true, { root: true })
    try {
      const response = await axios.get('students')
      commit('gui/SET_LOADING', false, { root: true })
      commit('SET_STUDENT_LIST', response.data)
    } catch (e) {
      commit('gui/SET_LOADING', false, { root: true })
      commit('gui/SET_ERROR', e, { root: true })
    }
  },

}

const mutations = {
  ADD_STUDENT: (st4, data) => st4.studentList.push(data),
  SET_STUDENT_LIST: (st4, data) => st4.studentList = data,

}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}
