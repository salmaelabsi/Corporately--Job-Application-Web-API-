import axios from "axios";
const apiPath = "http://localhost:5240/api/job/";

export default {
    getJobList(){
       return axios.get(apiPath + "JobsList");
    },
    getJobById(id){
        return axios.get(apiPath + "GetJobByID/" + id);
    },
    createJob(newJobInfo){
        return axios.post(apiPath + "CreateNewJob", newJobInfo);
    },
    updateJob(id, existingJobInfo){
        return axios.put(apiPath + "UpdateExistingJob/" + id, existingJobInfo);
    },
    deleteJob(id){
        return axios.delete(apiPath + "DeleteJob/" + id);
    }
}