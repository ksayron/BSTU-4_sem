import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { Post, NewPost } from './types';
import { fetchPostsAPI, createPostAPI, updatePostAPI, deletePostAPI } from './postsAPI';

interface PostsState {
    posts: Post[];
    loading: boolean;
    error: string | null;
}

const initialState: PostsState = {
    posts: [],
    loading: false,
    error: null,
};

export const fetchPosts = createAsyncThunk('posts/fetchPosts', fetchPostsAPI);
export const createPost = createAsyncThunk('posts/createPost', createPostAPI);
export const updatePost = createAsyncThunk('posts/updatePost', updatePostAPI);
export const deletePost = createAsyncThunk('posts/deletePost', deletePostAPI);

const postsSlice = createSlice({
    name: 'posts',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchPosts.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(fetchPosts.fulfilled, (state, action) => {
                state.posts = action.payload;
                state.loading = false;
            })
            .addCase(fetchPosts.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Error fetching posts';
            })
            .addCase(createPost.fulfilled, (state, action) => {
                state.posts.unshift(action.payload);
            })
            .addCase(updatePost.fulfilled, (state, action) => {
                const index = state.posts.findIndex((p) => p.id === action.payload.id);
                if (index !== -1) state.posts[index] = action.payload;
            })
            .addCase(deletePost.fulfilled, (state, action) => {
                state.posts = state.posts.filter((p) => p.id !== action.meta.arg);
            });
    },
});

export default postsSlice.reducer;