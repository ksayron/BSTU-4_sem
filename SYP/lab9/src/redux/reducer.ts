import {
    TodoState,
    TodoActionTypes,
    ADD_TODO,
    TOGGLE_TODO,
    EDIT_TODO,
    DELETE_TODO,
} from './types';

const initialState: TodoState = {
    todos: [],
};

export const todoReducer = (
    state = initialState,
    action: TodoActionTypes
): TodoState => {
    switch (action.type) {
        case ADD_TODO:
            const newTodo = {
                id: Date.now(),
                text: action.payload,
                completed: false,
            };
            return { ...state, todos: [newTodo, ...state.todos] };

        case TOGGLE_TODO:
            return {
                ...state,
                todos: state.todos.map(todo =>
                    todo.id === action.payload
                        ? { ...todo, completed: !todo.completed }
                        : todo
                ),
            };

        case EDIT_TODO:
            return {
                ...state,
                todos: state.todos.map(todo =>
                    todo.id === action.payload.id
                        ? { ...todo, text: action.payload.text }
                        : todo
                ),
            };

        case DELETE_TODO:
            return {
                ...state,
                todos: state.todos.filter(todo => todo.id !== action.payload),
            };

        default:
            return state;
    }
};

