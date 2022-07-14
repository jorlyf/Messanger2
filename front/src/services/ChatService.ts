import $api, { ResponseStatus } from "../http";
/////////////////////////////////////////////
import IChatDialog from "../models/IChatDialog";
import IChatMessage from "../models/IChatMessage";
import IChatUser from "../models/IChatUser";
import IUserDto from "../models/responses/IUserDto";

export default class ChatService {
  static sendMessage = async (dialog: IChatDialog, message: IChatMessage) => {

  }

  static getChatDialogs = async () => {
    //const response = await $api.get("/Chat/");
  }

  static getMessages = async (dialog: IChatDialog) => {

  }

  static searchUsersByLogin = async (login: string) => {
    try {
      const response = await $api.get<IUserDto[]>(`/Chat/GetUsersByLogin?Login=${login}`);
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      const users: IChatUser[] = [];
      response.data.forEach(u => {
        users.push({
          id: u.id,
          login: u.login,
          username: u.username,
          avatarUrl: u.avatarUrl
        });
      });

      return users;
    } catch (error) {
      return [];
    }
  }
}