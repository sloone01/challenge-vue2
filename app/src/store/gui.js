const state = {
  loading: false,
  message: '',
  error: '',
}

const getters = {
  getLoading: state => state.loading,
  getMessage: state => state.message,
  getError: state => state.error,
}

const actions = {
}

const mutations = {
  SET_LOADING: (state, loading) => state.loading = loading,
  SET_ERROR: (state, loading) => state.error = loading,
  SET_MESSAGE: (state, loading) => state.message = loading,
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}
