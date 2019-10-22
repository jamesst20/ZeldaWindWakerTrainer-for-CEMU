using System;
using System.Windows;
using System.IO;
using Path = System.IO.Path;

namespace ZeldaWindWakerTrainer
{
    /// <summary>
    /// Interaction logic for OffsetDialog.xaml
    /// </summary>
    public partial class OffsetDialog : Window
    {
        public OffsetDialog(string cemuPath)
        {
            InitializeComponent();
            TxtBaseAddress.Text = FindCemuBaseAddress(cemuPath);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public long GetBaseAddress()
        {
            return long.Parse(TxtBaseAddress.Text.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
        }

        private static string FindCemuBaseAddress(string cemuPath)
        {
            string address = "";
            using (FileStream stream = File.Open($"{Path.GetDirectoryName(cemuPath)}\\log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using StreamReader reader = new StreamReader(stream);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line == null || !line.Contains("Base: 0x")) continue;
                    address = line.Substring(line.IndexOf("Base: ", StringComparison.CurrentCulture) + 6);
                    break;
                }
            }

            return address;
        }
    }
}
