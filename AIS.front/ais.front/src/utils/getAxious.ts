import axios from 'axios';
import { Config } from '../config';

const { SERVICE_URL: serviceURL } = Config as any || "";

const axiosInstance = axios.create({
  baseURL: serviceURL,
});

export default axiosInstance;
