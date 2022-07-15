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

  static getChatDialog = async (id: number) => {
    
  }

  static getMessages = async (dialog: IChatDialog) => {

  }

  static searchUsersByContainsLogin = async (login: string): Promise<IChatUser[]> => {
    try {
      if (!login) return [];
      const response = await $api.get<IUserDto[]>(`/Chat/GetUsersByContainsLogin?Login=${login}`);
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