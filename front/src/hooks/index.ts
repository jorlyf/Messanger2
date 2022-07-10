import React from "react";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux"
import { setInitAuthAttempt } from "../redux/slices/authSlice";
import { RootState } from "../redux/store"
import AuthService from "../services/AuthService";

export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;

export const useAuth = () => {
  const dispatch = useDispatch();

  const wasInitAuthAttempt = useAppSelector(state => state.auth.wasInitAuthAttempt);
  const isLogging = useAppSelector(state => state.auth.isLogging);

  React.useEffect(() => {
    if (wasInitAuthAttempt) return;
    if (isLogging) return;

    const token = localStorage.getItem("token");
    if (!token) {
      dispatch(setInitAuthAttempt(true));
      return;
    }

    AuthService.loginByToken(dispatch, token);

  }, [wasInitAuthAttempt, isLogging, dispatch]);
};