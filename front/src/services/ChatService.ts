import $api from "../http";
import { AppDispatch } from "../redux/store";
/////////////////////////////////////////////
import IChatDialog from "../models/IChatDialog";
import IChatMessage from "../models/IChatMessage";

export default class ChatService {
  static sendMessage = async (dialog: IChatDialog, message: IChatMessage) => {

  }

  static getChatDialogs = async () => {
    const response = await $api.get("/Chat/");
  }

  static getMessages = async (dialog: IChatDialog) => {

  }
}