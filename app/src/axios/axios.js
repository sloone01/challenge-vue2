import Vue from 'vue'
import axios from 'axios'

Vue.prototype.$http = axios
const axiosInstance = axios.create({
    baseURL: 'https://localhost:7067/',

})

const successHandler = (response) => {
    return Promise.resolve({data : response.data})
}




const errorHandler = (error) => {
    if (error.response) {
        return Promise.reject(error.response.data);
    }

    return Promise.reject("Could not Connect")

}
axiosInstance.interceptors.response.use(
    sucess => successHandler(sucess),
    error => errorHandler(error)
)


export const http = axiosInstance
