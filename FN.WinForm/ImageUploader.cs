using FN.Entities;
using FN.Functions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using SD = System.Drawing;

namespace FN.WinForm
{
    public partial class ImageUploader : Form
    {
        private string UploadPath = string.Empty;

        public ImageUploader()
        {
            InitializeComponent();
        }

        private void ImageUploader_Load(object sender, EventArgs e)
        {
            UploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"];
            button2.Enabled = button1.Enabled = !string.IsNullOrEmpty(UploadPath);

            cmbSizeMax.Items.AddRange(
                new ComboBoxItem { Text = "100Kb", Value = 102400 },
                new ComboBoxItem { Text = "200Kb", Value = 204800 },
                new ComboBoxItem { Text = "300Kb", Value = 307200 }
            );
            cmbSizeMax.SelectedIndex = 2;

            cmbPercent.Items.AddRange(
                new ComboBoxItem { Text = "100%", Value = 1.00 },
                new ComboBoxItem { Text = "75%", Value = 0.75 },
                new ComboBoxItem { Text = "50%", Value = 0.50 },
                new ComboBoxItem { Text = "25%", Value = 0.25 }
            );
            cmbPercent.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                oImagePath.Text = openFileDialog.FileName;
                ShowImage(oImagePath.Text, imagePreview, oImageProperties);
            }
        }

        private static void ShowImage(string imagePath, PictureBox picturePreview, TextBox propertiesPreview)
        {
            picturePreview.Image?.Dispose();

            using var stream = File.OpenRead(imagePath);

            var format = Image.DetectFormat(stream);

            stream.Position = 0;

            using var image = Image.Load(stream);

            picturePreview.Image = ConvertToBitmap(image);

            var sb = new StringBuilder();
            sb.AppendLine($"Image Type : {format?.Name ?? "Unknown"}");
            sb.AppendLine($"Image width : {image.Width}");
            sb.AppendLine($"Image height : {image.Height}");
            sb.AppendLine($"Image Pixel depth : {image.PixelType.BitsPerPixel}");
            sb.AppendLine($"Image size : { Generic.ConvertSize(imagePath)}");

            propertiesPreview.Text = sb.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(oImagePath.Text).ToUpperInvariant();
            if (ext != ".PNG" && ext != ".JPG" && ext != ".JPEG")
                return;

            using Image image = Image.Load(oImagePath.Text);

            double scale = ((ComboBoxItem)cmbPercent.SelectedItem).Value;
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            image.Mutate(x => x.Resize(newWidth, newHeight));

            string tempPath = Path.GetTempPath();
            string tempFile = Generic.SaveImageToFile(image, tempPath);

            string compressedPath =
                ImageResizer.ScaleImage(
                    tempFile,
                    (int)((ComboBoxItem)cmbSizeMax.SelectedItem).Value,
                    deleteSrcFile: true
                );

            ShowImage(compressedPath, imageSaved, dImageProperties);
        }

        private static SD.Bitmap ConvertToBitmap(Image image)
        {
            using var ms = new MemoryStream();
            image.SaveAsBmp(ms);
            ms.Position = 0;
            return new SD.Bitmap(ms);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string uploadUri = System.Configuration.ConfigurationManager.AppSettings["WebServiceUri"];

            imageSaved.Image = null;
            lblStatusUpdate.Visible = false;

            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(oImagePath.Text));

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "File", Path.GetFileName(oImagePath.Text));
            form.Add(new StringContent("0"), "Id");
            form.Add(new StringContent(Path.GetFileName(oImagePath.Text)), "FileName");

            using var client = new HttpClient { BaseAddress = new Uri(uploadUri) };
            var response = await client.PostAsync("uploads", form);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var uploaded =
                System.Text.Json.JsonSerializer.Deserialize<UploadedModel>(
                    json,
                    new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            lblStatusUpdate.Text = $"{uploaded.FileName}{uploaded.Extension}";

            lblStatusUpdate.Visible = true;
        }
    }
}
