import {createRouter, createWebHistory} from 'vue-router';

import TheJobs from "./components/pages/TheJobs.vue";
import AvailableJobs from "./components/jobs/AvailableJobs.vue";
import JobApplication from "./components/pages/JobApplication.vue";
import TheAdmin from "./components/pages/TheAdmin.vue";
import store from "./store/index.js";

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {path: '/', redirect: '/jobs'},
        {path: '/jobs', component: TheJobs,
            children: [
                {path: ':jobId', component: AvailableJobs},
            ]
        },

        {path: '/:jobId/application', name: 'ApplyForm', component: JobApplication, meta: { requiresAuth: true }, props: true },
        { path: '/admin', component: TheAdmin, meta: { requiresAuth: true } },
        { path: '/:notFound(.*)' }
    ]
});

router.beforeEach((to, from, next) => {
    if(to.meta.requiresAuth && !store.getters.isAuthenticated){
        next('/jobs');
    } else {
        next();
    }
});

export default router;