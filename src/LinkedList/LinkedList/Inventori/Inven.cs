using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama { get; set; }
        public int Kuantitas { get; set; }

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }
    public class ManajemenInventori
    {
        LinkedList<Item> items = new LinkedList<Item>();

        public void TambahItem(Item item)
        {
            items.AddLast(item);
        }
        public bool HapusItem(string nama)
        {
            LinkedListNode<Item>? node = items.First;
            while (node != null)
            {
                if (node.Value.Nama == nama)
                {
                    items.Remove(node);
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
        public string TampilkanInventori()
        {
            var result = "";
            foreach (var item in items)
            {
                result += $"{item.Nama}; {item.Kuantitas}{Environment.NewLine}";
            }
            return result.TrimEnd();
        }
    }
}
