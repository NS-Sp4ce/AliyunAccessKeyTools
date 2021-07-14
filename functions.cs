using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tea;
using Tea.Utils;

namespace AliyunAkTools
{
    public partial class functions : Form
    {
        public string RegionId = "";
        public string InstanceId = "";
        public string AK_ID = "";
        public string AK_SK = "";
        public string PublicIP = "";
        public string SrvName = "";
        public string OS = "";
        public string cloudAssistantStatus = "";
        public static string OSType ;
        public functions( )
        {
            InitializeComponent();
        }

        private void functions_Load(object sender, EventArgs e)
        {
            OS = OS.Replace("(", "\n(");
            OSType = OS.Split('(')[0].ToLower();
            this.Info_Label.Text = "Region: " + RegionId + "\nInstanceId:" + InstanceId + "\nAK_ID:" + AK_ID + "\nAK_SK:" + AK_SK + "\nServer IP:" + PublicIP + "\nServer OS:" + OS+"\nServer Name:"+ SrvName;

            if (cloudAssistantStatus == "false" || cloudAssistantStatus == "Unknow")
            {
                this.TipLabel.Text = "Cloud Helper Not Installed";
                this.TipLabel.Visible = true;
                this.ExecBtn.Enabled = false;
                this.CmdBox.Enabled = false;
            }
        }

        private void ExecBtn_Click(object sender, EventArgs e)
        {
            string contentEncoding = "PlainText";
            try
            {
                AlibabaCloud.SDK.Ecs20140526.Client client = CreateClient(AK_ID, AK_SK);
                string commandId = RunCommand(client, this.CmdBox.Text, InstanceId, RegionId);
                bool? isExit = DescribeInvocationResults(client, InstanceId, commandId, RegionId, contentEncoding);
                if (isExit.Value)
                {
                    this.TipLabel.ForeColor = System.Drawing.Color.Green;
                    this.TipLabel.Text = "Comman Execute Success.";
                }
                AlibabaCloud.TeaUtil.Common.Sleep(2000);
            }
            catch (Exception _error)
            {
                TeaException error = new TeaException(new Dictionary<string, object>
                {
                    { "message", _error.Message }
                });
                System.Console.WriteLine(error.Message);
            }
        }
        public static AlibabaCloud.SDK.Ecs20140526.Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = accessKeyId,
                AccessKeySecret = accessKeySecret,
            };
            config.Endpoint = "ecs.aliyuncs.com";
            return new AlibabaCloud.SDK.Ecs20140526.Client(config);
        }
        public static string RunCommand(AlibabaCloud.SDK.Ecs20140526.Client client, string content, string instanceId, string regionId)
        {
            AlibabaCloud.SDK.Ecs20140526.Models.RunCommandRequest req = new AlibabaCloud.SDK.Ecs20140526.Models.RunCommandRequest();
            req.InstanceId = new List<string>
            {
                instanceId
            };
            req.RegionId = regionId;
            req.CommandContent = content;
            switch (functions.OSType)
            {
                case "linux":
                    req.Type = "RunShellScript";
                    break;
                case "windows":
                    req.Type = "RunPowerShellScript";
                    break;
                default:
                    req.Type = "RunBatScript";
                    break;
            }
            AlibabaCloud.SDK.Ecs20140526.Models.RunCommandResponse resp = client.RunCommand(req);
            return resp.Body.CommandId;
        }

        public static bool? DescribeInvocationResults(AlibabaCloud.SDK.Ecs20140526.Client client, string instanceId, string commandId, string regionId, string contentEncoding)
        {
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeInvocationResultsRequest req = new AlibabaCloud.SDK.Ecs20140526.Models.DescribeInvocationResultsRequest();
            req.InstanceId = instanceId;
            req.RegionId = regionId;
            req.CommandId = commandId;
            req.ContentEncoding = contentEncoding;
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeInvocationResultsResponse resp = client.DescribeInvocationResults(req);
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeInvocationResultsResponseBody.DescribeInvocationResultsResponseBodyInvocation.DescribeInvocationResultsResponseBodyInvocationInvocationResults.DescribeInvocationResultsResponseBodyInvocationInvocationResultsInvocationResult invocationResult = resp.Body.Invocation.InvocationResults.InvocationResult[0];
            if (!AlibabaCloud.TeaUtil.Common.IsUnset(invocationResult.InvocationStatus) && AlibabaCloud.TeaUtil.Common.EqualString(invocationResult.InvocationStatus, "Aborted"))
            {
                MessageBox.Show("执行失败 错误信息 " + invocationResult.ErrorInfo);
                return true;
            }
            else if (AlibabaCloud.TeaUtil.Common.IsUnset(invocationResult.ExitCode))
            {
                MessageBox.Show("脚本执行中，请等待.......");
                return false;
            }
            else
            {
                if (AlibabaCloud.TeaUtil.Common.EqualString(invocationResult.ExitCode.ToString(), "0"))
                {
                    MessageBox.Show("命令输出结果 " + invocationResult.Output);
                }
                else
                {
                    MessageBox.Show("错误码 " + invocationResult.ErrorCode + " 错误信息 " + invocationResult.ErrorInfo);
                }
                return true;
            }
        }
    }
}
