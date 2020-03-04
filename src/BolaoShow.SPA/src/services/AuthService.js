import axios from 'axios'

import Environment from '../environments/environment'

class AuthService {
    login(credentials) {
        return axios.post(`${Environment.URL}Auth/entrar`, credentials);
    }

    getUserInfo() {
        return JSON.parse(localStorage.getItem("userInfo"));
    }

    getAuthHeader() {
        return {headers: { Authorization: 'Bearer ' + this.getUserInfo().data.accessToken }}
    }

    logout() {
        localStorage.removeItem("userInfo");
    }
}

export default new AuthService()
