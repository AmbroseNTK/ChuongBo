using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XMLReaderAndWriter
{
    class Data
    {
        int id;
        string value;

        public Data(int id, string value)
        {
            this.Id = id;
            this.Value = value;
        }

        public int Id { get => id; set => id = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> listData = new List<Data>();
            listData.Add(new Data(1, "Hello"));
            listData.Add(new Data(2, "World"));

            Data select = listData.Single(data => data.Id == 1);
            if (select != null)
                select.Value = "Kiet";
            Console.WriteLine(listData[0].Value);
            Console.ReadLine();

        }
    }
}
