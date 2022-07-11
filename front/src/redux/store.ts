import { configureStore } from "@reduxjs/toolkit";

import auth from "./slices/authSlice";
import chat from "./slices/chatSlice";

export const store = configureStore({
    reducer: {
        auth,
        chat
    }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
