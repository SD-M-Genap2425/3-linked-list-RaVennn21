using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; set; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            this.Data = buku;
            this.Next = null;
        }
    }

    public  class KoleksiPerpustakaan
    {
        public BukuNode head;
        public BukuNode tail;
        public KoleksiPerpustakaan()
        {
            head = null;
            tail = null;
        }
        public void TambahBuku(Buku buku)
        {
            BukuNode node = new BukuNode(buku);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }
        public bool HapusBuku(string judul)
        {
            BukuNode current = head;
            BukuNode previous = null;
            while (current != null)
            {
                if (current.Data.Judul == judul)
                {
                    if (previous == null)
                    {
                        head = current.Next;
                        return true;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        return true;
                    }
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public Buku[] CariBuku(string KataKunci)
        {
            BukuNode current = head;
            while (current != null)
            {
                if (current.Data.Judul.Contains(KataKunci) || current.Data.Penulis.Contains(KataKunci))
                {
                    return new Buku[] { current.Data };
                }
                current = current.Next;
            }
            return new Buku[] { };
        }
        public string TampilkanKoleksi()
        {
            if (head == null)
            {
                return "";
            }
            BukuNode current = head;
            var result = "";
            while (current != null)
            {
                result += $"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}\n";
                current = current.Next;
            }
            return result;

        }
    }
}
