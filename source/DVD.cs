using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source
{
    class DVD : Memory
    {
        public int speed;
        public const int ONE_PART_ON_DVD = (int)((int)Constants.gigabyte * 4.7);
        public const int TWO_PART_ON_DVD = (int)((int)Constants.gigabyte * 9);
        private int velocity;
        public DVD(int velocity, bool type ) : base()
        {
            this.velocity = velocity;
            storage = type ? ONE_PART_ON_DVD : TWO_PART_ON_DVD;
            title = title;
            type = type;

        }
        public DVD(int velocity, string type) : base()
        {
            this.velocity = velocity;
            switch(type)
            {
                case "Unilateral":storage = ONE_PART_ON_DVD; break;
                case "Duplex":storage = TWO_PART_ON_DVD; break;
            }
            title = title;
            type = type;
        }
        public DVD(int velocity, int type) : base()
        {
            this.velocity = velocity;
            switch (type)
            {
                case ONE_PART_ON_DVD:storage = ONE_PART_ON_DVD;break;
                case TWO_PART_ON_DVD:storage = TWO_PART_ON_DVD;break;
                default: throw new ArgumentException("There is no such type");
            }
        }
        public DVD(int velocity, int type, string title, string sample) : base()
        {
            this.speed = speed;
            switch(type)
            {
                case ONE_PART_ON_DVD: storage = ONE_PART_ON_DVD; break;
                case TWO_PART_ON_DVD: storage = TWO_PART_ON_DVD; break;
                default: throw new ArgumentException("There is no such type");
            }
            title = title;
            sample = sample;
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
            return (double)writerMemory / velocity;
        }
        public override string GetAllData()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Title: {0}, Type: {1}, ScopeMemory: {2}", title, type, storage);
            string type = storage == ONE_PART_ON_DVD ? "Unilateral" : "Duplex";
            builder.Append(type);
            return builder.ToString();
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
