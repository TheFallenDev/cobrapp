using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Logic;
using Cobrapp.Model;

namespace Cobrapp
{
    public partial class Commissions : Form
    {
        public Commissions()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            List<Tax> taxes = TaxLogic.Instance.ListFromToDate(DateFixer(dtp_from_date.Text),DateFixer(dtp_to_date.Text));
        }

        private string DateFixer(string date)
        {
            string[] array = date.Split('/');
            string[] newArray = new string[array.Length];
            int counter = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                newArray[counter] = array[i];
                Console.WriteLine(newArray[counter]);
                counter++;
            }
            string newDate = string.Join("/", newArray);
            return newDate;
        }
    }
}
