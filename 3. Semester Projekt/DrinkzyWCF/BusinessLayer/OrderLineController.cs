using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class OrderLineController
    {
        OrderLineDB olDb;
        DrinkController dCtr = new DrinkController();
        OrderController oCtr = new OrderController();

        public OrderLineController()
        {
            olDb = new OrderLineDB();
        }

        public void CreateOrderLine(OrderLine OrderLine, int orderID)
        {
            olDb.CreateOrderLine(OrderLine, orderID);
        }

        public void CreateOrderLineHelflask(OrderLine orderLine, int orderID)
        {
            olDb.CreateOrderLineHelflask(orderLine, orderID);
        }

        public void CreateOrderLineAlchohol(OrderLine orderLine, int orderID)
        {
            olDb.CreateOrderLineAlchohol(orderLine, orderID);
        }

        public OrderLine GetOrderLine(int ID)
        {
            return olDb.GetOrderLine(ID);
        }

        public OrderLine GetOrderLineHelflask(int ID)
        {
            return olDb.GetOrderLineHelflask(ID);
        }

        public IEnumerable<OrderLine> GetAllOrderLines()
        {
            return olDb.GetAllOrderLines();
        }

        public void DeleteOrderLineByID(string type, int orderlineID, int id)
        {
            Order order = oCtr.GetOrder(id);
            decimal newprice = order.TotalPrice;
            if(type.Equals("Gui.OrderServiceRef.Drink"))
            {
                newprice = newprice - olDb.GetOrderLine(orderlineID).TotalPrice;
                oCtr.UpdatePrice(order, newprice);
                olDb.DeleteOrderLineByID(orderlineID);
            }

            else if (type.Equals("Gui.OrderServiceRef.Alchohol"))
            {
                newprice = newprice - olDb.GetOrderLineAlchohol(orderlineID).TotalPrice;
                oCtr.UpdatePrice(order, newprice);
                olDb.DeleteAlchoholOrderLineByID(orderlineID);
            }

            else if (type.Equals("Gui.OrderServiceRef.HelFlask"))
            {
                newprice = newprice - olDb.GetOrderLineHelflask(orderlineID).TotalPrice;
                oCtr.UpdatePrice(order, newprice);
                olDb.DeleteHelflaskOrderLineByID(orderlineID);
            }
        }

        /*Denne metode ændre total prise på order og en specifik orderline*/
        public void EditOrderLinePrice(int id, int orderID, string text)
        {
            decimal price = 0;
            int amount = 0;
            //OrderLine orderline = null;
            OrderDB oDB = new OrderDB();


            foreach (var o in oDB.GetOrder(orderID).OrderLines)
            {
                /*Her tjekkes der om hvilken type drink der er på orderlinen, da den skal kalde forskellige metoder
                 som kalder en forskellige del i databasen*/
                if (o.ID == id && o.Drink.GetType() == typeof(HelFlask))
                {
                    /*Først tager vi den orderline total pris fra order total pris*/
                    price = oDB.GetOrder(orderID).TotalPrice - o.TotalPrice;
                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);

                    amount = Convert.ToInt32(text);
                    
                    /*Herefter ændres total prisen og amount på orderlinen til det nye, som kan være både højere
                      eller mindre end hvad den var før*/
                    o.TotalPrice = amount * o.Drink.Price;
                    o.Amount = amount;
                    olDb.EditOrderLineHelflask(o);

                    /*Nu ændres price til den nye prid der skal tilføres på order's total pris*/
                    price = oDB.GetOrder(orderID).TotalPrice + o.TotalPrice;

                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);
                }
                else if (o.ID == id && o.Drink.GetType() == typeof(Drink))
                {
                    price = oDB.GetOrder(orderID).TotalPrice - olDb.GetOrderLine(id).TotalPrice;
                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);

                    amount = Convert.ToInt32(text);
                    //orderline = olDb.GetOrderLine(id);
                    o.TotalPrice = amount * o.Drink.Price;
                    o.Amount = amount;
                    olDb.EditOrderLine(o);

                    price = oDB.GetOrder(orderID).TotalPrice + olDb.GetOrderLine(id).TotalPrice;

                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);
                }
                else if (o.ID == id && o.Drink.GetType() == typeof(Alchohol))
                {
                    price = oDB.GetOrder(orderID).TotalPrice - olDb.GetOrderLineAlchohol(id).TotalPrice;
                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);

                    amount = Convert.ToInt32(text);
                    //orderline = olDb.GetOrderLine(id);
                    o.TotalPrice = amount * o.Drink.Price;
                    o.Amount = amount;
                    olDb.EditOrderAlchohol(o);

                    price = oDB.GetOrder(orderID).TotalPrice + olDb.GetOrderLineAlchohol(id).TotalPrice;

                    oDB.updateTotalPrice(oDB.GetOrder(orderID), price);
                }
            }
        }

        public void EditOrderLine(OrderLine orderLine)
        {
            olDb.EditOrderLine(orderLine);
        }

        public void EditOrderLineHelflask(OrderLine orderLine)
        {
            olDb.EditOrderLineHelflask(orderLine);
        }

        public Drink getDrink(int id)
        {
            return dCtr.GetDrink(id);
        }

        public HelFlask GetHelflask(int id)
        {
            HelflaskController hCtr = new HelflaskController();
            return hCtr.GetHelflask(id);
        }

        public Alchohol GetALchohol(int id)
        {
            AlchoholController aCtr = new AlchoholController();
            return aCtr.GetAlchohol(id);
        }

    }
}

