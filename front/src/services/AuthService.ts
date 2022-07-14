import $api, { ResponseStatus } from "../http";
import { loginSuccess, loginInit, loginError } from "../redux/slices/authSlice";
import { AppDispatch } from "../redux/store";
///////////////////\
import IUserLoginSuccessDataDto from "../models/responses/IUserLoginSuccessDataDto";
import { setOwnerUser } from "../redux/slices/chatSlice";

export default class AuthService {

  static loginByToken = async (dispatch: AppDispatch) => {
    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/Auth/LoginByToken");
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      AuthService.onSuccessLogin(dispatch, response.data);

    } catch (error) {
      dispatch(loginError());
    }
  }

  static login = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/Auth/Login", { Login: login, Password: password });
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      AuthService.onSuccessLogin(dispatch, response.data);

    } catch (error) {
      dispatch(loginError());
    }
  }

  static registration = async (dispatch: AppDispatch, login: string, password: string) => {
    if (!AuthService.validateInput(login, password)) return null;

    dispatch(loginInit());
    try {
      const response = await $api.post<IUserLoginSuccessDataDto>("/Auth/Registrate", { Login: login, Password: password });
      if (response.status !== ResponseStatus.OK) { throw new Error(); }

      AuthService.onSuccessLogin(dispatch, response.data);

    } catch (error) {
      dispatch(loginError());
    }
  }

  static logout = async () => {
    localStorage.removeItem("token");
    window.location.reload();
  }

  static validateInput = (login: string, password: string): boolean => {
    if (login.length < 3 || login.length > 24) return false;
    if (password.length < 5 || password.length > 24) return false;

    return true;
  }

  static onSuccessLogin = (dispatch: AppDispatch, data: IUserLoginSuccessDataDto) => {
    dispatch(loginSuccess({ login: data.login, token: data.token }));
    dispatch(setOwnerUser({ id: data.id, login: data.login, username: data.username, avatarUrl: data.avatarUrl }));
  }
}
