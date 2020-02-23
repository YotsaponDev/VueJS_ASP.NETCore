import axios from 'axios';
const config = axios.create({
    baseURL: 'https://localhost:44300',
  });

export default config;