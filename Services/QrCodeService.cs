using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SomaAfrica.Services
{
    public class QrCodeService
    {
        public byte[] GenerateQrCode(string text)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new PngByteQRCode(qrCodeData);
                return qrCode.GetGraphic(20);
            }
        }
    }
}