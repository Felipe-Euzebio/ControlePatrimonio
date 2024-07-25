import axios, { AxiosError, AxiosResponse } from 'axios';
import { toast } from 'react-toastify';
import { router } from '../router/Routes';
import { PaginatedResponse } from '../models/pagination';
import { store } from '../store/configureStore';

axios.defaults.baseURL = import.meta.env.VITE_API_URL; 
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response?.data;

axios.interceptors.request.use(config => {
    const token = store.getState().user.user?.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
});

axios.interceptors.response.use(async response => {
    const pagination = response.headers['pagination'];

    if (pagination) {
        response.data = new PaginatedResponse(response.data, JSON.parse(pagination));
        return response;
    }

    return response;
}, (error: AxiosError) => {
    const { data, status } = error.response as AxiosResponse;

    switch (status) {
        case 400:
            if (data.errors) {
                const modalStateErrors: string[] = [];

                for (const key in data.errors) {
                    if (data.errors[key]) {
                        modalStateErrors.push(data.errors[key]);
                    }
                }

                throw modalStateErrors.flat();
            }
            toast.error(data.title);
            break;

        case 401:
            toast.error(data.title);
            break;

        case 403:
            toast.error('You are not allowed to do that!');
            break;

        case 404:
            router.navigate('/not-found');
            break;

        case 500:
            router.navigate('/server-error', {state: {error: data}});
            break;
    
        default:
            break;
    }

    return Promise.reject(error.response);
})

const requests = {
    get: (url: string, params?: URLSearchParams)    => axios.get(url, {params}).then(responseBody),
    post: (url: string, body: {})                   => axios.post(url, body).then(responseBody),
    put: (url: string, body: {})                    => axios.put(url, body).then(responseBody),
    delete: (url: string)                           => axios.delete(url).then(responseBody),
    postForm: (url: string, data: FormData)         => axios.post(url, data, {
        headers: {'Content-type': 'multipart/form-data'}
    }).then(responseBody),
    putForm: (url: string, data: FormData)          => axios.put(url, data, {
        headers: {'Content-type': 'multipart/form-data'}
    }).then(responseBody),
}

function createFormData(item: any){
    const formData = new FormData();
    for(const key in item){
        formData.append(key, item[key]);
    }
    return formData;
}

const Users = {
    login: (values: any)    => requests.post('users/login', values),
    register: (values: any) => requests.post('users/register', values),
    currentUser: ()         => requests.get('users/currentUser'),
}

const agent = {
    Users,
}

export default agent;