import IChatMessage from "./IChatMessage";
import IChatUser from "./IChatUser";

export default interface IChatInfo {
  chatUser: IChatUser;
  messages: IChatMessage[];
  
}
