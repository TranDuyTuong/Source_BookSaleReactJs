import instance from "../ApiLablary/Axios";
import { UserLogin_Post } from "../ObjectCommon/ApiCommon";

// Api Login User
export const postDataLoginAPI = (info) => {
  const result = instance.post(`${UserLogin_Post}`, info);
  return result;
};
