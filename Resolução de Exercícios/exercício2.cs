/*
Nesta implementação, utilizamos a classe TcpClient para estabelecer uma conexão TCP assíncrona com o servidor.
O método ConnectAsync aguarda a conclusão da conexão e, em caso de sucesso, 
retorna o descritor de arquivo (socket) associado ao cliente. Se ocorrer algum erro na conexão, 
uma mensagem de erro é exibida e é retornado um valor indicativo de erro (-1 neste caso).

Certifique-se de incluir essa classe TcpConnect na mesma namespace em que o restante do código
está definido. Lembre-se de que esta é uma implementação básica e pode ser necessário ajustar
o código para atender aos requisitos específicos do seu projeto e ambiente.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace WebFetcherExample
{
    class File
    {
        public string f_name;
        public string f_host;
        public int f_fd;
        public int f_flags;
        public Thread f_tid;

        public File(string name, string host)
        {
            f_name = name;
            f_host = host;
            f_fd = -1;
            f_flags = 0;
        }
    }

    class WebFetcher
    {
        private const int MAXFILES = 20;
        private const string SERV = "80";
        private readonly File[] files = new File[MAXFILES];
        private int nconn, nfiles, nlefttoconn, nlefttoread;
        private int ndone;
        private readonly object ndoneMutex = new object();

        public static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: WebFetcher <#conns> <IPaddr> <homepage> file1 ...");
                return;
            }

            int maxnconn = int.Parse(args[0]);
            WebFetcher webFetcher = new WebFetcher();
            webFetcher.Start(args, maxnconn);
        }

        public void Start(string[] args, int maxnconn)
        {
            nfiles = Math.Min(args.Length - 3, MAXFILES);

            for (int i = 0; i < nfiles; i++)
            {
                files[i] = new File(args[i + 3], args[1]);
            }

            Console.WriteLine("nfiles = " + nfiles);

            HomePage(args[1], args[2]);

            nlefttoread = nlefttoconn = nfiles;
            nconn = 0;

            while (nlefttoread > 0)
            {
                while (nconn < maxnconn && nlefttoconn > 0)
                {
                    int i;
                    for (i = 0; i < nfiles; i++)
                    {
                        if (files[i].f_flags == 0)
                        {
                            break;
                        }
                    }

                    if (i == nfiles)
                    {
                        Console.WriteLine("nlefttoconn = " + nlefttoconn + " but nothing found");
                        return;
                    }

                    files[i].f_flags = 1;
                    Thread thread = new Thread(new WebFetcherRunnable(files[i]).Run);
                    files[i].f_tid = thread;
                    thread.Start();
                    nconn++;
                    nlefttoconn--;
                }

                lock (ndoneMutex)
                {
                    while (ndone == 0)
                    {
                        Monitor.Wait(ndoneMutex);
                    }

                    for (int i = 0; i < nfiles; i++)
                    {
                        if ((files[i].f_flags & 4) != 0)
                        {
                            File fptr = (File)files[i].f_tid;
                            fptr.f_flags = 8;
                            ndone--;
                            nconn--;
                            nlefttoread--;
                            Console.WriteLine("thread " + fptr.f_tid.ManagedThreadId + " for " + fptr.f_name + " done");
                        }
                    }
                }
            }
        }

        private void HomePage(string host, string fname)
        {
            int fd;
            string line;

            fd = TcpConnect.Connect(host, SERV);
            string request = "GET " + fname + " HTTP/1.0\r\n\r\n";

            using (StreamWriter writer = new StreamWriter(new FileStream(fd.ToString(), FileMode.Create)))
            {
                writer.Write(request);
            }

            using (StreamReader reader = new StreamReader(new FileStream(fd.ToString(), FileMode.Open)))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("read " + line.Length + " bytes of home page");
                }
            }

            Console.WriteLine("end-of-file on home page");
        }
    }

    class WebFetcherRunnable
    {
        private File fptr;

        public WebFetcherRunnable(File file)
        {
            fptr = file;
        }

        public void Run()
        {
            int fd;
            string line;
            fd = TcpConnect.Connect(fptr.f_host, WebFetcher.SERV);
            fptr.f_fd = fd;

            Console.WriteLine("do_get_read for " + fptr.f_name + ", fd " + fd + ", thread " + fptr.f_tid.ManagedThreadId);

            WriteGetCmd(fptr);

            using (StreamReader reader = new StreamReader(new FileStream(fd.ToString(), FileMode.Open)))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("read " + line.Length + " bytes from " + fptr.f_name);
                }
            }

            Console.WriteLine("end-of-file on " + fptr.f_name);
            fptr.f_flags = 4;

            lock (fptr.f_tid)
            {
                Monitor.Enter(WebFetcher.Instance.ndoneMutex);
                try
                {
                    WebFetcher.Instance.ndone++;
                    Monitor.Pulse(WebFetcher.Instance.ndoneMutex);
                }
                finally
                {
                    Monitor.Exit(WebFetcher.Instance.ndoneMutex);
                }
            }
        }

        private void WriteGetCmd(File fptr)
        {
            string line = "GET " + fptr.f_name + " HTTP/1.0\r\n\r\n";
            using (StreamWriter writer = new StreamWriter(new FileStream(fptr.f_fd.ToString(), FileMode.Create)))
            {
                writer.Write(line);
            }

            Console.WriteLine("wrote " + line.Length + " bytes for " + fptr.f_name);
            fptr.f_flags = 2;
        }
    }

    class TcpConnect
    {
        public static async Task<int> ConnectAsync(string host, string serv)
        {
            try
            {
                TcpClient client = new TcpClient();
                await client.ConnectAsync(host, int.Parse(serv));

                return client.Client.Handle.ToInt32(); // Retornar o descritor de arquivo (socket)
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connecting: " + e.Message);
                return -1; // Retornar um valor indicativo de erro
            }
        }
    }
}
