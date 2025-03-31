using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public  string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }
    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }
        public KaryawanNode(Karyawan karyawan)
        {
            this.Karyawan = karyawan;
            this.Next = null;
            this.Prev = null;
        }
    }
    public class DaftarKaryawan
    {
        public KaryawanNode Head;
        public KaryawanNode Tail;
        public DaftarKaryawan()
        {
            Head = null;
            Tail = null;
        }
        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode node = new KaryawanNode(karyawan);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
        }
        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode current = Head;
            KaryawanNode prev = null;
            while (current != null)
            {
                if (current.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (prev == null)
                    {
                        Head = current.Next;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                        else
                        {
                            Head.Prev = null;
                        }
                        return true;
                    }
                    else
                    {
                        prev.Next = current.Next;
                        if (current.Next == null)
                        {
                            Tail = prev;
                        }
                        else
                        {
                            current.Next.Prev = prev;
                        }
                        return true;
                    }
                    break;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }
        public Karyawan[] CariKaryawan(string KataKunci)
        {
            KaryawanNode current = Head;
            while (current != null)
            {
                if ((current.Karyawan.Nama.Contains(KataKunci) || current.Karyawan.Posisi.Contains(KataKunci)))
                {
                    return new Karyawan[] { current.Karyawan };
                }
                current = current.Next;
            }
            return new Karyawan[] { };
        }
        public string TampilkanDaftar()
        {
            if (Head == null)
            {
                return null;
            }
            var result = "";
            var current = Tail;
            while (current != null)
            {
                result += $"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}";
                current = current.Prev;
            }
            return result;
        }
    }
}
