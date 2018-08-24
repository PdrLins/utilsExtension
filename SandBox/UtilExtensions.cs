using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

//System.Collections.Generic

namespace UtilExtensions
{
    public static class UtilExtensions
    {
        public static XmlNode SeachXmlNode(this XmlNode node, String nodeName)
        {
            if (node.LocalName == nodeName)
                return node;

            if (node.ChildNodes.Count == 0)
                return null;

            foreach (XmlNode no in node.ChildNodes)
            {
                var nodeSought = SeachXmlNode(no, nodeName);

                if (nodeSought == null)
                    continue;
                return nodeSought;
            }

            return null;
        }
        
         public static List<Dictionary<int, List<T>>> Split<T>(this List<T> list, int? maxlength = 25)
        {
            var listAux = new List<T>();
            var rList = new List<Dictionary<int, List<T>>>();
            var seq = 1;
            var page = 1;

            foreach (var i in list)
            {
                listAux.Add(i);
                if (seq == maxlength)
                {
                    rList.Add(new Dictionary<int, List<T>>() { { page, listAux } });
                    listAux = new List<T>();
                    seq = 0;
                    page++;
                }
                seq++;
            }

            return rList;
        }

        public static List<Dictionary<int, List<T>>> Split<T>(this IEnumerable<T> list, int? maxlength = 25)
        {
            if (list.Any())
            {
                var listAux = new List<T>();
                var rList = new List<Dictionary<int, List<T>>>();
                var seq = 1;
                var page = 1;

                foreach (var i in list)
                {
                    listAux.Add(i);
                    if (seq == maxlength)
                    {
                        rList.Add(new Dictionary<int, List<T>>() { { page, listAux } });
                        listAux = new List<T>();
                        seq = 0;
                        page++;
                    }
                    seq++;
                }
                rList.Add(new Dictionary<int, List<T>>() { { page, listAux } });
                return rList;
            }

            return new List<Dictionary<int, List<T>>>();

        }

        public static List<Dictionary<int, List<T>>> Split<T>(this IGrouping<string, T> list, int? maxlength = 25)
        {
            if (list.Any())
            {
                var aList = new List<T>();
                var rList = new List<Dictionary<int, List<T>>>();
                var seq = 1;
                var page = 1;

                foreach (var i in list)
                {
                    aList.Add(i);
                    if (seq == maxlength)
                    {
                        rList.Add(new Dictionary<int, List<T>>() { { page, aList } });
                        aList = new List<T>();
                        seq = 0;
                        page++;
                    }
                    seq++;
                }

                rList.Add(new Dictionary<int, List<T>>() { { page, aList } });
                return rList;
            }

            return new List<Dictionary<int, List<T>>>();
        }
    }
}
