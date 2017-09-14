using System;

namespace SearchResearch
{
    public class RedBlackBST<TKey, TValue> : BinarySearchTree_Recur<TKey, TValue> where TKey : IComparable
    {
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;

        public override void Put(TKey key, TValue value)
        {
            _root = Put(_root, key, value);
            _root.Color = BLACK;
        }

        private Node<TKey, TValue> Put(Node<TKey, TValue> h, TKey key, TValue value)
        {
            if (h == null)
            {
                return new Node<TKey, TValue>(key, value, 1, RED);
            }

            int cmp = key.CompareTo(h.Key);
            if (cmp < 0)
            {
                h.Left = Put(h.Left, key, value);
            }
            else if (cmp > 0)
            {
                h.Right = Put(h.Right, key, value);
            }
            else
            {
                h.Value = value;
            }

            if (IsRed(h.Right) && !IsRed(h.Left))
            {
                h = RotateLeft(h);
            }
            if (h.Left != null && IsRed(h.Left) && IsRed(h.Left.Left))
            {
                h = RotateRight(h);
            }
            if (IsRed(h.Left) && IsRed(h.Right))
            {
                FlipColors(h);
            }

            h.N = Size(h.Left) + Size(h.Right) + 1;

            return h;
        }

        public override void DeleteMin()
        {
            _root = DeleteMin(_root);
            if (!IsEmpty())
            {
                _root.Color = BLACK;
            }
        }

        private Node<TKey, TValue> DeleteMin(Node<TKey, TValue> h)
        {
            if (h.Left == null)
            {
                return null;
            }
            if (!IsRed(h.Left) && !IsRed(h.Left.Left))
            {
                h = MoveRedLeft(h);
            }
            h.Left = DeleteMin(h.Left);
            //ɾ����֮����ܴ���4-Node���������Ҫ���´������Ͻ���balance
            return Balance(h);
        }

        public override void DeleteMax()
        {
            _root = DeleteMax(_root);
            if (!IsEmpty())
            {
                _root.Color = BLACK;
            }
        }

        private Node<TKey, TValue> DeleteMax(Node<TKey, TValue> h)
        {
            //�����ǰ�ڵ�������Ǻ�ɫ�Ļ�
            if (IsRed(h.Left))
            {
                //���²�ڵ���3�ڵ㣬��ǰ�ڵ��Ǻ�ɫ�������Ǻ�ɫ��ͨ��һ��RotateRight�任
                //����ǰ�ڵ�����ӵ�����ʹ��ǰ�ڵ��Ϊ���ӵ��Һ���
                //����ֱ��ɾ���Һ��Ӿ�������ֵ��ɾ����ͬʱ��������ƽ��
                h = RotateRight(h);
            }
            if (h.Right == null)
            {
                return null;
            }
            //�����ǰ�ڵ���Һ��Ӳ��Ǻ�ڵ㣬�ҵ�ǰ�ڵ���Һ��ӵ�����Ҳ���Ǻ�ڵ�
            //�����ǰ�ڵ���Һ�����2-node����Ҫͨ��MoveRedRight�Ӹ��ڵ������ڵ��һ���ڵ�
            if (!IsRed(h.Right) && !IsRed(h.Right.Left))
            {
                h = MoveRedRight(h);
            }
            h.Right = DeleteMax(h.Right);
            //ɾ����֮����ܴ���4-Node���������Ҫ���´������Ͻ���balance
            return Balance(h);
        }

        public override void Delete(TKey key)
        {
            if (_root == null)
            {
                return;
            }
            if (!IsRed(_root.Left) && !IsRed(_root.Right))
            {
                _root.Color = RED;
            }
            _root = Delete(_root, key);
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> h, TKey key)
        {
            if (h == null)
            {
                return null;
            }
            if (key.CompareTo(h.Key) < 0)
            {
                if (h.Left != null && !IsRed(h.Left) && !IsRed(h.Left.Left))
                {
                    h = MoveRedLeft(h);
                }
                h.Left = Delete(h.Left, key);
            }
            else
            {
                if (IsRed(h.Left))
                {
                    h = RotateRight(h);
                }
                if (key.CompareTo(h.Key) == 0 && h.Right == null)
                {
                    return null;
                }
                if (key.CompareTo(h.Key) == 0)
                {
                    Node<TKey, TValue> min = Min(h.Right);
                    h.Key = min.Key;
                    h.Value = min.Value;
                    h.Right = DeleteMin(h.Right);
                }
                else
                {
                    if (h.Right != null && !IsRed(h.Right) && !IsRed(h.Right.Left))
                    {
                        h = MoveRedRight(h);
                    }
                    h.Right = Delete(h.Right, key);
                }
            }
            return Balance(h);
        }

        private Node<TKey, TValue> MoveRedLeft(Node<TKey, TValue> h)
        {
            //ͨ����ɫ�任������ǰ�ڵ�������ӽڵ��³�
            //����ʵ�ֽ�3��2-nodeת��Ϊ1��4-node(Parent Node�³�)
            //����ʵ������һ��Node�³�
            FlipColors(h);
            if (h.Right != null && IsRed(h.Right.Left))
            {
                //ͨ��RotateRight��RotateLeftʵ�ִ��ҽڵ��һ���ڵ����������
                //ʵ�����ǽ��ҽڵ��һ���ڵ��Ƚ赽���ڵ㣬Ȼ�󽫸��ڵ��һ���ڵ�赽��ڵ�
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
            }
            return h;
        }

        private Node<TKey, TValue> MoveRedRight(Node<TKey, TValue> h)
        {
            //ͨ����ɫ�任������ǰ�ڵ�������ӽڵ��³�
            //����ʵ�ֽ�3��2-nodeת��Ϊ1��4-node(Parent Node�³�)
            //����ʵ������һ��Node�³�
            FlipColors(h);
            //�������Ϊtrue�Ļ���һ���ǳ����˵�ǰ�ڵ�����Ӻ����ӵ����Ӷ�Ϊ��ڵ㣬����5-node
            if (h.Left != null && IsRed(h.Left.Left))
            {
                //ͨ��RotateRight�����Ӻ͵�ǰ�ڵ������ʹ��ǰ�ڵ��Ϊ���ӵ��Һ���
                h = RotateRight(h);
            }
            return h;
        }

        private Node<TKey, TValue> Balance(Node<TKey, TValue> h)
        {
            if (IsRed(h.Right) && !IsRed(h.Left))
            {
                h = RotateLeft(h);
            }
            if (h.Left != null && IsRed(h.Left) && IsRed(h.Left.Left))
            {
                h = RotateRight(h);
            }
            if (IsRed(h.Left) && IsRed(h.Right))
            {
                FlipColors(h);
            }

            return h;
        }

        private Node<TKey, TValue> RotateLeft(Node<TKey, TValue> h)
        {
            Node<TKey, TValue> x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private Node<TKey, TValue> RotateRight(Node<TKey, TValue> h)
        {
            Node<TKey, TValue> x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private void FlipColors(Node<TKey, TValue> h)
        {
            h.Color = !h.Color;
            if (h.Left != null)
            {
                h.Left.Color = !h.Left.Color;
            }
            if (h.Right != null)
            {
                h.Right.Color = !h.Right.Color;
            }
        }

        private int Size(Node<TKey, TValue> node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.N;
        }

        private bool IsRed(Node<TKey, TValue> x)
        {
            if (x == null)
            {
                return false;
            }
            return x.Color == RED;
        }
    }
}