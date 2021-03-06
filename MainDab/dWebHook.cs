using System;
using System.Collections.Specialized;
using System.Net;

// Token: 0x02000002 RID: 2
public class dWebHook : IDisposable
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public string WebHook { get; set; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
	// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
	public string UserName { get; set; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
	// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
	public string ProfilePicture { get; set; }

	// Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
	public dWebHook()
	{
		this.dWebClient = new WebClient();
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002098 File Offset: 0x00000298
	public void SendMessage(string msgSend)
	{
		dWebHook.discordValues.Add("username", this.UserName);
		dWebHook.discordValues.Add("avatar_url", this.ProfilePicture);
		dWebHook.discordValues.Add("content", msgSend);
		this.dWebClient.UploadValues(this.WebHook, dWebHook.discordValues);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000020FA File Offset: 0x000002FA
	public void Dispose()
	{
		this.dWebClient.Dispose();
	}

	// Token: 0x04000001 RID: 1
	private readonly WebClient dWebClient;

	// Token: 0x04000002 RID: 2
	private static NameValueCollection discordValues = new NameValueCollection();
}
