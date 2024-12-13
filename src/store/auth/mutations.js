export default {
    setUser(state, payload) {
        state.token = payload.token;
        state.userId = payload.userId;
        state.tokenExpiration = payload.tokenExpiration;
    },
    //new code
    setToken(state, token) {
        state.token = token;
    },
    clearAuthData(state) {
        state.token = null;
        state.user = null;
    },
};