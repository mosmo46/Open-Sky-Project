using Project.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.OpenSky.Entities
{
    public class QueueTask
    {
        public List<OpenSkyModel> list = new List<OpenSkyModel>();

        public void AddNewData(OpenSkyModel data)
        {
            list.Add(data);  
        }
    }
}
