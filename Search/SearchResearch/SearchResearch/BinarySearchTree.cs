using System;
using System.Collections.Generic;

namespace SearchResearch
{
    public class BinarySearchTree_Loop<TKey, TValue> : OrderedSTBase<TKey, TValue> where TKey : IComparable
    {
        private Node<TKey, TValue> _root;

        private int _length;

        public override void Put(TKey key, TValue value)
        {
            if (_root == null)
            {
                _root = new Node<TKey, TValue>(key, value);
                _length++;
            }
            Node<TKey, TValue> current = _root;
            while (true)
            {
                if (key.CompareTo(current.Key) == 0)
                {
                    current.Value = value;
                    break;
                }
                else if (key.CompareTo(current.Key) > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<TKey, TValue>(key, value);
                        _length++;
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<TKey, TValue>(key, value);
                        _length++;
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            }
        }

        public override TValue Get(TKey key)
        {
            Node<TKey, TValue> current = _root;
            while (current != null)
            {
                if (key.CompareTo(current.Key) == 0)
                {
                    return current.Value;
                }
                else if (key.CompareTo(current.Key) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            return default(TValue);
        }

        public override int Size()
        {
            return _length;
        }

        public override TKey Min()
        {
            if (_root == null)
            {
                throw new InvalidOperationException();
            }
            Node<TKey, TValue> current = _root;
            while (true)
            {
                if (current.Left == null)
                {
                    return current.Key;
                }
                else
                {
                    current = current.Left;
                }
            }
        }

        public override TKey Max()
        {
            if (_root == null)
            {
                throw new InvalidOperationException();
            }
            Node<TKey, TValue> current = _root;
            while (true)
            {
                if (current.Right == null)
                {
                    return current.Key;
                }
                else
                {
                    current = current.Right;
                }
            }
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

        //TODO : 需要重构，不能依赖于Keys()方法
        public override IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            IEnumerable<TKey> allKeys = Keys();
            List<TKey> keys = new List<TKey>();
            foreach (var key in allKeys)
            {
                if (key.CompareTo(lo) >= 0 && key.CompareTo(hi) <= 0)
                {
                    keys.Add(key);
                }
            }
            return keys;
        }

        //TODO : 需要重构为循环的方式
        public override IEnumerable<TKey> Keys()
        {
            List<TKey> keys = new List<TKey>();
            if (_root == null)
            {
                return keys;
            }
            Keys(_root, keys);
            return keys;
        }

        public override void DeleteMin()
        {
            if (_root == null)
            {
                return;
            }
            else if (_root.Left == null)
            {
                if (_root.Right != null)
                {
                    _root = _root.Right;
                }
                else
                {
                    _root = null;
                }
                _length--;
            }
            else
            {
                Node<TKey, TValue> parent = _root;
                Node<TKey, TValue> current = _root.Left;
                while (true)
                {
                    if (current.Left == null)
                    {
                        if (current.Right != null)
                        {
                            parent.Left = current.Right;
                            current.Right = null;
                        }
                        else
                        {
                            parent.Left = null;
                        }
                        _length--;
                        break;
                    }
                    else
                    {
                        parent = current;
                        current = current.Left;
                    }
                }
            }
        }

        public override void DeleteMax()
        {
            if (_root == null)
            {
                return;
            }
            else if (_root.Right == null)
            {
                if (_root.Left != null)
                {
                    _root = _root.Left;
                }
                else
                {
                    _root = null;
                }
                _length--;
            }
            else
            {
                Node<TKey, TValue> parent = _root;
                Node<TKey, TValue> current = _root.Right;
                while (true)
                {
                    if (current.Right == null)
                    {
                        if (current.Left != null)
                        {
                            parent.Right = current.Left;
                            current.Left = null;
                        }
                        else
                        {
                            parent.Right = null;
                        }
                        _length--;
                        break;
                    }
                    else
                    {
                        parent = current;
                        current = current.Right;
                    }
                }
            }
        }

        public override void Delete(TKey key)
        {
           
        }
        
        private void Keys(Node<TKey, TValue> node, List<TKey> keys)
        {
            if (node == null)
            {
                return;
            }
            Keys(node.Left, keys);
            keys.Add(node.Key);
            Keys(node.Right, keys);
        }
    }

    public class BinarySearchTree_Recur<TKey, TValue> : OrderedSTBase<TKey, TValue> where TKey : IComparable
    {
        protected Node<TKey, TValue> _root;

        public override void Put(TKey key, TValue value)
        {
            _root = Put(_root, key, value);
        }

        private Node<TKey, TValue> Put(Node<TKey, TValue> x, TKey key, TValue value)
        {
            if (x == null)
            {
                return new Node<TKey, TValue>(key, value, 1);
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                x.Left = Put(x.Left, key, value);
            }
            else if (cmp > 0)
            {
                x.Right = Put(x.Right, key, value);
            }
            else
            {
                x.Value = value;
            }
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override TValue Get(TKey key)
        {
            Node<TKey, TValue> current = _root;
            while (current != null)
            {
                if (key.CompareTo(current.Key) == 0)
                {
                    return current.Value;
                }
                else if (key.CompareTo(current.Key) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            return default(TValue);
        }

        public override int Size()
        {
            return Size(_root);
        }

        private int Size(Node<TKey, TValue> node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.N;
        }

        public override TKey Min()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return Min(_root).Key;
        }

        protected Node<TKey, TValue> Min(Node<TKey, TValue> x)
        {
            if (x.Left == null)
            {
                return x;
            }
            else
            {
                return Min(x.Left);
            }
        }

        public override TKey Max()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return Max(_root).Key;
        }

        private Node<TKey, TValue> Max(Node<TKey, TValue> x)
        {
            if (x.Right == null)
            {
                return x;
            }
            else
            {
                return Max(x.Right);
            }
        }

        public override TKey Floor(TKey key)
        {
            Node<TKey, TValue> x = Floor(_root, key);
            if (x == null)
            {
                return default(TKey);
            }
            return x.Key;
        }

        /// <summary>
        /// 从一棵树中找到比key小的最大值
        /// </summary>
        /// <param name="x">树的根节点</param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node<TKey, TValue> Floor(Node<TKey, TValue> x, TKey key)
        {
            if (x == null)
            {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                return x;
            }
            if (cmp < 0)
            {
                //key < x.key
                //x以及x的右子树都可以忽略，因为这些都比key大，Floor是找比key小的
                return Floor(x.Left, key);
            }
            //key > x.key
            //x.key比key小，但是不确定是比key小的所有key里面最大的，所以从x的右子树里继续查找
            //只要在右子树中查找就必定返回值，不可能返回null
            Node<TKey, TValue> t = Floor(x.Right, key);
            if (t != null)
            {
                //在右子树中找到一个比key小的，这个key肯定比x.key大，所以返回这个值
                return t;
            }
            else
            {
                //在右子树中没有找到比key小的，那x.key就是比key小的最大值，返回x
                return x;
            }
        }

        public override TKey Ceiling(TKey key)
        {
            Node<TKey, TValue> x = Ceiling(_root, key);
            if (x == null)
            {
                return default(TKey);
            }
            return x.Key;
        }

        private Node<TKey, TValue> Ceiling(Node<TKey, TValue> x, TKey key)
        {
            if (x == null)
            {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                return x;
            }
            if (cmp > 0)
            {
                return Ceiling(x.Right, key);
            }
            Node<TKey, TValue> t = Ceiling(x.Left, key);
            if (t != null)
            {
                return t;
            }
            else
            {
                return x;
            }
        }

        public override int Rank(TKey key)
        {
            return Rank(_root, key);
        }

        /// <summary>
        /// 从一棵树中找到key的下标，这个下标是将key插入到ST后的下标，也即是找小于当前key的元素的数量
        /// </summary>
        /// <param name="x">树的根节点</param>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Rank(Node<TKey, TValue> x, TKey key)
        {
            if (x == null)
            {
                return 0;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                //key和当前节点key相等，因此其Rank为左子树的数量
                int size = Size(x.Left);
                return size;
            }
            else if (cmp < 0)
            {
                //key小于当前节点key，从左子树递归
                int rank = Rank(x.Left, key);
                return rank;
            }
            else
            {
                //key大于当前节点key，先加左子树的数量再加1，再继续在右子树递归
                int rank = 1 + Size(x.Left) + Rank(x.Right, key);
                return rank;
            }
        }

        public override TKey Select(int k)
        {
            Node<TKey, TValue> n = Select(_root, k);
            if (n != null)
            {
                return n.Key;
            }
            else
            {
                return default(TKey);
            }
        }

        /// <summary>
        /// 从一棵树中找到下标为k的元素的key，即第k+1元素，也即有k个元素的key都比该元素的key要小
        /// </summary>
        /// <param name="x">树的根节点</param>
        /// <param name="k"></param>
        /// <returns></returns>
        private Node<TKey, TValue> Select(Node<TKey, TValue> x, int k)
        {
            if (x == null)
            {
                return null;
            }
            //计算左子树的大小
            int t = Size(x.Left);
            if (t > k)
            {
                //左子树的数量大于k，从左子树中继续查找
                return Select(x.Left, k);
            }
            else if (t < k)
            {
                //左子树的数量小于k，从右子树查找，左子树包含t+1个元素，把t-1从k从减去即是新的k，因此新的k为k-t-1
                return Select(x.Right, k - t - 1);
            }
            else
            {
                //左子树的数量等于k，即有k个元素的key都比x的key要小，x就是要找的元素，返回x
                return x;
            }
        }

        public override IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            List<TKey> keys = new List<TKey>();
            Keys(keys, _root, lo, hi);
            return keys;
        }

        private void Keys(List<TKey> keys, Node<TKey, TValue> x, TKey lo, TKey hi)
        {
            if (x == null)
            {
                return;
            }
            //将左子树的Node添加到集合中
            if (x.Key.CompareTo(lo) > 0)
            {
                Keys(keys, x.Left, lo, hi);
            }
            //将root node添加到集合中
            if (x.Key.CompareTo(lo) >= 0 && x.Key.CompareTo(hi) <= 0)
            {
                keys.Add(x.Key);
            }
            //将右子树的Node添加到集合中
            if (x.Key.CompareTo(hi) < 0)
            {
                Keys(keys, x.Right, lo, hi);
            }
        }
        
        public override void DeleteMin()
        {
            _root = DeleteMin(_root);
        }

        private Node<TKey, TValue> DeleteMin(Node<TKey, TValue> x)
        {
            if (x.Left == null)
            {
                return x.Right;
            }
            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override void DeleteMax()
        {
            _root = DeleteMax(_root);
        }

        private Node<TKey, TValue> DeleteMax(Node<TKey, TValue> x)
        {
            if (x.Right == null)
            {
                return x.Left;
            }
            x.Right = DeleteMax(x.Right);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override void Delete(TKey key)
        {
            _root = Delete(_root, key);
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> x, TKey key)
        {
            if (x == null)
            {
                return null;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                x.Left = Delete(x.Left, key);
            }
            else if (cmp > 0)
            {
                x.Right = Delete(x.Right, key);
            }
            else
            {
                if (x.Right == null)
                {
                    return x.Left;
                }
                if (x.Left == null)
                {
                    return x.Right;
                }

                Node<TKey, TValue> t = x;
                //将x设置为原节点的右子树中最小的节点
                x = Min(t.Right);
                //将原节点的右子树中最小节点删除，即将x从右子树中删除，避免重复
                //将原节点的右子树设置为x的右子树
                x.Right = DeleteMin(t.Right);
                //将原节点的左子树设置为x的左子树
                x.Left = t.Left;
            }
            x.N = Size(x.Left) + Size(x.Right) + 1;
            //x返回后即将原节点替换，并且设置好了其左右子树，并更新好了N
            return x;
        }
    }

    public class Node<TKey, TValue>
    {
        public Node()
        {

        }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public Node(TKey key, TValue value, int n) : this(key,value)
        {
            N = n;
        }

        public Node(TKey key, TValue value, int n, bool color) : this(key,value, n)
        {
            Color = color;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int N { get; set; }

        public bool Color { get; set; }

        public Node<TKey, TValue> Left { get; set; }

        public Node<TKey, TValue> Right { get; set; }
    }
}