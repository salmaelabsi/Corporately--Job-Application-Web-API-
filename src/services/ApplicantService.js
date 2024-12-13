import axios from "axios";
const apiPath = "http://localhost:5240/api/applicant/";

export default {
    getApplicantsList(){
        return axios.get(apiPath + "ApplicantsList");
    },
    /* getApplicantByID(id){
        return axios.get(apiPath + "GetApplicantByID/" + id);
    }, */ // will use in future updates
    createApplicant(id, newApplicantInfo){
        console.log("newAppInfo", newApplicantInfo);
        return axios.post(apiPath+"CreateApplicationByJobId/" + id, newApplicantInfo);
    },
    /* updateApplicant(id, existingApplicant){
        return axios.put(apiPath + "UpdateApplicant/" + id, existingApplicant);
    }, */ // will use in future updates
    deleteApplicant(id){
        return axios.delete(apiPath + "DeleteApplicant/" + id);
    }
}