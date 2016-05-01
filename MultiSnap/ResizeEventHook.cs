using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSnap
{
    public delegate void ResizeEvent(IntPtr hWnd,Point WindowPos,Point WindowSize);
    public class ResizeEventHook
    {
        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
        IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public static event ResizeEvent OnResizeEvent;

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
           hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
           uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        const uint EVENT_SYSTEM_MOVESIZEEND = 0x000B;
        const uint WINEVENT_OUTOFCONTEXT = 0;
        IntPtr hhook;
        // Need to ensure delegate is not collected while we're using it,
        // storing it in a class field is simplest way to do this.
        static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);

        public void Hook()
        {
            // Listen for name change changes across all processes/threads on current desktop...
            hhook = SetWinEventHook(EVENT_SYSTEM_MOVESIZEEND, EVENT_SYSTEM_MOVESIZEEND, IntPtr.Zero,
                    procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        public void UnHook()
        {
            UnhookWinEvent(hhook);
        }

        static void WinEventProc(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (idObject != 0 || idChild != 0)
            {
                return;
            }

            if(IsWindow(hwnd))
            {
                RECT r;
                GetWindowRect(hwnd, out r);
                OnResizeEvent(hwnd,new Point(r.Left,r.Top),new Point(r.Right-r.Left,r.Bottom-r.Top));
            }
        }
    }
}
