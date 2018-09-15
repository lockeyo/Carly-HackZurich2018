using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace AmagAPIServer
{
    public class ChartGen
    {
        // Brushes used to fill pie slices.
        public static Brush[] SliceBrushes =
        {
            Brushes.Red,
            Brushes.LightGreen,
            Brushes.Blue,
            Brushes.LightBlue,
            Brushes.Green,
            Brushes.Lime,
            Brushes.Orange,
            Brushes.Fuchsia,
            Brushes.Yellow,
            Brushes.Cyan,
        };

        // Pens used to outline pie slices.
        public static Pen[] SlicePens = { Pens.Black };

        // Draw a pie chart.
        public static byte[] DrawPieChart(Rectangle rect, Brush[] brushes, Pen[] pens,
            float[] values)
        {
            Bitmap bitmap = new Bitmap(Convert.ToInt32(rect.Width), Convert.ToInt32(rect.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(bitmap);

            // Get the total of all angles.
            float total = values.Sum();

            // Draw the slices.
            float start_angle = 0;
            for (int i = 0; i < values.Length; i++)
            {
                float sweep_angle = values[i] * 360f / total;
                gr.FillPie(brushes[i % brushes.Length],
                    rect, start_angle, sweep_angle);
                gr.DrawPie(pens[i % pens.Length],
                    rect, start_angle, sweep_angle);
                start_angle += sweep_angle;
            }

            byte[] result;

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                result = ms.ToArray();
            }

            return result;
        }
    }
}
