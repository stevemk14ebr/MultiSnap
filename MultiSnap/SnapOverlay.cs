using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSnap
{
    public delegate void ReceivedSnapPoint(PointF SnapPoint);
    public partial class SnapOverlay : Form
    {
        public event ReceivedSnapPoint OnReceivedSnapPoint;
        public SnapOverlay()
        {
            InitializeComponent();
        }

        private void SnapOverlay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point ScreenLoc = PointToScreen(e.Location);
            Point ScreenSize = new Point(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            PointF ScreenPercent = new PointF(ScreenLoc.X / (float)ScreenSize.X, ScreenLoc.Y / (float)ScreenSize.Y);

            OnReceivedSnapPoint(ScreenPercent);
        }
    }
}
