using System;
using System.Runtime.InteropServices;
 
namespace Silksong.Rando;

#if DEV
class ConsoleMover
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool MoveWindow(
        IntPtr hWnd,
        int X,
        int Y,
        int nWidth,
        int nHeight,
        bool bRepaint
    );

    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    
    [DllImport("user32.dll")]
    static extern int SetProcessDpiAwarenessContext(IntPtr dpiContext);

    static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 =
        new IntPtr(-4);

    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    
    public static void Move()
    {
        SetProcessDpiAwarenessContext(
            DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
        );
        IntPtr console = GetConsoleWindow();

        // Move to (100, 100) and resize to 800x600
        MoveWindow(console, 3833, 936, (int)(1094f * 1.5f), (int)(943f * 1.5f), true);
    }
    
    public static void PrintConsoleRect()
    {
        IntPtr hwnd = GetConsoleWindow();

        if (hwnd == IntPtr.Zero)
        {
            RandoPlugin.Log.LogInfo("No console window found.");
            return;
        }

        if (!GetWindowRect(hwnd, out RECT r))
        {
            RandoPlugin.Log.LogInfo("GetWindowRect failed.");
            return;
        }

        int width = r.Right - r.Left;
        int height = r.Bottom - r.Top;

        RandoPlugin.Log.LogInfo("Console window rect:");
        RandoPlugin.Log.LogInfo($"Left   = {r.Left}");
        RandoPlugin.Log.LogInfo($"Top    = {r.Top}");
        RandoPlugin.Log.LogInfo($"Right  = {r.Right}");
        RandoPlugin.Log.LogInfo($"Bottom = {r.Bottom}");
        RandoPlugin.Log.LogInfo($"Width  = {width}");
        RandoPlugin.Log.LogInfo($"Height = {height}");
    }
}
#endif