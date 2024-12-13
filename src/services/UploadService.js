import axios from "axios";
const apiPath = "http://localhost:5240/api/upload";

export default {
    upload(file){
        return axios.post(apiPath, file, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
    }
}