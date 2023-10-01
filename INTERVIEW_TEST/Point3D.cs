using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVIEW_TEST
{
    public class Point3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Cộng 2 điểm
        public Point3D Add(Point3D other)
        {
            return new Point3D(this.x + other.x, this.y + other.y, this.z + other.z);
        }

        // Trừ 2 điểm
        public Point3D Sub(Point3D other)
        {
            return new Point3D(this.x - other.x, this.y - other.y, this.z - other.z);
        }

        // Nhân điểm với số
        public Point3D Mul(double scalar)
        {
            return new Point3D(this.x * scalar, this.y * scalar, this.z * scalar);
        }

        // Chia điểm cho số
        public Point3D Div(double scalar)
        {
            return new Point3D(this.x / scalar, this.y / scalar, this.z / scalar);
        }

        // Tính khoảng cách giữa 2 điểm
        public double DistanceTo(Point3D other)
        {
            return Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2) + Math.Pow(this.z - other.z, 2));
        }
    }

}
