using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source
{
    public abstract class Memory
    {
        public Memory()
        {
            fullMemory = 0;
        }

        public int fullMemory;
        public int storage;

        public string title { get; set; }
        public string type { get; set; }

        public abstract int GetAllMemory();
        public abstract int GetLeisureMemory();

        public abstract double Replicate(ref int storage);
        public abstract string GetAllData();
        public bool CanWeReplicate()
        {
            return GetLeisureMemory() >= storage ? true : false;
        }
    }
}
