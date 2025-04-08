using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SplashScreen
{
    public class PdPatchOpenerModel
    {
        private ProcessStartInfo info;

        public void SetProcessInfo()
        {
            try
            {
                string[] pdExePaths = new [] { @"C:\Program Files\pd\bin\pd.exe", @"C:\Program Files (x86)\pd\bin\pd.exe" };
                string pdExePath;
                string pdPatchPath;

                #if UNITY_EDITOR
                    string projectRoot = Directory.GetParent(Application.dataPath).FullName;
                    pdPatchPath = Path.Combine(projectRoot, "PureDataProject/MobileOSCSend.pd");
                #else
                    string projectRoot = Path.GetDirectoryName(Application.dataPath);
                    pdPatchPath = Path.Combine(projectRoot, "MobileOSCSend.pd");
                #endif

                pdExePath = pdExePaths.FirstOrDefault(File.Exists);

                if (File.Exists(pdExePath) && File.Exists(pdPatchPath))
                {
                    info = new ProcessStartInfo
                    {
                        FileName = pdExePath,
                        Arguments = pdPatchPath,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process.Start(info);
                }
                else
                {
                    throw new FileNotFoundException("pd.exe or MobileOSCSend.pd not found.\n" + 
                                                    "pd.exe path: " + pdExePaths[0] + "\n" +
                                                    "pd patch path: " + pdPatchPath + "\n" +
                                                    "Please download PureData from https://puredata.info/downloads/pure-data and place it in the correct directory.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorWindow($"エラーが発生しました:\n{ex.Message}");
            }
        }

        // Windows API の MessageBox を利用してエラーを表示
        #if UNITY_STANDALONE_WIN
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        private void ShowErrorWindow(string message)
        {
            MessageBox(IntPtr.Zero, message, "エラー", 0);
        }
        #endif
    }
}