import axios from "axios";

export default {
    async login(context, payload) {
        try {
            const logInModel = {
                username: payload.username,
                password: payload.password,
                returnSecureToken: true
            };

            const response = await axios.post('http://localhost:5240/api/account/Login/', logInModel);
            const responseData = response.data;

            const token = payload.token;
            context.commit('setToken', token);
            context.commit('setUser', {
                token: responseData.token,
                tokenExpiration: responseData.expires,
            });
            localStorage.setItem('token', token);
        } catch (error) {
            console.error("Error!", error.response.data);
            throw new Error(error.response.data.message || 'Failed to authenticate.');
        }
    },
    async signup(context, payload) {
        try {
            const signUpData = {
                username: payload.username,
                email: payload.email,
                password: payload.password,
                returnSecureToken: true
            };

            const response = await axios.post('http://localhost:5240/api/account/Register/', signUpData);
            const responseData = response.data;

            console.log(responseData);

            context.commit('setUser', {
                token: responseData.token,
                tokenExpiration: responseData.expires,
            });
        } catch (error) {
            console.error(error.response.data);
            throw new Error(error.response.data.message || 'Failed to authenticate.');
        }
    },
    logout(context) {
        context.commit('setUser', {
            token: null,
            userId: null,
            tokenExpiration: null
        });
        localStorage.removeItem('token');
    }
};