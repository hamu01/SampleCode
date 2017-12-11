// namespace Classic
// {
//     public class DanceLink1
//     {
//         public void Dance(Node h)
//         {
//             List<Node> solutions = new List<Node>();
//             if (h.Right == h)
//             {
//                 printSolution();
//                 return;
//             }
//             else
//             {
//                 Node column = ChooseNextColumn(h);
//                 Cover(column);

//                 for (Node row = column.Down; row != column; row = row.Down)
//                 {
//                     solutions.Add(row);

//                     for (Node right = row.Right; right != row; right = right.Right)
//                     {
//                         Cover(right);
//                     }

//                     Search(k + 1);

//                     solutions.Remove(row);
//                     column = row.GetColumn();

//                     for (Node leftNode = row.Left; leftNode != row; leftNode = leftNode.Left)
//                     {
//                         Uncover(leftNode);
//                     }
//                 }

//                 Uncover(column);
//             }
//         }

//         private void Cover(Node dataNode)
//         {
//             Node column = dataNode.getColumn();

//             column.Right.Left = column.Left;
//             column.Left.Right = column.Right;

//             for (Node row = column.Down; row != column; row = row.Down)
//             {
//                 for (Node rightNode = row.Right; rightNode != row; rightNode = rightNode.Right)
//                 {
//                     rightNode.Up.Down = rightNode.Down;
//                     rightNode.Down.Up = rightNode.Up;
//                 }
//             }
//         }

//         private void Uncover(Node dataNode)
//         {
//             Node column = dataNode.getColumn();
//             for (Node row = column.Up; row != column; row = row.Up)
//             {
//                 for (Node leftNode = row.Left; leftNode != row; leftNode = leftNode.Right)
//                 {
//                     leftNode.Up.Down = leftNode.Down;
//                     leftNode.Down.Up = leftNode.Up;
//                 }
//             }
//             column.Right.Left = column.Left;
//             column.Left.Right = column.Right;
//         }

//         private Node ChooseNextColumn(Node head)
//         {
//             Node n = head.Right;
//             Node min = n;
//             while (n != null)
//             {
//                 if (n.Count < min.Count)
//                 {
//                     min = n;
//                 }
//                 n = n.Right;
//             }
//             return min;
//         }
//     }
// }