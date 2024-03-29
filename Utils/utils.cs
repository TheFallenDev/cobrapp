﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cobrapp.Utils
{
    public static class MyUtils
    {
        public static string DateFixer(string date)
        {
            string[] array = date.Split('/');
            string[] newArray = new string[array.Length];
            int counter = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                newArray[counter] = array[i];
                counter++;
            }
            string newDate = string.Join("/", newArray);
            return newDate;
        }
        public static string Formatter(string text)
        {
            string result;
            if (!text.Contains("."))
            {
                result = text + ",00";
            }
            else if (text.Split('.')[1].Length < 2)
            {
                result = text.Replace(".", ",") + "0";
            }
            else
            {
                result = text.Replace(".", ",");
            }
            return result;
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 270, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }



}
