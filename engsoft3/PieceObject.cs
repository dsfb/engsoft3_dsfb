using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engsoft3
{
    public class PieceObject
    {
        public int faceA;
        public int faceB;

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            PieceObject p = (PieceObject)obj;
            return (faceA == p.faceA) && (faceB == p.faceB);
        }

        public override int GetHashCode()
        {
            return faceA * faceB;
        }
    }
}
