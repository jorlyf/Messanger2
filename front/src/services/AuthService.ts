import $api from "../http";

export default class AuthService {
  static login = (login: string, password: string) => {
    if (!AuthService.validate(login, password)) return null;
  }

  static register = (login: string, password: string) => {
    if (!AuthService.validate(login, password)) return null;

    return $api.post("/register");
  }
  
  static logout = () => {

  }

  static validate = (login: string, password: string): boolean => {
    if (login.length < 3 || login.length > 24) return false;
    if (password.length < 5 || password.length > 24) return false;

    return true;
  }
}
