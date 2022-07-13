import React from "react";
import { useDispatch } from "react-redux";
import { setInitAuthAttempt } from "../redux/slices/authSlice";
import useAppSelector from "./useAppSelector";

import AuthService from "../services/AuthService";

const useAuth = () => {
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

    AuthService.loginByToken(dispatch);

  }, [wasInitAuthAttempt, isLogging, dispatch]);
}

export default useAuth;
