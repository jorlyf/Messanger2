import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface IAuthState {
  login: string;
  token: string;
  isAuthorized: boolean;
  isLogging: boolean;
  wasInitAuthAttempt: boolean;
}

const initialState: IAuthState = {
  login: "",
  token: "",
  isAuthorized: false,
  isLogging: false,
  wasInitAuthAttempt: false
}

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    loginInit(state) {
      state.isLogging = true;
    },
    loginSuccess(state, action: PayloadAction<{ login: string, token: string }>) {
      state.isLogging = false;
      state.login = action.payload.login;
      state.token = action.payload.token;
      localStorage.setItem("token", action.payload.token);
      state.isAuthorized = true;
      state.wasInitAuthAttempt = true;
    },
    loginError(state) {
      state.isLogging = false;
      state.login = "";
      state.token = "";
      localStorage.removeItem("token");
      state.isAuthorized = false;
      state.wasInitAuthAttempt = true;
    },
    setInitAuthAttempt(state, action: PayloadAction<boolean>) {
      state.wasInitAuthAttempt = action.payload;
    }
  }
});

export const { loginInit, loginSuccess, loginError, setInitAuthAttempt } = authSlice.actions;

export default authSlice.reducer;
