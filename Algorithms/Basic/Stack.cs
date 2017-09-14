using System;

namespace Basic
{
    public class Stack<T>
    {
        private Node<T> _start;

        //add an item
        public void Push(T item)
        {
            var node = new Node<T>() { Value = item };
            if (_start != null)
            {
                node.Next = _start;
            }
            _start = node;
        }

        //remove the most recently added item
        public T Pop()
        {
            if (_start != null)
            {
                var startValue = _start.Value;
                _start = _start.Next;
                return startValue;
            }
            else
            {
                return default(T);
            }
        }

        //is the stack empty?
        public bool IsEmpty()
        {
            return _start == null;
        }

        //number of items in the stack
        public int Size()
        {
            int i = 0;
            var node = _start;
            while (node != null)
            {
                node = node.Next;
                i++;
            }
            return i;
        }
    }


    public class Stack1<T>
    {
        private const int initLength = 10;
        private T[] _list = new T[initLength];
        private int _start = 0;

        //add an item
        public void Push(T item)
        {
            if (_start >= _list.Length)
            {
                T[] newList = new T[_list.Length + initLength];
                Array.Copy(_list, newList, _list.Length);
                _list = newList;
            }
            _list[_start++] = item;
        }

        //remove the most recently added item
        public T Pop()
        {
            if (_start > 0)
            {
                return _list[--_start];
            }
            else
            {
                return default(T);
            }
        }

        //is the stack empty?
        public bool IsEmpty()
        {
            return _start <= 0;
        }

        //number of items in the stack
        public int Size()
        {
            return _start;
        }
    }