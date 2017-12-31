using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source
{
    public class FlashDrive : Memory
    {
        private const int VELOCITY = 600;//Wiki
        public FlashDrive(int storage) : base()
        {
            this.storage = storage;
        }
        public FlashDrive(int storage, string Title, string Type) : base()
        {
            this.storage = storage;
            Title = title;
            Type = type;
        }
        public override double Replicate(ref int storage)
        {
            int leisureMemory = GetLeisureMemory();
            int writerMemory;
            if(leisureMemory >= storage)
            {
                writerMemory = storage;
                leisureMemory -= storage;
                fullMemory = this.storage - leisureMemory;
                storage = 0;
            }
            else
            {
                writerMemory = leisureMemory;
                fullMemory = this.storage;
                storage -= leisureMemory;
            }
            return (double)writerMemory / VELOCITY;
        }
        public override string GetAllData()
        {
            return string.Format("Title: {0}, Model: {1}, Memory: {2}", title, type, storage);
        }
        public override int GetAllMemory()
        {
            return storage;
        }
        public override int GetLeisureMemory()
        {
            return storage - fullMemory;
        }
    }
}
