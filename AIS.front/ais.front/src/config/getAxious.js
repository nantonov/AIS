import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:5001',
});

export const addAccessTokenInterceptor = (getAccessTokenSilently) => {
  axiosInstance.interceptors.request.use(async (config) => {
    const token = await getAccessTokenSilently();
    const newConfig = { ...config };
    newConfig.headers.Authorization = `Bearer ${token}`;
    return newConfig;
  });
};

export default axiosInstance;
