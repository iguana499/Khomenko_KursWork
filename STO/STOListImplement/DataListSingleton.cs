using STOListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Part> Parts { get; set; }
        public List<Work> Works { get; set; }
        public List<WorkParts> WorkParts { get; set; }
        private DataListSingleton() 
        {
            Parts = new List<Part>();
            Works = new List<Work>();
            WorkParts = new List<WorkParts>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
