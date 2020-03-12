import axios from 'axios';
const config = axios.create({
    baseURL: 'https://localhost:44300',
    headers: {'Authorization': 'Bearer '+localStorage.getItem('jwt')}
  });

export default config;