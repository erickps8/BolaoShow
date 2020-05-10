import axios from 'axios';

import Auth from './AuthService';
import environment from '../environments/environment';

class Services {
    async get(route) {
        return await axios.get(`${environment.URL}${route}`, Auth.getAuthHeader());
    }

    async getById(route, id) {
        return await axios.get(`${environment.URL}${route}/${id}`, Auth.getAuthHeader());
    }

    async post(route, data) {
        return await axios.post(`${environment.URL}${route}`, data, Auth.getAuthHeader());
    }

    async put(route, data) {
        return await axios.put(`${environment.URL}${route}`, data, Auth.getAuthHeader());
    }
}

export default new Services()