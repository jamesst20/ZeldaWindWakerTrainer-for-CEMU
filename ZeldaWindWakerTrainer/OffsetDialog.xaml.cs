using System;
using System.Windows;
using System.IO;
using System.Text.RegularExpressions;
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
            if (File.Exists(Path.Join(cemuPath, "log.txt")))
            {
                using (FileStream stream = File.Open(Path.Join(cemuPath, "log.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using StreamReader reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line == null) continue;
                        
                        Match match = Regex.Match(line, @"base:\s*(0x[0-9a-fA-F]+)", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            address = match.Groups[1].Value;
                            break;
                        }
                    }
                }
            }
            
            return address;
        }
    }
}
