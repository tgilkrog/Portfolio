using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    public class OrderLineService : IOrderLineService
        
    {
        OrderLineController olCtr;

        public OrderLineService()
        {
            olCtr = new OrderLineController();
        }
        public void CreateOrderLine(OrderLine orderline, int orderID)
        {
            olCtr.CreateOrderLine(orderline, orderID);
        }

        public void CreateOrderLineHelflask(OrderLine orderline, int orderID)
        {
            olCtr.CreateOrderLineHelflask(orderline, orderID);
        }

        public void CreateOrderLineAlchohol(OrderLine orderline, int orderID)
        {
            olCtr.CreateOrderLineAlchohol(orderline, orderID);
        }

        public IEnumerable<OrderLine> GetAllOrderlines()
        {
           return olCtr.GetAllOrderLines();
        }

        public OrderLine GetOrderLine(int ID)
        {
           return olCtr.GetOrderLine(ID);
        }

        public OrderLine GetOrderLineHelflask(int ID)
        {
            return olCtr.GetOrderLineHelflask(ID);
        }

        public void DeleteOrderLineByID(string type, int orderlineID, int id)
        {
            olCtr.DeleteOrderLineByID(type, orderlineID, id);
        }

        public void EditOrderLine(OrderLine orderLine)
        {
            olCtr.EditOrderLine(orderLine);
        }

        public void EditOrderLineHelflask(OrderLine orderLine)
        {
            olCtr.EditOrderLineHelflask(orderLine);
        }

        public void EditOrderLinePrice(int id, int orderID, string text)
        {
            olCtr.EditOrderLinePrice(id, orderID, text);
        }

        public Drink GetDrink(int id)
        {
            return olCtr.getDrink(id);
        }

        public HelFlask GetHelflask(int id)
        {
            return olCtr.GetHelflask(id);
        }

        public Alchohol GetAlchohol(int id)
        {
            return olCtr.GetALchohol(id);
        }
    }
}
