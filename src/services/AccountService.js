import axios from "axios";
const apiPath = "http://localhost:5240/api/account/";

export default {
    login(username, password) {
        return axios.post(apiPath + "Login", username, password);
    },
    signup(username, email, password) {
        return axios.post(apiPath + "Register", username, email, password);
    },
}