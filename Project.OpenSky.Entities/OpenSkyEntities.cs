using Project.OpenSky.Dal;
using Project.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.OpenSky.Entities
{
    public class OpenSkyEntities
    {
        public bool runing = true;

        public delegate void delUpdate(OpenSkyModel allData);

        public event delUpdate HandlerUpdateData;


        public delegate void delItem(OpenSkyModel data);

        public event delItem HandlerDataArrived;


        public async Task<object[][]> GetFlightsData()
        {
            HTTP hTTP = new HTTP();
            OpenSkyModel openSkyModel = await hTTP.GetAllData();
            object[][] flightsData = openSkyModel.states;
            return flightsData;
        }


        public Task AutoRequset()
        {

            return Task.Factory.StartNew(async () =>
            {
                while (runing)
                {
                    object[][] flightsData = await GetFlightsData();

                    OpenSkyModel newData = new OpenSkyModel(flightsData);

                    HandlerDataArrived(newData);

                    HandlerUpdateData(newData);

                    Thread.Sleep(20000);
                }
            });

        }
        public void stopRunRequst()
        {
            runing = false;
        }
    }
}