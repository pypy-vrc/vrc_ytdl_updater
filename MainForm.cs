using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

#nullable disable

namespace VRC_YTDL_Updater
{
    public partial class MainForm : Form
    {
        private string LocalFilePath = string.Empty;
        private string RemoteFileURL = string.Empty;
        private bool Updating = false;

        public MainForm()
        {
            // specify to use TLS 1.2 as default connection
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetLocalVersion();
            GetRemoteVersion();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateFile();
        }

        private void GetLocalVersion()
        {
            LocalFilePath = @"C:\Program Files (x86)\Steam\steamapps\common\VRChat\VRChat_Data\StreamingAssets\youtube-dl.exe";

            try
            {
                using (var key = Registry.ClassesRoot.OpenSubKey(@"VRChat\shell\open\command"))
                {
                    // "C:\Program Files (x86)\Steam\steamapps\common\VRChat\launch.bat" "C:\Program Files (x86)\Steam\steamapps\common\VRChat" "%1"
                    var match = Regex.Match(key.GetValue(string.Empty) as string, "^\"(.+\\\\VRChat)\\\\launch.bat\"");
                    if (match.Success)
                    {
                        var path = match.Groups[1].Value;
                        LocalFilePath = path + @"\VRChat_Data\StreamingAssets\youtube-dl.exe";
                    }
                }
            }
            catch
            {
            }

            try
            {
                var info = FileVersionInfo.GetVersionInfo(LocalFilePath);
                LocalVersion.Text = info.FileVersion;
            }
            catch
            {
                LocalVersion.Text = "Error";
            }
        }

        private async void GetRemoteVersion()
        {
            ReleaseDTO release = null;

            BeginInvoke((MethodInvoker)delegate
            {
                RemoteVersion.Text = "Checking";
            });

            try
            {
                using (var http = new HttpClient())
                {
                    var headers = http.DefaultRequestHeaders;
                    headers.ExpectContinue = true;
                    headers.Add("User-Agent", "VRC_YTDL_Updater");
                    var response = await http.GetAsync(
                        "https://api.github.com/repos/ytdl-org/youtube-dl/releases/latest",
                        new CancellationTokenSource(3000).Token
                        );
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var raw = await response.Content.ReadAsStreamAsync())
                        {
                            using (var stream = new StreamReader(raw))
                            {
                                using (var reader = new JsonTextReader(stream))
                                {
                                    var serializer = new JsonSerializer();
                                    release = serializer.Deserialize<ReleaseDTO>(reader);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            BeginInvoke((MethodInvoker)delegate
            {
                if (release != null)
                {
                    foreach (var asset in release.assets)
                    {
                        if ("youtube-dl.exe".Equals(asset.name, StringComparison.OrdinalIgnoreCase))
                        {
                            RemoteFileURL = asset.browser_download_url;
                            var size = Math.Round(asset.size / 1048576f, 2);
                            RemoteVersion.Text = $"{release.tag_name} ({size} MiB)";
                            UpdateButton.Enabled = true;
                            return;
                        }
                    }
                }
                RemoteVersion.Text = "Error";
            });
        }

        private async void UpdateFile()
        {
            if (Updating)
            {
                return;
            }

            Updating = true;

            BeginInvoke((MethodInvoker)delegate
            {
                UpdateButton.Enabled = false;
                DownloadStatus.Text = "Downloading";
            });

            var wasError = false;

            try
            {
                var client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                await client.DownloadFileTaskAsync(new Uri(RemoteFileURL), $"{LocalFilePath}.new");
                File.Delete(LocalFilePath);
                File.Move($"{LocalFilePath}.new", LocalFilePath);
            }
            catch
            {
                wasError = true;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                DownloadStatus.Text = wasError ? "Error" : "Completed";
                UpdateButton.Enabled = true;
                GetLocalVersion();
                GetRemoteVersion();
            });

            Updating = false;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                var pct = 0;
                if (e.TotalBytesToReceive > 0)
                {
                    pct = (int)((double)e.BytesReceived / e.TotalBytesToReceive * 100);
                }
                var size = Math.Round(e.BytesReceived / 1048576f, 2);
                DownloadStatus.Text = $"Downloading {pct}% ({size}MiB)";
                DownloadProgressBar.Value = pct;
            });
        }

        private void pypy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text).Close();
        }
    }

    public class ReleaseDTO
    {
        public string tag_name;
        public IList<ReleaseAssetDTO> assets;
    }

    public class ReleaseAssetDTO
    {
        public string name;
        public ulong size;
        public string browser_download_url;
    }
}
