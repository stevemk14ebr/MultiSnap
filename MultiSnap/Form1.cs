using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MultiSnap
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);

        List<SnapBlock> SnapBlocks = new List<SnapBlock>();
        ResizeEventHook ResizeHook = new ResizeEventHook();
        int SnapState = 0;
        PointF FirstSnapPoint;
        bool ShowHalf = false;
        bool ShowThird = false;
        bool ShowRuleIndividually = false;
        string LayoutFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MultiSnapLayout.xml";
        void SetOpacityToSlider(SnapOverlay Overlay)
        {
            Overlay.Opacity = ((double)OpacitySlider.Value / 100.0);
        }

        private void InitializeOverlay(SnapOverlay Overlay)
        {
            Overlay.OnReceivedSnapPoint += fReceivedSnapPoint;
            SetOpacityToSlider(Overlay);
        }

        void UpdateRuleComboBox()
        {
            RuleSelectionCombo.Items.Clear();
            for(int i=0;i<SnapBlocks.Count;i++)
            {
                RuleSelectionCombo.Items.Add("Rule " + i.ToString());
            }
        }

        public Form1()
        {
            InitializeComponent();
            ResizeEventHook.OnResizeEvent += fResizeCallback;
            ResizeHook.Hook();
        }

        public void CalcRectSize(PointF Point1,PointF Point2,out PointF Pos,out PointF Size)
        {
            Pos = new PointF(0, 0);
            Size = new PointF(0, 0);
            //Calculate corners and use those
            if (Point2.X > Point1.X && Point2.Y < Point1.Y)
            {
                PointF LeftTopCorner = new PointF(Point1.X, Point2.Y);
                PointF BottomRightCorner = new PointF(Point2.X, Point1.Y);
                Pos = LeftTopCorner;
                Size = BottomRightCorner - LeftTopCorner;
            }

            if (Point2.X < Point1.X && Point2.Y > Point1.Y)
            {
                PointF LeftTopCorner = new PointF(Point1.X, Point2.Y);
                PointF BottomRightCorner = new PointF(Point2.X, Point1.Y);
                Pos = BottomRightCorner;
                Size = LeftTopCorner - BottomRightCorner;
            }

            if (Point1.X < Point2.X && Point2.Y > Point1.Y)
            {
                Pos = Point1;
                Size = Point2 - Point1;
            }

            if (Point2.X < Point1.X && Point2.Y < Point1.Y)
            {
                Pos = Point2;
                Size = Point1 - Point2;
            }
        }

        private void fReceivedSnapPoint(PointF SnapPoint)
        {
            if (SnapState == 0)
                FirstSnapPoint = SnapPoint;
            else if(SnapState == 1){
                PointF Pos, Size;
                CalcRectSize(FirstSnapPoint, SnapPoint,out Pos,out Size);
                SnapBlocks.Add(new SnapBlock(Pos, Size));
                UpdateRuleComboBox();
            }
            else if(SnapState ==2) {
                FirstSnapPoint = SnapPoint;
            }else if(SnapState == 3) {
                PointF Pos, Size;
                CalcRectSize(FirstSnapPoint, SnapPoint, out Pos, out Size);
                SnapBlocks.Last().AppendDestination(Pos, Size);
            }
            SnapPreviewPicBox.Invalidate();
            SnapState++;
            if (SnapState >= 4)
                SnapState = 0;
        }

        private void SnapPreviewPicBox_Paint(object sender, PaintEventArgs e)
        {
            Pen Black = new Pen(Color.Black, 2f);
            Pen Green = new Pen(Color.Green, 2f);
            int width = SnapPreviewPicBox.Size.Width;
            int height = SnapPreviewPicBox.Size.Height;

            if(ShowHalf)
                e.Graphics.DrawLine(Black,new Point(width/2,0),new Point(width/2,height));

            if (ShowThird)
            {
                float Third = width / 3.0f;
                e.Graphics.DrawLine(Black, new Point((int)Third, 0), new Point((int)Third, height));
                e.Graphics.DrawLine(Black, new Point((int)(Third*2.0f), 0), new Point((int)(Third*2.0f), height));
                e.Graphics.DrawLine(Black, new Point((int)(Third*3.0f), 0), new Point((int)(Third*3.0f), height));
            }

            for(int i=0;i<SnapBlocks.Count; i++)
            {
                SnapBlock Block = SnapBlocks[i];
                if (!ShowRuleIndividually)
                {
                    PointF Pos = Block.PercentPos * new PointF(width, height);
                    PointF Size = Block.PercentSize * new PointF(width, height);
                    PointF Pos2 = Block.DestPercentPos * new PointF(width, height);
                    PointF Size2 = Block.DestPercentSize * new PointF(width, height);

                    e.Graphics.DrawRectangle(Black, Pos.X, Pos.Y, Size.X, Size.Y);
                    e.Graphics.DrawRectangle(Green, Pos2.X, Pos2.Y, Size2.X, Size2.Y);
                }else {
                    if (i != RuleSelectionCombo.SelectedIndex)
                        continue;

                    PointF Pos = Block.PercentPos * new PointF(width, height);
                    PointF Size = Block.PercentSize * new PointF(width, height);
                    PointF Pos2 = Block.DestPercentPos * new PointF(width, height);
                    PointF Size2 = Block.DestPercentSize * new PointF(width, height);

                    e.Graphics.DrawRectangle(Black, Pos.X, Pos.Y, Size.X, Size.Y);
                    e.Graphics.DrawRectangle(Green, Pos2.X, Pos2.Y, Size2.X, Size2.Y);
                }
            }
        }

        private void SnapCreateBtn_Click(object sender, EventArgs e)
        {
            SnapOverlay Overlay = new SnapOverlay();
            
            InitializeOverlay(Overlay);
            Overlay.Width = SystemInformation.VirtualScreen.Width;
            Overlay.Height = SystemInformation.VirtualScreen.Height;
            Overlay.Show();
        }

        private void ShowHalfChk_CheckedChanged(object sender, EventArgs e)
        {
            ShowHalf = ShowHalfChk.Checked;
            SnapPreviewPicBox.Invalidate();
        }

        private void ShowThirdChk_CheckedChanged(object sender, EventArgs e)
        {
            ShowThird = ShowThirdChk.Checked;
            SnapPreviewPicBox.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResizeHook.UnHook();
            
            XmlSerializer xsSubmit = new XmlSerializer(SnapBlocks.GetType(), new XmlRootAttribute("SnapBlockArray"));
            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, SnapBlocks);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(sww.ToString());
                xdoc.Save(LayoutFilePath);
            }
        }

        private void fResizeCallback(IntPtr hWnd,Point WindowPos,Point WindowSize)
        {
            Point ScreenSize = new Point(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            Point MousePosition = System.Windows.Forms.Cursor.Position;

            //Is the cursor dragging the window
            Rectangle WindowRect = new Rectangle(WindowPos, new Size(WindowSize));
            if (!WindowRect.Contains(MousePosition))
                return;

            foreach (SnapBlock block in SnapBlocks)
            {
                PointF Location = block.PercentPos * ScreenSize;
                PointF Size = block.PercentSize * ScreenSize;
                Rectangle SnapBlockRect = new Rectangle((Point)Location, new Size((Point)Size));

                //Do our hit test based on cursor position
                if (SnapBlockRect.Contains(MousePosition))
                {
                    if (!block.HasDestination)
                        continue;

                    PointF LocationDest = block.DestPercentPos * ScreenSize;
                    PointF SizeDest = block.DestPercentSize * ScreenSize;
                    SetWindowPos(hWnd, -2, (int)LocationDest.X, (int)LocationDest.Y, (int)SizeDest.X, (int)SizeDest.Y, 0x0040);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Icon = ((System.Drawing.Icon)(MultiSnap.Properties.Resources.Icon));
            try
            {
                XmlSerializer serializer = new XmlSerializer(SnapBlocks.GetType(),new XmlRootAttribute("SnapBlockArray"));
                XDocument xdox = XDocument.Parse(System.IO.File.ReadAllText(LayoutFilePath));
                SnapBlocks = (List<SnapBlock>)serializer.Deserialize(xdox.CreateReader());
                UpdateRuleComboBox();
            }catch (FileNotFoundException ex){
                
            }
        }

        private void ClearSnapsBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Clear All Snaps", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;

            SnapBlocks.Clear();
            SnapPreviewPicBox.Invalidate();
            UpdateRuleComboBox();
        }

        private void RulesIndividChk_CheckedChanged(object sender, EventArgs e)
        {
            ShowRuleIndividually = RulesIndividChk.Checked;
            SnapPreviewPicBox.Invalidate();
        }

        private void RuleSelectionCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            SnapPreviewPicBox.Invalidate();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
            }
        }
    }
}
