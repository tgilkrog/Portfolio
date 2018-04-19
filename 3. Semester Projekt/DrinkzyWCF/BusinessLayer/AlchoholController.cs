using DBLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AlchoholController
    {
        AlchoholDB aDB;

        public AlchoholController()
        {
            aDB = new AlchoholDB();
        }

        public void CreateAlchohol(Alchohol alchohol)
        {
            aDB.CreateAlchohol(alchohol);
        }

        public Alchohol GetAlchohol(int id)
        {
            return aDB.GetAlchohol(id);
        }

        public IEnumerable<Alchohol> GetAllAlchohol()
        {
            return aDB.GetAllAlchohols();
        }

        public IEnumerable<Alchohol> searchAlchohol(string search)
        {
            List<Alchohol> drinks = new List<Alchohol>();
            string search2 = search.ToLower().Trim();

            foreach (Alchohol d in aDB.GetAllAlchohols())
            {
                if (d.Name.ToLower().Contains(search2))
                {
                    drinks.Add(d);
                }
            }

            return drinks;
        }
    }
}
