namespace Hilos
{
    public partial class Form1 : Form
    {
        Thread p1, p2, p3, p4;
        byte r, g, b, x;
        bool b1, b2, b3, b4;
        int turnoHilo = 1;
        int ciclosCompletados = 0;
        bool ejecutar = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = 0; g = 255; b = 0; x = 255;
            b1 = false; b2 = true; b3 = false; b4 = true;
        }

        private void Hilo1()
        {
            while (ejecutar)
            {
                if (turnoHilo == 1)
                {
                    for (int i = 0; i < 510; i++)
                    {
                        Thread.Sleep(10);
                        if (!b1) 
                        { 
                            r++; 
                            if (r == 255)
                                b1 = true;
                        }
                        else { 
                            r--; 
                            if (r == 0) 
                                b1 = false; 
                        }

                        pictureBox1.BackColor = Color.FromArgb(r, 80, 100);
                    }

                    siguiente(2);
                }
            }
       
        }
        private void Hilo2()
        {

            while (ejecutar)
            {
                if (turnoHilo == 2)
                {
                    for (int i = 0; i < 510; i++)
                    {
                        Thread.Sleep(10);
                        if (!b2)
                        { 
                            g++; 
                            if (g == 255) 
                                b2 = true; 
                        }
                        else { 
                            g--; 
                            if (g == 0) 
                                b2 = false; 
                        }

                        pictureBox2.BackColor = Color.FromArgb(100, g, 80);
                    }

                    siguiente(3);
                }
            }
         
        }

        private void Hilo3()
        {

            while (ejecutar)
            {
                if (turnoHilo == 3)
                {
                    for (int i = 0; i < 510; i++)
                    {
                        Thread.Sleep(10);
                        if (!b3) 
                        { 
                            b++; 
                            if (b == 255) 
                                b3 = true; 
                        }
                        else {
                            b--; 
                            if (b == 0) 
                                b3 = false; 
                        }

                        pictureBox3.BackColor = Color.FromArgb(80, 100, b);
                    }

                    siguiente(4);
                }
            }
         
        }
        private void Hilo4()
        {
            while (ejecutar)
            {
                if (turnoHilo == 4)
                {
                    for (int i = 0; i < 510; i++)
                    {
                        Thread.Sleep(10);
                        if (!b4) 
                        { 
                            x++; 
                            if (x == 255) 
                                b4 = true; 
                        }
                        else { 
                            x--; 
                            if (x == 0) 
                                b4 = false; 
                        }

                        pictureBox4.BackColor = Color.FromArgb(x, x, x);
                    }

                    siguiente(1);
                }
            }
           
        }


        private void siguiente(int siguienteHilo)
        {
            ciclosCompletados++;
            if (ciclosCompletados >= 3)
            {
                ciclosCompletados = 0;
                turnoHilo = siguienteHilo;
            }
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
           
            p1 = new Thread(new ThreadStart(Hilo1));
            p2 = new Thread(new ThreadStart(Hilo2));
            p3= new Thread(new ThreadStart(Hilo3));
            p4= new Thread(new ThreadStart(Hilo4));
            p1.Start();
            p2.Start();
            p3.Start();
            p4.Start();
        }
    }
}
