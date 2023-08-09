import axios from "axios";
import { BaseAddress } from "../ObjectCommon/ApiCommon";

const instance = axios.create({
  baseURL: BaseAddress,
  timeout: 300000,
});

instance.interceptors.response.use(
  // success
  (reponse) => {
    return reponse.data;
  },
  // error
  (error) => {
    console.log(error);
  }
);

export default instance;
