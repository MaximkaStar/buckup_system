using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source
{
    class USB : Memory
    {
        private const int VELOCITY = 60;//Wiki, usb 2.0
        public int storageInSegment;
        public int ammoutOfSegments;
        public USB(int ammoutOfSegments, int storageInSegment)
        {
            storage = storageInSegment * ammoutOfSegments;
            this.storageInSegment = storageInSegment;
            this.ammoutOfSegments = ammoutOfSegments;
        }
        public USB(int ammoutOfSegments, int storageInSegment, string title, string type):base()
        {
            storage = ammoutOfSegments * storageInSegment;
            this.ammoutOfSegments = ammoutOfSegments;
            this.storageInSegment = storageInSegment;
            title = title;
            type = type;
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
            return string.Format("Title: {0}, Type: {1}, ScopeMemory: {2}, ammoutOfSegments: {3}, storageInSegment: {4}", title, type, storage, ammoutOfSegments, storageInSegment);
        }
        public override int GetAllStorage()
        {
            return ammoutOfSegments * storageInSegment;
        }
        public override int GetLeisureMemory()
        {
            return storageInSegment * ammoutOfSegments - fullMemory;
        }
    }
}
