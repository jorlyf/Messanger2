import { createSlice, PayloadAction } from "@reduxjs/toolkit";
///////////////////////////////////////////////
import IChatOwner from "../../models/IChatOwner";
import IChatUser from "../../models/IChatUser";

interface IChatState {
  owner: IChatOwner | null;
  currentChatUser: IChatUser | null;
  chatUsers: IChatUser[];
}

const initialState: IChatState = {
  owner: null,
  currentChatUser: null,
  chatUsers: [],
}

const chatSlice = createSlice({
  name: "chat",
  initialState,
  reducers: {
    setOwnerUser(state, action: PayloadAction<{ id: number, username: string, avatarUrl: string }>) {
      state.owner = {
        id: action.payload.id,
        username: action.payload.username,
        avatarUrl: action.payload.avatarUrl
      };
    },
    changeUsername(state, action: PayloadAction<string>) {
      if (state.owner === null) return;
      state.owner.username = action.payload;
    },
    changeAvatarUrl(state, action: PayloadAction<string>) {
      if (state.owner === null) return;
      state.owner.avatarUrl = action.payload;
    }
  }
});

export default chatSlice.reducer;
