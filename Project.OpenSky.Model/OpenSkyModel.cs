using Project.OpenSky.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.OpenSky.Model
{
    public class OpenSkyModel
    {

        public OpenSkyModel(object[][] states)
        {
            this.states = states;
            this.date = DateTime.Now;

        }


        public int time { get; set; }
            public object[][] states { get; set; }
            
            public DateTime date { get; set; }

    }
}
