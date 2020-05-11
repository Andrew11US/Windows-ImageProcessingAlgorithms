using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingAlgorithms
{
    public partial class AboutView : Form
    {
        public AboutView()
        {
            // UI setup
            InitializeComponent();
            Text = "About Project";
            ClientSize = new Size(500, 360);
            label1.Size = new Size(300, 30);
            textBox1.Size = new Size(480, 250);

            label1.Top = 10;
            label1.Left = 180;
            textBox1.Top = 50;
            textBox1.Left = 10;

            doneBtn.Top = 310;
            doneBtn.Left = 210;
            doneBtn.Focus();
            CenterToScreen();

            ShowAbout();
        }

        private void ShowAbout()
        {
            // Compund string output using StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.
                Append("Aplikacja zbiorcza z ćwiczeń laboratoryjnych").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Autor: ").Append("Andrii Halabuda").Append(Environment.NewLine)
                .Append("Grupa: ").Append("ID06IO2").Append(Environment.NewLine)
                .Append("ID: ").Append("17460").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Prowadzący: ").Append("mgr inż. Łukasz Roszkowiak").Append(Environment.NewLine)
                .Append("Przedmiot: Algorytmy Przetwarzania Obrazów 2020").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Wyższa Szkoła Informatyki Stosowanej i Zarządzania").Append(Environment.NewLine)
                .Append("Warszawa 2020").Append(Environment.NewLine);

            textBox1.Text = stringBuilder.ToString();
        }
    }
}
