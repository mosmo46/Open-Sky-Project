using Project.OpenSky.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.OpenSky.UI
{
    public partial class Form1 : Form
    {
      public List<string> AuthorList = new List<string>();

       // public string[] names;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenSkyDal c = new OpenSkyDal();
           await c.GetAllData();
       
            ListCantry();
        }

        public async void ListCantry()
        {
            OpenSkyDal c = new OpenSkyDal();
           var list =  await c.GetAllData();
            var bigList = list.states;

            listView1.View = View.Details;

            listView1.Columns.Add("Country Name");

            for (int i = 0; i < bigList.Length; i++)
            {
            listView1.Items.Add(new ListViewItem(new string[] { bigList[i][2].ToString() }));

            }

           

        }
    }
}
