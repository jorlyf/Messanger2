import { createSlice } from "@reduxjs/toolkit";
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
    
  }
});

export default chatSlice.reducer;
