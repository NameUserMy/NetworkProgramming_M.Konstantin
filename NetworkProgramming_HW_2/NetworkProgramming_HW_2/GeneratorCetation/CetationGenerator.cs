using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkProgramming_HW_2.GeneratorCetation
{
    internal class CetationGenerator
    {
        UploadList? _data;
        private List<string>? _cetations;
        private Random _random;
        public List<String> GeneratorSend()
        {
            var randomCitation = new List<String>();
            for (int i = 0; i <_cetations.Count(); i++)
            {
                randomCitation.Add(_cetations.ElementAt(_random.Next(0, randomCitation.Count)));
            }
            return randomCitation;
        }
        private void UploadCitation(IUploadData upload)
        {

            upload.UploadData(new List<string> {"Gtnz","Vasya","1","2","3","4"}, _cetations);

        }
        public CetationGenerator() {

            _random = new Random();
            _cetations = new List<string>();
            _data = new UploadList();
            UploadCitation(_data);
        
        }
    }
}
