import $api from "../http";
import { AppDispatch } from "../redux/store";
/////////////////////////////////////////////
import IChatDialog from "../models/IChatDialog";
import IChatMessage from "../models/IChatMessage";

export default class ChatService {
  sendMessage(dialog: IChatDialog, message: IChatMessage) {

  }

  getChatDialogs() {

  }

  getMessages(dialog: IChatDialog) {

  }

  getOwner(dispatch: AppDispatch, token: string) {
    $api.post("/", token);
  }
}