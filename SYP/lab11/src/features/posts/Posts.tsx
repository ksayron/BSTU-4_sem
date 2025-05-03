import { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks';
import { fetchPosts, createPost, updatePost, deletePost } from './postsSlice';
import { Post, NewPost } from './types';
import PostForm from '../../components/PostForm';
import PostItem from '../../components/PostItem';

export default function Posts() {
    const dispatch = useAppDispatch();
    const { posts, loading, error } = useAppSelector(state => state.posts);
    const [editingPost, setEditingPost] = useState<Post | null>(null);

    useEffect(() => {
        dispatch(fetchPosts());
    }, [dispatch]);

    return (
        <div style={{ padding: '20px' }}>
            <h1>Post managing</h1>
            <PostForm
                editingPost={editingPost}
                onSave={(post) => {
                    if (editingPost) {
                        dispatch(updatePost({ ...editingPost, ...post }));
                    } else {
                        dispatch(createPost(post));
                    }
                    setEditingPost(null);
                }}
                onCancel={() => setEditingPost(null)}
            />

            {loading && <p>Загрузка...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}

            {posts.map((post) => (
                <PostItem
                    key={post.id}
                    post={post}
                    onEdit={() => setEditingPost(post)}
                    onDelete={() => dispatch(deletePost(post.id))}
                />
            ))}
        </div>
    );
}
