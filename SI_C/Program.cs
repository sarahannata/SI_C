using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SI_C
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.Write("Masukan User Id :");
                    string user = Console.ReadLine();
                    Console.Write("Masukan Password :");
                    string pass = Console.ReadLine();
                    Console.Write("Masukan Database Tujuan:");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik y untuk koneksi ke database:");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'y':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source = LAPTOP-H0P5FB59\\SARAHHANNA17; " +
                                    ";" +
                                    "Initial catalog = {0}; " +
                                    "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine(" 1. Create data ");
                                        Console.WriteLine(" 2. Read Data ");
                                        Console.WriteLine(" 3. Update Data ");
                                        Console.WriteLine(" 4. Delete Data ");
                                        Console.WriteLine(" 5. Keluar ");
                                        Console.Write("\nEnter your choice (1-5):");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Tambahkan data ke database");
                                                    Console.Write("Masukkan nama toko:  ");
                                                    string nmtk = Console.ReadLine();
                                                    Console.Write("Masukkan id toko: ");
                                                    string idtk = Console.ReadLine();
                                                    Console.Write("Masukkan kecamatan :  ");
                                                    string kcm = Console.ReadLine();
                                                    Console.Write("Masukkan jalan :  ");
                                                    string jl = Console.ReadLine();
                                                    Console.Write("Masukkan nomor :  ");
                                                    string nmr = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.Create(nmtk, idtk, kcm, jl, nmr, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki akses untuk menambah data");
                                                        Console.WriteLine(" Tekan enter untuk melanjutkan ");
                                                        Console.ReadLine();
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Data Frozen Food\n");
                                                    Console.WriteLine();
                                                    pr.Read(conn);
                                                    conn.Close();
                                                    Console.WriteLine("Tekan enter untuk melanjutkan");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nUpdate data di database");
                                                    Console.Write("Masukkan table data yang akan diubah: ");
                                                    int id = int.Parse(Console.ReadLine());
                                                    Console.Write("Masukkan Nama Toko baru: ");
                                                    string nmtk = Console.ReadLine();
                                                    Console.Write("Masukkan Id Toko baru: ");
                                                    string idtk = Console.ReadLine();
                                                    Console.Write("Masukkan Nama Kecamatan Toko baru: ");
                                                    string kcm = Console.ReadLine();
                                                    Console.Write("Masukkan Nama Jalan Toko baru: ");
                                                    string jl = Console.ReadLine();
                                                    Console.Write("Masukkan Nomor Toko baru: ");
                                                    string nmr = Console.ReadLine();
                                                    SqlCommand updateCmd = new SqlCommand("UPDATE Tokko SET nama toko baru = @nama_toko, id toko baru = @id_toko,kecamatan baru = @kecamatan,jalan baru = @jalan, nomor baru= @nomor WHERE id = @id_toko", conn);
                                                    updateCmd.Parameters.AddWithValue("@nama_toko_baru", nmtk);
                                                    updateCmd.Parameters.AddWithValue("@id_toko_baru", idtk);
                                                    updateCmd.Parameters.AddWithValue("@kecamatan_toko_baru", kcm);
                                                    updateCmd.Parameters.AddWithValue("@jalan_toko_baru", jl);
                                                    updateCmd.Parameters.AddWithValue("@nomor_toko_baru", nmr);
                                                    updateCmd.Parameters.AddWithValue("@id", idtk);
                                                    updateCmd.ExecuteNonQuery();

                                                }
                                                break;
                                        }

                                    }
                                }
                            }
                    }
                }
            }
            
        }
        public void Create(string nmtk, string idtk, string kcm, string jl, string nmr, SqlConnection conn);
        {


    }
}
