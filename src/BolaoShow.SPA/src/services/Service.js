import axios from 'axios';

import Auth from './AuthService';
import environment from '../environments/environment';

class Services {
    get(route) {
        return axios.get(`${environment.URL}${route}`, Auth.getAuthHeader());
    }

    getById(route, id) {
        return axios.get(`${environment.URL}${route}/${id}`, Auth.getAuthHeader());
    }

    async post(route, data) {
        return await axios.post(`${environment.URL}${route}`, data, Auth.getAuthHeader());
    }

    put(route, data) {
        return axios.put(`${environment.URL}${route}`, data, Auth.getAuthHeader());
    }
}

export default new Services()