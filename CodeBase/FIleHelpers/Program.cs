using FileHelpers;
using System;
using System.Collections.Generic;

namespace FIleHelpers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {//读写分割文件
                var path = AppDomain.CurrentDomain.BaseDirectory + "Delimited.txt";
                var engine = new FileHelperEngine<Orders>();
                var records = engine.ReadFile(path);//读

                foreach (var record in records)
                {
                    Console.WriteLine($"{record.OrderID} {record.CustomerID} {record.OrderDate} {record.Freight}");
                }


                var orders = new List<Orders>();

                orders.Add(new Orders()
                {
                    OrderID = 1,
                    CustomerID = "AIRG",
                    Freight = 82.43M,
                    OrderDate = new DateTime(2009, 05, 01)
                });

                orders.Add(new Orders()
                {
                    OrderID = 2,
                    CustomerID = "JSYV",
                    Freight = 12.22M,
                    OrderDate = new DateTime(2009, 05, 02)
                });

                engine.WriteFile("Delimited.Txt", orders);//写
            }


            {//读定长文件
                var engine = new FixedFileEngine<Customer>();
                Customer[] result = engine.ReadFile("Fixed.txt");

                foreach (var detail in result)
                {
                    Console.WriteLine(" Client: {0},  Name: {1}", detail.CustId, detail.Name);
                }
            }


            {// 按行读文件
                var list = new List<string>();
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Personal\代码库\CodeBase\FIleHelpers\bin\Debug\测试药品id.txt");
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
                var joinstring = string.Join(",", list.ToArray());
                Console.WriteLine(joinstring);
            }



            Console.ReadKey();
        }
    }

    [DelimitedRecord("|")]
    public class Orders
    {
        [FieldOrder(1)]
        public int OrderID { get; set; }
        [FieldOrder(2)]
        public string CustomerID { get; set; }
        [FieldOrder(3)]
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime OrderDate;
        [FieldOrder(4)]
        [FieldConverter(ConverterKind.Decimal, ".")] // The decimal separator is .
        public decimal Freight;
    }


    [FixedLengthRecord()]
    public class Customer
    {
        [FieldFixedLength(5)]
        public int CustId;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string Name;

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime AddedDate;
    }
}
