import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface IAuthState {
  login: string;
  isAuthorized: boolean;
  isLogging: boolean;
}

const initialState: IAuthState = {
  login: "",
  isAuthorized: false,
  isLogging: false,
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
      localStorage.setItem("token", action.payload.token);
      state.isAuthorized = true;
    },
    loginError(state) {
      state.isLogging = false;
      state.login = "";
      localStorage.removeItem("token");
      state.isAuthorized = false;
    },
  }
});

export const { loginInit, loginSuccess, loginError } = authSlice.actions;

export default authSlice.reducer;
