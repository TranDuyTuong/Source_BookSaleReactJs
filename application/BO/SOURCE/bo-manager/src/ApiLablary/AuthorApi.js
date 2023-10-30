import instance from "../ApiLablary/Axios";
import { SeachAuthor_Post } from "../ObjectCommon/ApiCommon";
import { post } from "../Contants/DataContant";

// Api Login User
const AuthorAPI = (info, URL, TYPE) => {
  switch (TYPE) {
    case "get":
      const resultGet = instance.get(`${URL}`, info);
      return resultGet;
    case "post":
      const resultPost = instance.post(`${URL}`, info);
      return resultPost;
    default:
      break;
  }
};

// Handle Seach Area
export const HandleSeachAuthor = async (request) => {
  const data = await AuthorAPI(request, SeachAuthor_Post, post);
  return data;
};
