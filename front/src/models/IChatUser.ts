import IChatInfo from "./IChatInfo";

export default interface IChatUser {
  id: number;
  username: string;
  avatarUrl: string;
  chatInfo: IChatInfo;
}
