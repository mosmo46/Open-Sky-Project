using Project.OpenSky.Dal;
using Project.OpenSky.Entities;
using Project.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.OpenSky.UI
{
    public partial class Form1 : Form
    {

          OpenSkyEntities openSkyEntities = new OpenSkyEntities();
        //    public OpenSkyModel data;
        readonly Manager manager = new Manager();

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.Run();
            manager.httpJob.HandlerUpdateData += HttpHandlerUpdate;
            // UpdateControls();
        }


        private void button2_Click(object sender, EventArgs e)
        {
             openSkyEntities.stopRunRequst();
        }


        public int displayDataFlightLength()
        {
            int sum = 0;
            var lengthList = manager.queueTask1.list;

           

            for (int i = 0; i < lengthList.Count; i++)
            {
                sum = lengthList[i].states.Length;
            }
            return sum;

        }

        public void HttpHandlerUpdate(OpenSkyModel openSky)
        {
            if (label2.InvokeRequired)
            {
                label2.Invoke(new Action(() =>
                {
                    NumberOfFlightsLableConterLable.Text = displayDataFlightLength().ToString();
                    NumberOfFlightsLableConterLable.Visible = true;

                }));

            }
            else
            {
                label2.Text = displayDataFlightLength().ToString();
                NumberOfFlightsLableConterLable.Visible = true;

            }
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new Action(() =>
                {
                    listView1.Clear();
                    listView1.View = View.Details;
                    listView1.Columns.Add("List");
                    var listname = DispalyNameCuntryList();
                    for (int i = 0; i < listname.Count; i++)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { listname[i].ToString() }));
                    }
                }));
            }
            else
            {
                var listname = DispalyNameCuntryList();
                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add("List");
                for (int i = 0; i < listname.Count; i++)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { listname[i].ToString() }));
                }
            }

        }





        /*
        private void HttpJob_HandlerUpdateData(OpenSkyModel data)
        {
            if (NumberOfFlightsLableConterLable.InvokeRequired)
            {
                NumberOfFlightsLableConterLable.Invoke(new Action(() => {
                    NumberOfFlightsLableConterLable.Text = manager.queueTask1.list.Count.ToString();
                }));
            }
            else
            {
                UpdateControls();
            }
      
        }
         */


        /*
        private void UpdateControls()
        {
            NumberOfFlightsLableConterLable.Text = manager.queueTask1.list.Count.ToString();
        }
         */




        public List<string> DispalyNameCuntryList()
        {
            List<string> Countrys = new List<string>();

            var GetDataFromHttp = manager.queueTask1.list;

            for (int i = 0; i < GetDataFromHttp.Count; i++)
            {
                var s = GetDataFromHttp[i].states;

                for (int j = 0; j < s.Length; j++)
                {
                    Countrys.Add(s[j][2].ToString());
                }

            };

            List<string> NameCountrys = new List<string>();

            var DistinctCountrys = Countrys.Distinct();

            foreach (var Country in DistinctCountrys)
            {
                if (Country != "")
                {
                    NameCountrys.Add(Country);
                }

            }

            return NameCountrys;
        }

        private void NumberOfFlightsLableConterLable_Click(object sender, EventArgs e)
        {

        }
    }
}
;