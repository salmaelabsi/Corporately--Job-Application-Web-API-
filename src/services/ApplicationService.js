import axios from "axios";
const apiPath = "http://localhost:5240/api/application/";

export default {
    getApplication(){
        return axios.get(apiPath + "ApplicantsList");
    },
    addApplicationByTitle(jobTitle) {
        return axios.post(apiPath + "AddApplicationByJobTitle", jobTitle);
    },
    deleteApplicationByTitle(jobTitle){
        return axios.delete(apiPath + "DeleteApplicationByJobTitle", jobTitle);
    }
}