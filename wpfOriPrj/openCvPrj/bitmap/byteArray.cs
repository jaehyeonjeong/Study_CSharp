using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;


namespace openCvPrj.bitmap
{
    internal class byteArray
    {
        public static BitmapSource ByteArrayToBitmapSource(byte[] data, int width, int height)
        {
            return BitmapSource.Create(
                width,
                height,
                96, 96,
                PixelFormats.Gray8,
                null,
                data,
                width
            );
        }

    }
}
