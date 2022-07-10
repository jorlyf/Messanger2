import $api, { ResponseStatus } from "../http";
import IUserLoginSuccessDataDto from "../models/responses/IUserLoginSuccessDataDto";
import { loginSuccess, loginInit, loginError } from "../redux/slices/authSlice";
import { AppDispatch } from "../redux/store";

export default class AuthService {
  static loginByToken = async (dispatch: AppDispatch, token: string) => {
    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/api/Auth/LoginByToken", token);
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      dispatch(loginSuccess({ login: response.data.login, token: response.data.token }));

    } catch (error) {
      dispatch(loginError());
    }
  };
  static login = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/api/Auth/Login", { Login: login, Password: password });
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      dispatch(loginSuccess({ login: login, token: response.data.token }));

    } catch (error) {
      dispatch(loginError());
    }
  };

  static registration = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/api/Auth/Registrate", { Login: login, Password: password });
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      dispatch(loginSuccess({ login: login, token: response.data.token }));

    } catch (error) {
      dispatch(loginError());
    }
  };

  static logout = async () => {

  };

  static validateInput = (login: string, password: string): boolean => {
    if (login.length < 3 || login.length > 24) return false;
    if (password.length < 5 || password.length > 24) return false;

    return true;
  };
}
