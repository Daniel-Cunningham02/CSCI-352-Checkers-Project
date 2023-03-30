using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using static CheckersProject.src.CmdManager;

namespace CheckersProject.src
{
    internal class Observer
    {

        Thread ServerThread;
        String req;
        TcpClient Client;
        StreamReader sr;
        StreamWriter sw;
        IPAddress ip;
        TcpListener listener;
        Player p;
        CmdManager cm;

        public Observer() {
            ip = Dns.GetHostAddresses(Environment.MachineName)[1];
            listener = new TcpListener(ip, 0);
            listener.Start();
            ServerThread = new Thread(new ThreadStart(this.Listen));
            ServerThread.Start();
        }

        public string IP { get { return listener.LocalEndpoint.ToString(); } }

        public void HandleConnection()
        {
            while (Client.Connected)
            {
                req = sr.ReadLine();
                
                CmdType type = cm.RegisterCommand(ref req);
                if(type == CmdType.None)
                {
                    continue;
                }
                if (type == CmdType.Move)
                {
                    int rowStart = Int32.Parse(req.Substring(0, req.IndexOf(" ")));// Takes RowStart
                    req = req.Substring(req.IndexOf(" ") + 1); // Trims the string down to "{colStart} {rowEnd} {colEnd}"
                    int colStart = Int32.Parse(req.Substring(0, req.IndexOf(" "))); // Takes colStart
                    req = req.Substring(req.IndexOf(" ") + 1); // Trims the string down to {rowEnd} {colEnd}
                    int rowEnd = Int32.Parse(req.Substring(0, req.IndexOf(" ")));// Takes RowStart
                    req = req.Substring(req.IndexOf(" ") + 1); // Trims the string down to "{colStart} {rowEnd} {colEnd}"
                    int colEnd = Int32.Parse(req.Substring(0, req.IndexOf(" "))); // Takes colStart
                    MessageBox.Show("Move " + rowStart + colStart + " to " + rowEnd + colEnd);
                    Pos pos = new Pos(rowEnd, colEnd);
                    Piece piece = p.Board[rowStart, colStart];
                    Update(pos, piece);
                }
                else if (type == CmdType.Forfeit)
                {
                    ServerThread.Join();
                }
                else if (type == CmdType.Leave)
                {
                    ServerThread.Join();
                }
            }
        }

        public void Listen()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                sr = new StreamReader(client.GetStream(), Encoding.ASCII);
                sw = new StreamWriter(client.GetStream(), Encoding.ASCII);
                string data = sr.ReadLine();
                if (cm.RegisterCommand(ref data) == CmdType.Connect)
                {
                    sw.WriteLine(data);
                    Client = client;
                }
                break;
            }
            HandleConnection();
        }


        public void Update(Pos pos, Piece piece)
        {
            p.Move(pos, piece);
        }

        public void Publish(Pos pos, Piece piece)
        {
            string command = "Move " + piece.Row + " " + piece.Column + " " + pos.Row + " " + pos.Column;
            sw.WriteLine(command);
            sw.Flush();
        }

        public bool Attach(Player player)
        {
            this.p = player;
            
            return false;
        }

        public void Close()
        {
            if (ServerThread != null)
            {
                ServerThread.Abort();
            }
            if (sw != null)
            {
                sw.WriteLine("Leave");
                sw.Flush();
                sw.Close();
            }
            if (sr != null)
            {
                sr.Close();

            }
        }
    }
}
