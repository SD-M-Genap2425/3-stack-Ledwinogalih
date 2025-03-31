using System;

namespace Solution.BrowserHistory
{
    public class Halaman
    {
        public string? URL{ get; private set;}
        public Halaman? Next{ get; set;}

        public Halaman(string url)
        {
            URL = url;
            Next = null;
        }
    }

    public class HistoryManager
    {
        private Halaman? top;

        public HistoryManager()
        {
            top = null;
        }

        public void KunjungiHalaman(string url)
        {
            Halaman newPage = new Halaman(url);
            newPage.Next = top;
            top = newPage;
            Console.WriteLine($"Mengunjungi halaman: {url}");
        }

        public string Kembali()
        {
            if(top == null)
            {
                return "Tidak ada halaman yang dikunjungi.";
            }
            if(top.URL == null)
            {
                return "URL halaman saat ini tidak tersedia."; // Atau pesan lain yang sesuai
            }
            return top.URL;
        }

        public string LihatHalamanSaatIni()
        {
            if(top != null)
            {
                if(top.URL != null)
                {
                    return top.URL;
                }
                else
                {
                    return "URL tidak tersedia";
                }
            }
            else
            {
                return "Tidak ada halaman yang dikunjungi.";
            }

        }

        public void TampilkanHistory()
        {
            Halaman? current = top;
            int index = 1;
            
            Console.WriteLine("Menampilkan history:");
            while(current != null)
            {
                Console.WriteLine($"{index}. {current.URL}");
                current = current.Next;
                index++;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            HistoryManager history = new HistoryManager();
            
            history.KunjungiHalaman("google.com");
            history.KunjungiHalaman("example.com");
            history.KunjungiHalaman("stackoverflow.com");
            
            Console.WriteLine($"Halaman saat ini: {history.LihatHalamanSaatIni()}");
            
            Console.WriteLine("Kembali ke halaman sebelumnya...");
            Console.WriteLine($"Halaman saat ini: {history.Kembali()}");
            
            history.TampilkanHistory();
        }
    }
}
