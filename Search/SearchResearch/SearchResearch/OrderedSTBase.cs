using System;
using System.Collections.Generic;

namespace SearchResearch
{
    public abstract class OrderedSTBase<TKey, TValue> : STBase<TKey, TValue> where TKey : IComparable
    {
        public abstract TKey Min();

        public abstract TKey Max();

        public abstract TKey Floor(TKey key);

        public abstract TKey Ceiling(TKey key);

        public abstract int Rank(TKey key);

        public abstract TKey Select(int k);

        public virtual void DeleteMin()
        {
            Delete(Min());
        }

        public virtual void DeleteMax()
        {
            Delete(Max());
        }

        public virtual int Size(TKey lo, TKey hi)
        {
            if (hi.CompareTo(lo) < 0)
            {
                return 0;
            }
            else if (Contains(hi))
            {
                return Rank(hi) - Rank(lo) + 1;
            }
            else
            {
                return Rank(hi) - Rank(lo);
            }
        }

        public abstract IEnumerable<TKey> Keys(TKey lo, TKey hi);

        public override IEnumerable<TKey> Keys()
        {
            return Keys(Min(), Max());
        }
    }

    public class BinarySearchST<TKey, TValue> : OrderedSTBase<TKey, TValue> where TKey : IComparable
    {
        private TKey[] _keys;

        private TValue[] _values;

        private int _count;

        public BinarySearchST(int capacity)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
        }

        public override void Put(TKey key, TValue value)
        {
            int rank = Rank(key);
            if (rank < _count && _keys[rank].CompareTo(key) == 0)
            {
                _values[rank] = value;
            }
            else
            {
                for (int i = _count; i > rank; i--)
                {
                    _keys[i] = _keys[i - 1];
                    _values[i] = _values[i - 1];
                }
                _keys[rank] = key;
                _values[rank] = value;
                _count++;
            }
        }

        public override TValue Get(TKey key)
        {
            if (IsEmpty())
            {
                return default(TValue);
            }
            int rank = Rank(key);
            if (rank < _count && _keys[rank].CompareTo(key) == 0)
            {
                return _values[rank];
            }
            else
            {
                return default(TValue);
            }
        }

        public override int Size()
        {
            return _count;
        }

        public override TKey Min()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return _keys[0];
        }

        public override TKey Max()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return _keys[_count - 1];
        }

        public override TKey Floor(TKey key)
        {
            int rank = Rank(key);
            if (rank < _count && _keys[rank].CompareTo(key) == 0)
            {
                return _keys[rank];
            }
            else
            {
                return _keys[rank - 1];
            }  
        }

        public override TKey Ceiling(TKey key)
        {
            int rank = Rank(key);
            return _keys[rank];
        }

        public override int Rank(TKey key)
        {
            return Rank(key, 0, _count - 1);
        }

        public override TKey Select(int k)
        {
            if (k >= _count)
            {
                throw new InvalidOperationException();
            }
            return _keys[k];
        }

        public override IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            int loRank = Rank(lo);
            int hiRank = Rank(hi);
            List<TKey> keys = new List<TKey>();
            for (int i = loRank; i <= hiRank; i++)
            {
                keys.Add(_keys[i]);
            }
            return keys;
        }

        public override void Delete(TKey key)
        {
            int rank = Rank(key);
            if (rank < _count && _keys[rank].CompareTo(key) == 0)
            {
                for (int i = rank; i < --_count; i++)
                {
                    _keys[i] = _keys[i + 1];
                    _values[i] = _values[i + 1];
                }
            }
        }

        private int Rank(TKey key, int lo, int hi)
        {
            if (hi < lo)
            {
                return lo;
            }
            int mid = (lo + hi) / 2;
            int cmp = key.CompareTo(_keys[mid]);
            if (cmp < 0)
            {
                return Rank(key, lo, mid - 1);
            }
            else if (cmp > 0)
            {
                return Rank(key, mid + 1, hi);
            }
            else
            {
                return mid;
            }
        }
    }

    public class BinarySearchTreeST<TKey, TValue> : OrderedSTBase<TKey, TValue> where TKey : IComparable
    {
        public override void Put(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public override TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }

        public override TKey Min()
        {
            throw new NotImplementedException();
        }

        public override TKey Max()
        {
            throw new NotImplementedException();
        }

        public override TKey Floor(TKey key)
        {
            throw new NotImplementedException();
        }

        public override TKey Ceiling(TKey key)
        {
            throw new NotImplementedException();
        }

        public override int Rank(TKey key)
        {
            throw new NotImplementedException();
        }

        public override TKey Select(int k)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            throw new NotImplementedException();
        }

        public class Node<NKey, NValue> where NKey : IComparable
        {
            public NKey Key { get; set; }

            public NValue Value { get; set; }

            public Node<NKey, NValue> Left { get; set; }

            public Node<NKey, NValue> Right { get; set; }
        }
    }
}