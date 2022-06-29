import IChatUser from "./IChatUser";
import IChatAttachment from "./IChatAttachment";

export default interface IChatMessage {
  id: number;
  sender: IChatUser;
  text: string;
  attachments: IChatAttachment[];
}
