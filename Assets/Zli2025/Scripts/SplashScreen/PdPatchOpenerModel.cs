using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SplashScreen
{
    public class PdPatchOpenerModel
    {
        private ProcessStartInfo info;
        
        public void SetProcessInfo()
        {
            string[] pdExePaths = new [] { @"C:\Program Files\pd\bin\pd.exe", @"C:\Program Files (x86)\pd\bin\pd.exe" };
            string pdExePath;
            string pdPatchPath;
            
            // PureDataのパッチファイルのパスを取得
            #if UNITY_EDITOR
                string projectRoot = Directory.GetParent(Application.dataPath).FullName;
                pdPatchPath = Path.Combine(projectRoot, "PureDataProject/MobileOSCSend.pd");
            #else
                string exeDir = Path.GetDirectoryName(Application.dataPath);
                pdFilePath = Path.Combine(exeDir, "MobileOSCSend.pd");
            #endif

            // pd.exeのパスを取得
            pdExePath = pdExePaths.FirstOrDefault(File.Exists);
            
            // ファイルが存在していれば実行
            if(File.Exists(pdExePath) && File.Exists(pdPatchPath))
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
                #if UniTY_EDITOR
                    Debug.LogError("pd.exe or MobileOSCSend.pd not found.\n" + 
                                   "pd.exe path: " + pdExePaths[0] + "\n" +
                                   "pd patch path: " + pdPatchPath + "\n" +
                                   "Please download PureData from https://puredata.info/downloads/pure-data and place it in the correct directory.");
                #else
                    throw new FileNotFoundException("pd.exe or MobileOSCSend.pd not found.\n" + 
                                                    "pd.exe path: " + pdExePaths[0] + "\n" +
                                                    "pd patch path: " + pdPatchPath + "\n" +
                                                    "Please download PureData from https://puredata.info/downloads/pure-data and place it in the correct directory.");
                #endif
            }
        }
    }
}