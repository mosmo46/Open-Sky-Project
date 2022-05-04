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
            httpJob.HandlerDataArrived += queueTask1.AddNewData;  

         //   httpJob.HandlerNumberArrived += queueTask2.AddNewItem;
           // httpJob.HandlerNumberArrived += queueTask3.AddNewItem;
        }

        public OpenSkyEntities httpJob = new OpenSkyEntities();
        public QueueTask queueTask1 = new QueueTask();

    }
}
