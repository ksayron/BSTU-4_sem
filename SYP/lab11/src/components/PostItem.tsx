import { Post } from '../features/posts/types';
import styles from './PostItem.module.css';

interface Props {
    post: Post;
    onEdit: () => void;
    onDelete: () => void;
}

export default function PostItem({ post, onEdit, onDelete }: Props) {
    return (
        <div className={styles.item}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
            <div className={styles.buttons}>
                <button onClick={onEdit}>Edit</button>
                <button onClick={onDelete}>Delete</button>
            </div>
        </div>
    );
}
