using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProjectMainDab
{
	// Token: 0x02000011 RID: 17
	internal class Functions
	{
		// Token: 0x06000154 RID: 340 RVA: 0x000186CC File Offset: 0x000168CC
		public static void Inject()
		{
			new Thread(delegate()
			{
				bool flag = NamedPipes.NamedPipeExist(NamedPipes.luapipename);
				if (flag)
				{
					MessageBox.Show("Already injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					bool flag2 = !NamedPipes.NamedPipeExist(NamedPipes.luapipename);
					if (flag2)
					{
						switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Functions.exploitdllname))
						{
						case Injector.DllInjectionResult.DllNotFound:
							MessageBox.Show("MainDab.dll was not found! Please restart the application!");
							break;
						case Injector.DllInjectionResult.GameProcessNotFound:
							MessageBox.Show("Couldn't find RobloxPlayerBeta.exe!", "Roblox isn't started!");
							break;
						case Injector.DllInjectionResult.InjectionFailed:
							MessageBox.Show("Injection Failed!", "Failed for whatever reason (try kill roblox or restart ur pc)", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							break;
						}
					}
				}
			}).Start();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000186FC File Offset: 0x000168FC
		public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
			FileInfo[] files = directoryInfo.GetFiles(FileType);
			foreach (FileInfo fileInfo in files)
			{
				lsb.Items.Add(fileInfo.Name);
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00018744 File Offset: 0x00016944
		public static void PopulateListBox1(ListBox lsb, string Folder, string FileType)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
			FileInfo[] files = directoryInfo.GetFiles(FileType);
			foreach (FileInfo fileInfo in files)
			{
				lsb.Items.Add(fileInfo.Name);
			}
		}
		string fuck = ("game.StarterGui:SetCore(\'SendNotification\', { Title = \'MainDab\'; Text = \'MainDab Injected!\'; Icon = \'rbxassetid://5242625956\';  Duration = 25; Button1 = \'Ok\'; })");
		// Token: 0x04000172 RID: 370
		public static string exploitdllname = "MainDab.dll";

		// Token: 0x04000173 RID: 371
		public static OpenFileDialog openfiledialog = new OpenFileDialog
		{
			Filter = "Script File|*.txt;*.lua|All files (*.*)|*.*",
			FilterIndex = 1,
			RestoreDirectory = true,
			Title = "Open File"
		};
	}
}
