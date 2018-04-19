using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace WCF
{
    [ServiceContract]
    public interface IOrderLineService
    {
        [OperationContract]
        void CreateOrderLine(OrderLine orderline, int orderID);
        [OperationContract]
        void CreateOrderLineHelflask(OrderLine orderline, int orderID);
        [OperationContract]
        void CreateOrderLineAlchohol(OrderLine orderline, int orderID);

        [OperationContract]
        OrderLine GetOrderLine(int ID);

        [OperationContract]
        OrderLine GetOrderLineHelflask(int ID);

        [OperationContract]
        IEnumerable<OrderLine> GetAllOrderlines();

        [OperationContract]
        void DeleteOrderLineByID(string type, int orderlineID, int id);

        [OperationContract]
        void EditOrderLine(OrderLine orderLine);

        [OperationContract]
        void EditOrderLineHelflask(OrderLine orderLine);

        [OperationContract]
        void EditOrderLinePrice(int id, int orderID, string text);


        [OperationContract]
        Drink GetDrink(int id);

        [OperationContract]
        HelFlask GetHelflask(int id);


        [OperationContract]
        Alchohol GetAlchohol(int id);
    }
}
