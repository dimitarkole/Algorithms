using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGraph
{
    public class Graph<T>
    {
        public Graph()
        {
            Nodes = new List<Node<T>>();
        }

        private List<Node<T>> Nodes { get; set; }

        public void AddNode(T nodeId)
        {
            var node = new Node<T>(nodeId);
            Nodes.Add(node);
        }

        public void RemoveNode(T id)
        {
            var node = this.Nodes
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (node == null) return;

            var parentNodes = this.Nodes
                .Where(x => x.ChildreContainsNode(id));

            foreach (var parentNode in parentNodes)
            {
                parentNode.RemoveChildren(node.Id);
            }

            Nodes.Remove(node);
        }

        public void AddChildren(T parentNodeId, T childrenNodeId)
        {
            var node = this.Nodes
                .Where(x => x.Id.Equals(parentNodeId))
                .FirstOrDefault();

            node.AddChildren(childrenNodeId);
        }

        public List<T> GetChildren(T nodeId)
            => this.Nodes
                .Where(x => x.Id.Equals(parentNodeId))
                .FirstOrDefault()
                .GetChildrens();

        public void RemoveChildren(T parentNodeId, T childrenNodeId)
        {
            var node = this.Nodes
                .Where(x => x.Id.Equals(parentNodeId))
                .FirstOrDefault();

            node.RemoveChildren(childrenNodeId);
        }
    }
}
