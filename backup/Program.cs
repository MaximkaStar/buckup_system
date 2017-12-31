using source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backup
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ONE_FILE = 780;
            int allStorage = 565 * (int)Constants.gigabyte;
            int storageInFlashDrive = ONE_FILE;
            Memory[] memory = new FlashDrive[1];
            double allAlong = 0;
            memory[0] = new FlashDrive(storageInFlashDrive);
            int m = 0;
            while(allStorage > 0)
            {
                if(ONE_FILE <= allStorage)
                {
                    if(!memory[m].CanWeReplicate(ONE_FILE))
                    {
                        Array.Resize(ref memory, memory.Length + 1);
                        memory[memory.Length - 1] = new FlashDrive(storageInFlashDrive);
                        m++;
                    }
                    allAlong += memory[m].Replicate(ref allStorage);
                }
                else
                {
                    if(allStorage >0)
                    {
                        if(!memory[m].CanWeReplicate(allStorage))
                        {
                            Array.Resize(ref memory, memory.Length + 1);
                            memory[memory.Length - 1] = new FlashDrive(storageInFlashDrive);
                            m++;
                        }
                        allAlong += (long)memory[m].Replicate(ref allStorage);
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
