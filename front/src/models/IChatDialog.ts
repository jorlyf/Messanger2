import IChatMessage from "./IChatMessage";
import IChatUser from "./IChatUser";

export default interface IChatDialog {
  id: number;
  messages: IChatMessage[];
  users: IChatUser[];
}