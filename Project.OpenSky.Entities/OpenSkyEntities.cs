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


        public async Task<object[][]> GetAllFlit()
        {
            HTTP hTTP = new HTTP();
            OpenSkyModel opne = await hTTP.GetAllData();
            object[][] arrayOfArtay = opne.states;
            return arrayOfArtay;
        }


        public Task AutoRequset()
        {

            return Task.Factory.StartNew(async () =>
            {
                while (runing)
                {
                    object[][] statesData = await GetAllFlit();

                    OpenSkyModel openSkyModel = new OpenSkyModel(statesData);

                    HandlerDataArrived(openSkyModel);

                    HandlerUpdateData(openSkyModel);

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