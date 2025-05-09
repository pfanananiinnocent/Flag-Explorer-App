import axios from "axios";

const API_URL = "http://localhost:5093/countries"; 


export const fetchCountries = async () => {
  const res = await axios.get(API_URL);
  return res.data;
};

export const fetchCountryByName = async (name: string) => {
  const res = await axios.get(`${API_URL}/${name}`);
  return res.data;
};
