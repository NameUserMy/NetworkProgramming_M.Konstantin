using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_2.GeneratorCetation
{
    internal class UploadList : IUploadData
    {

        public void UploadData(object s,object t)
        {
            List<string> incomming =  (List<string>)s;
            List<string> target =  (List<string>)t;
            foreach (var item in incomming)
            {
                target.Add(item);
            }   
        }
    }
}
