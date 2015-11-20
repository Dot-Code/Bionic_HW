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

namespace Homework_2
{
    public partial class Form1 : Form
    {
        Thread thread;
        private bool running;
        public Form1()
        {
            InitializeComponent();
            button1.Click += btn_Click;
            button2.Click += btn_Click;
            button3.Click += btn_Click;
            button4.Click += btn_Click;
            button5.Click += btn_Click;
            button6.Click += btn_Click;
            button7.Click += btn_Click;
            button8.Click += btn_Click;
            button9.Click += btn_Click;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SignDraw(this.ActiveControl as System.Windows.Forms.Button);
            this.ActiveControl.Enabled = false;
        }
        public bool PlayerX { get; set; }
        public bool PlayerO { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
            New.Enabled = false;
        }

        private void NewGame()
        {
            comboBox1.Items.Add("Zero");
            comboBox1.Items.Add("Cross");

            comboBox2.Items.Add("Zero");
            comboBox2.Items.Add("Cross");
            panel1.Enabled = false;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("You must choose a 'Zero' or 'Cross'");
                return;
            }

            if (comboBox1.SelectedItem == comboBox2.SelectedItem)
            {
                MessageBox.Show("A players must be diferent ");
                return;
            }

            if (comboBox1.SelectedItem == "Cross")
            {
                PlayerX = true;
                PlayerO = false;
            }
            else
            {
                PlayerX = false;
                PlayerO = true;
            }
            running = true;
            New.Enabled = true;
            panel1.Enabled = true;
            Start.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            thread = new Thread(this.MethodCicle);
            thread.IsBackground = true;
            thread.Start();

        }

        private void MethodCicle()
        {
            System.Windows.Forms.Button[] myArray = { button1, button2, button3, button4, button5, button6, 
                                                        button7, button8, button9 };
            Random random = new Random();
            while (running)
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (!running)
                        return;
                    myArray[i].BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                }
            }
        }

        private void SignDraw(System.Windows.Forms.Button element)
        {
            if (PlayerX)
            {
                DrawX(element);
                PlayerX = false;
                PlayerO = true;
            }
            else
            {
                DrawY(element);
                PlayerX = true;
                PlayerO = false;
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button[] myArray = { button1, button2, button3, button4, button5, button6, 
                                                        button7, button8, button9 };
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i].Text = "";
                myArray[i].Enabled = true;
            }
            Start.Enabled = true;
            New.Enabled = false;
            panel1.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            running = false;
        }

        public void DrawX(System.Windows.Forms.Button btnX)
        {
            btnX.Text = "X";
            btnX.Font = new System.Drawing.Font(btnX.Font, System.Drawing.FontStyle.Bold);
        }

        public void DrawY(System.Windows.Forms.Button btnO)
        {
            btnO.Text = "O";
            btnO.Font = new System.Drawing.Font(btnO.Font, System.Drawing.FontStyle.Bold);
        }
    }
}
