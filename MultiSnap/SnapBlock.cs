using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MultiSnap
{
    [Serializable, XmlType("PointF")]
    public struct PointF
    {
        [XmlElement("X")]
        public float X;
        [XmlElement("Y")]
        public float Y;

        public PointF(float X,float Y)
        {
            this.X = X;
            this.Y = Y;
        }
   
        public static PointF operator *(PointF one,PointF two)
        {
            return new PointF(one.X * two.X, one.Y * two.Y);
        }
        public static PointF operator *(PointF one, float scalar)
        {
            return new PointF(one.X * scalar, one.Y * scalar);
        }
        public static PointF operator /(PointF one, float scalar)
        {
            return new PointF(one.X / scalar, one.Y / scalar);
        }
        public static PointF operator /(PointF one, PointF two)
        {
            return new PointF(one.X / two.X, one.Y / two.Y);
        }
        public static PointF operator /(PointF one, System.Drawing.Point two)
        {
            return new PointF(one.X / two.X, one.Y / two.Y);
        }
        public static PointF operator *(PointF one, System.Drawing.Point two)
        {
            return new PointF(one.X * two.X, one.Y * two.Y);
        }
        public static PointF operator -(PointF one, PointF two)
        {
            return new PointF(one.X - two.X, one.Y - two.Y);
        }
        public static explicit operator Point(PointF one)
        {
            return new Point((int)one.X,(int)one.Y);
        }
    }

    [Serializable,XmlType("SnapBlock")]
    public class SnapBlock
    {
        public PointF PercentPos { get; set; }
        public PointF PercentSize { get; set; }

        public PointF DestPercentPos { get; set; }
        public PointF DestPercentSize { get; set; }

        [XmlElement("HasDestBool")]
        public bool HasDestination { get; set; }
        public SnapBlock(PointF PositionPercent,PointF SizePercent)
        {
            PercentPos = PositionPercent;
            PercentSize = SizePercent;
            HasDestination = false;
        }
        private SnapBlock()
        {

        }
        public void AppendDestination(PointF DestPos,PointF DestSize)
        {
            DestPercentPos = DestPos;
            DestPercentSize = DestSize;
            HasDestination = true;
        }
    }
}
