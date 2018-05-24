using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTT2CarGps
{
    public class Car
    {
        public int SignatureId { get; private set; }
        public Trail Path { get; private set; }

        public Car(int SignatureId)
        {
            this.SignatureId = SignatureId;
            Path = new Trail();
        }
    }
}
