import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootStateOrAny } from 'react-redux';
import { increment, decrement, reset } from '../redux/actions';
import Button from './Button';

const Counter: React.FC = () => {
    const count = useSelector((state: RootStateOrAny) => state.value);
    const dispatch = useDispatch();

    return (
        <div>
            <h1>Counter: {count}</h1>
            <div>
                <Button onClick={() => dispatch(increment())}>+</Button>
                <Button onClick={() => dispatch(decrement())}>-</Button>
                <Button onClick={() => dispatch(reset())}>Reset</Button>
            </div>
        </div>
    );
};

export default Counter;
    