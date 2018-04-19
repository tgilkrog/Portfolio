using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    public class StorageService : IStorageService
    {
        StorageController sCtr;

        public StorageService()
        {
            sCtr = new StorageController();
        }

        public void CreateStorage(Storage storage)
        {
            sCtr.CreateStorage(storage);
        }

        public Storage getAlchoholStorageByDrinkAndStorage(int alchID, int cusID)
        {
            return sCtr.getAlchoholStorageByDrinkAndStorage(alchID, cusID);
        }

        public IEnumerable<Storage> GetAllStorages()
        {
           return sCtr.GetAllStorages();
        }

        public Storage GetDrinkStorage(int cusID, int drinkID)
        {
            return sCtr.GetDrinkStorage(cusID, drinkID);
        }

        public Storage getHelflaskStorageByHelflaskAndStorage(int flaskID, int cusID)
        {
            return sCtr.getHelflaskStorageByHelflaskAndStorage(flaskID, cusID);
        }

        public Storage GetStorage(int id)
        {
            return sCtr.GetStorage(id);
        }

        public Storage getStorageByDrinkAndStorage(int drinkID, int cusID)
        {
            return sCtr.getStorageByDrinkAndStorage(drinkID, cusID);
        }

        public void UpdateStorageDrink(int orderID)
        {
            sCtr.UpdateDrinkAmount(orderID);
        }

        public IEnumerable<Storage> GetAllDrinkStorage(int cusID)
        {
            return sCtr.GetAllDrinkStorage(cusID);
        }

        public IEnumerable<Storage> GetAllAlchoholStorage(int cusID)
        {
            return sCtr.GetAllAlchoholStorage(cusID);
        }

        public IEnumerable<Storage> GetAllHelflaskStorage(int cusID)
        {
            return sCtr.GetAllHelflaskStorage(cusID);
        }

        public void UpdateStorages(Storage storage)
        {
            sCtr.UpdateStorages(storage);
        }

        public bool CompleteOrder(int orderID)
        {
            return sCtr.CompleteOrder(orderID);
        }
    }
}
