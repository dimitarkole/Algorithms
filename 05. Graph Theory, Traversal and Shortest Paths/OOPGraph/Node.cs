using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGraph
{
    public class Node<T>
    {
        public Node(T id)
        {
            Id = id;
            Childrens = new List<T>();
        }

        public T Id { get; set; }

        private List<T> Childrens { get; set; }

        public void AddChildren(T children)
            => Childrens.Add(children);

        public void RemoveChildren(T children)
            => Childrens.Remove(children);

        public bool ChildreContainsNode(T id)
            => Childrens.Any(ch => ch.Equals(id));

        public List<T> GetChildrens()
            => this.Childrens;
    }
}
