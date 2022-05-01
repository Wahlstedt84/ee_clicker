using System.Diagnostics;


namespace EEClicker
{
    public class Program
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");
            Console.WriteLine("Hello! Do you want me to click? Type true or false");

            var input = Console.ReadLine();
            var status = Convert.ToBoolean(input);

            Thread.Sleep(10000);
            var counter = 0;


            Console.WriteLine("Let's start to click!");

            while (status)
            {
                Thread.Sleep(2000);
                LeftMouseClick(500, 500);
                counter++;
                Console.WriteLine("Click " + counter);

                if (counter == 100)
                {
                    break;
                }
            }
        }
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
    }
}