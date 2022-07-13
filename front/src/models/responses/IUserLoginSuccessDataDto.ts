export default interface IUserLoginSuccessDataDto {
  id: number;
  login: string;
  username?: string;
  avatarUrl?: string;
  token: string;
}