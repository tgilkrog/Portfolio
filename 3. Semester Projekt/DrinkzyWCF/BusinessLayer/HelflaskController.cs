using DBLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HelflaskController
    {
        HelFlaskDB hfDB = new HelFlaskDB();

        public HelFlask GetHelflask(int id)
        {
            return hfDB.GetHelFlask(id);
        }

        public IEnumerable<HelFlask> searchHelflask(string search)
        {
            List<HelFlask> drinks = new List<HelFlask>();
            string search2 = search.ToLower().Trim();

            foreach (HelFlask d in hfDB.GetAllHelflasks())
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
