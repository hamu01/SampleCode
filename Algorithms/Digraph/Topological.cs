using System;
using System.Collections.Generic;

namespace Digraph
{
    public class Topological
    {
        private Cycle _cycle;
        private Order _order;

        public Topological(Digraph g)
        {
            _cycle = new Cycle(g);
            _order = new Order(g);
        }

        public bool IsDag()
        {
            return !_cycle.HasCycle();
        }

        public IEnumerable<int> Order()
        {
            if (IsDag())
            {
                return _order.ReversePost();
            }
            else
            {
                return null;
            }
        }
    }
}