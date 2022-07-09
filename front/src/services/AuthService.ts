import $api, { ResponseStatus } from "../http";
import { loginSuccess, loginInit, loginError } from "../redux/slices/authSlice";
import { AppDispatch } from "../redux/store";

export default class AuthService {
  static login = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post("/api/Auth/Login", { Login: login, Password: password });
      if (response.status === ResponseStatus.OK) {
        dispatch(loginSuccess({ login: login, token: response.data.token }));
      }
    } catch (error) {
      dispatch(loginError());
    }
  }

  static registration = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post("/api/Auth/Registrate", { Login: login, Password: password });
      if (response.status === ResponseStatus.OK) {
        dispatch(loginSuccess({ login: login, token: response.data.token }));
      }
    } catch (error) {
      dispatch(loginError());
    }
  }

  static logout = async () => {

  }

  static validateInput = (login: string, password: string): boolean => {
    if (login.length < 3 || login.length > 24) return false;
    if (password.length < 5 || password.length > 24) return false;

    return true;
  }
}
