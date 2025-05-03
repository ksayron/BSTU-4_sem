import axios from 'axios';
import { Post, NewPost } from './types';

const BASE_URL = 'https://jsonplaceholder.typicode.com/posts';

export const fetchPostsAPI = async (): Promise<Post[]> => {
    const response = await axios.get<Post[]>(BASE_URL);
    return response.data;
};

export const createPostAPI = async (post: NewPost): Promise<Post> => {
    const response = await axios.post<Post>(BASE_URL, post);
    return response.data;
};

export const updatePostAPI = async (post: Post): Promise<Post> => {
    const response = await axios.put<Post>(`${BASE_URL}/${post.id}`, post);
    return response.data;
};

export const deletePostAPI = async (id: number): Promise<void> => {
    await axios.delete(`${BASE_URL}/${id}`);
};