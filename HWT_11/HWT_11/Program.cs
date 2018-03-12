/*
 Реализуйте возможность через DAL управлять заказами:
1. Показывать список введенных заказов (таблица [Orders]). Помимо основных полей должны возвращаться:
a. Статус заказа в виде Enum поля.
2. Показывать подробные сведения о конкретном заказе, включая номенклатуру заказа (таблицы [Orders], [Order Details], и [Products], требуется извлекать как Id, так и название продукта)
3. Создавать новые заказы.
4. Менять статус заказа. Для реализации этого пункта предлагается сделать специальные методы (именование выбирайте сами):
a. Передать в работу: устанавливает дату заказа
b. Пометить как выполненный: устанавливает ShippedDate
5. Получать статистику по заказам, используя готовые хранимые процедуры:
a. CustOrderHist
b. CustOrdersDetail.
 */

namespace HWT_11
{
    using System;
    using Classes;
   
    public class Program
    {
        public static void Main(string[] args)
        {
            DAL dal = new DAL();
            ////List<CustOrderHist> custOrderHist = dal.ViewCustOrderHist("TORTU");
            ////foreach (var i in custOrderHist)
            ////{
            ////    Console.WriteLine($"{i.ProductName} - {i.Total}");
            ////    Console.WriteLine(custOrderHist.Count);
            ////}

            var orders = dal.GetOrders();
            Console.ReadLine();
        }
    }   
}
