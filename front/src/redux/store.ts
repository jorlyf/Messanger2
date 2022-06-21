import { configureStore } from "@reduxjs/toolkit";

import auth from "./slices/authSlice";

export const store = configureStore({
    reducer: {
        auth
    }
});

type RootState = ReturnType<typeof store.getState>;
