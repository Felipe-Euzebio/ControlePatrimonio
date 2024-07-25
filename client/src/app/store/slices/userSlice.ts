import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { User } from "../../models/user";
import { FieldValues } from "react-hook-form";
import agent from "../../api/agent";
import { router } from "../../router/Routes"
import { toast } from 'react-toastify';

interface UserState {
    user: User | null;
}

const initialState: UserState = {
    user: null
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    'users/signInUser',
    async (data, thunkAPI) => {
        try {
            const user = await agent.Users.login(data);
            localStorage.setItem('user', JSON.stringify(user));
            return user;
        } catch (error: any) {
            return thunkAPI.rejectWithValue({error: error.message});
        }
    }
)

export const fetchCurrentUser = createAsyncThunk<User>(
    'users/fetchCurrentUser',
    async (_, thunkAPI) => {
        thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem('user')!)));
        try {
            const user = await agent.Users.currentUser();
            localStorage.setItem('user', JSON.stringify(user)); 
            return user;
        } catch (error: any) {
            return thunkAPI.rejectWithValue({error: error.message});
        }
    },
    {
        condition: () => {
            if (!localStorage.getItem('user')) return false;
        }
    }
)

export const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        signOut: (state) => {
            state.user = null;
            localStorage.removeItem('user');
            router.navigate('/');
        },
        setUser: (state, action) => {
            let claims = JSON.parse(atob(action.payload.token.split('.')[1]));
            let roles = claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            state.user = {...action.payload, roles: typeof(roles) === 'string' ? [roles] : roles};
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.rejected, (state) => {
            state.user = null;
            localStorage.removeItem('user');
            toast.error('Session expired - please login again');
            router.navigate('/');
        });
        
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            let claims = JSON.parse(atob(action.payload.token.split('.')[1]));
            let roles = claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            state.user = {...action.payload, roles: typeof(roles) === 'string' ? [roles] : roles};
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (_, action) => {
            throw action.payload;
        });
    })
})

export const { signOut, setUser } = userSlice.actions;
    