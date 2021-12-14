using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MutexTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button1");
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                do
                {
                    Console.WriteLine("checkBox1.Checked");
                }
                while (!checkBox1.Checked);
            }
            else
            {
            }
        }

        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }


        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.
            Console.WriteLine("x:" + System.Windows.Forms.Cursor.Position.X);   // Located X axis
            Console.WriteLine("y:" + System.Windows.Forms.Cursor.Position.Y);   // Located Y axis
            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("DragDrop");
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("DragEnter");
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            Console.WriteLine("DragOver");
        }
    }
}
