import { createSlice } from "@reduxjs/toolkit";

interface IAuthState {
    login: string;
    isAuthorized: boolean;
}

const initialState: IAuthState = {
    login: "",
    isAuthorized: false
}

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {

    }
});

export default authSlice.reducer;