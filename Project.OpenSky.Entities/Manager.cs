using Project.OpenSky.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.OpenSky.Entities
{
    public class Manager
    {

        
        public void Run()
        {
            httpJob.AutoRequset();
            httpJob.HandlerDataArrived += listTask1.AddNewData;  

        }

        public OpenSkyEntities httpJob = new OpenSkyEntities();
        public ListTask listTask1 = new ListTask();

    }
}
