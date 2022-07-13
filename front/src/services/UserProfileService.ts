import $api, { ResponseStatus } from "../http";
import { setUsername } from "../redux/slices/chatSlice";
import { AppDispatch } from "../redux/store";
/////////////////\


export default class UserProfileService {
  static changeUsername = async (dispatch: AppDispatch, newUsername: string) => {
    try {
      const response = await $api.post("/UserProfile/SetUsername", { newUsername });
      if (response.status !== ResponseStatus.OK) { throw new Error(); }
      
      dispatch(setUsername(response.data));
    } catch (error) {

    }
  }
}