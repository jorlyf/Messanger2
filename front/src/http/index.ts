import axios from "axios";

export const BASE_URL = "https://localhost:5000";

const $api = axios.create({
  baseURL: BASE_URL
});

$api.interceptors.request.use(config => {
  config.headers!.Authorization = localStorage.getItem("token") || "";
  return config;
});

export default $api;