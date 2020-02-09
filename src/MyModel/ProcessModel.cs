using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestSandCastle
{
    public class ProcessModel
    {
        int _val = -1;

        public ProcessModel(int val)
        {
            _val = val;
        }

        public int Process()
        {
            return _val + 1;
        }
    }
}
