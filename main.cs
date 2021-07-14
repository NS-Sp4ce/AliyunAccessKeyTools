using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tea;
using Tea.Utils;

namespace AliyunAkTools
{
    public partial class main : Form
    {
        public string AK_ID = "";
        public string AK_SK = "";
        public string fCloudAssistantStatus;
        public main( )
        {
            InitializeComponent();
        }
        /**
         创建client
         */
        public static AlibabaCloud.SDK.Ecs20140526.Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                // 您的AccessKey ID
                AccessKeyId = accessKeyId,
                // 您的AccessKey Secret
                AccessKeySecret = accessKeySecret,
            };
            // 访问的域名
            config.Endpoint = "ecs.aliyuncs.com";
            return new AlibabaCloud.SDK.Ecs20140526.Client(config);
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (this.srv_lvw.Items.Count > 1)
            {
                this.srv_lvw.Items.Clear();
            }
            AK_ID = AKID.Text;
            AK_SK = AKSK.Text;
            LogInfo("Tring use: " + AK_ID + "----" + AK_SK + " login.");
            AlibabaCloud.SDK.Ecs20140526.Client client = CreateClient(AK_ID, AK_SK);
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeRegionsRequest describeRegionsRequest = new AlibabaCloud.SDK.Ecs20140526.Models.DescribeRegionsRequest();
            //请求SDK，屎一样的SDK
            try
            {
                AlibabaCloud.SDK.Ecs20140526.Models.DescribeRegionsResponse response = client.DescribeRegions(describeRegionsRequest);
                //解析为JSON
                String JsonData = AlibabaCloud.TeaUtil.Common.ToJSONString(response.Body.ToMap());
                //解析JSON为数组
                JObject Region = JObject.Parse(JsonData);
                JArray items = (JArray)Region["Regions"]["Region"];
                //获取地区数量
                int length = items.Count;
                List<string> regionIds = new List<string>();
                for (int i = 0; i < items.Count; i++)
                {
                    regionIds.Add(items[i]["RegionId"].ToString());
                }
                LogSuccess("Login Success! Get Available Aera Success, Area Count:" + length.ToString());
                string[] _regionIds = regionIds.ToArray();
                Thread t = new Thread(( ) => getAccountServer(AK_ID, AK_SK, _regionIds));
                t.Start();
            }
            catch
            {
                LogError("Connect Failed, Check Your AK/AKSK");
            }
        }
        public void getAccountServer(String AK_ID, String AK_SK, String[] regionIds)
        {
            int count = 0;
            AlibabaCloud.SDK.Ecs20140526.Client client = CreateClient(AK_ID, AK_SK);
            foreach (var regionId in regionIds)
            {
                AlibabaCloud.SDK.Ecs20140526.Models.DescribeInstancesRequest describeInstancesRequest = new AlibabaCloud.SDK.Ecs20140526.Models.DescribeInstancesRequest
                {
                    RegionId = regionId
                };

                try
                {
                    AlibabaCloud.SDK.Ecs20140526.Models.DescribeInstancesResponse resp = client.DescribeInstances(describeInstancesRequest);
                    List<AlibabaCloud.SDK.Ecs20140526.Models.DescribeInstancesResponseBody.DescribeInstancesResponseBodyInstances.DescribeInstancesResponseBodyInstancesInstance> instances = resp.Body.Instances.Instance;
                    foreach (var instance in instances)
                    {
                        string cloudAssistantStatus = DescribeCloudAssistantStatus(client, instance.InstanceId, instance.RegionId);
                        switch ((string)cloudAssistantStatus){
                            case "false":
                                cloudAssistantStatus = "×";
                                break;
                            case "true":
                                cloudAssistantStatus = "√";
                                break;
                            default:
                                cloudAssistantStatus = "Unknow";
                                break;
                        }
                        addItemToListView(count,
                            instance.InstanceId,
                            instance.RegionId,
                            instance.HostName,
                            instance.OSType + "(" + instance.OSName + ")",
                            instance.Status,
                            string.Join(",", instance.VpcAttributes.PrivateIpAddress.IpAddress.ToArray()),
                            string.Join(",", instance.PublicIpAddress.IpAddress.ToArray()),
                            string.Join(",", instance.SecurityGroupIds.SecurityGroupId.ToArray()),
                            "CPU:" + instance.Cpu + " Mem:" + instance.Memory + " MB",
                            instance.InstanceType,
                            instance.CreationTime,
                            instance.ExpiredTime,
                            cloudAssistantStatus
                            );
                        count++;
                        LogSuccess(string.Join(",", instance.PublicIpAddress.IpAddress.ToArray()) + "--CPU:" + instance.Cpu + " Mem:" + instance.Memory + " MB");
                    }
                }
                catch
                {
                    LogError(regionId + " Region Search Failed,API Not Support.");
                }
            }
        }
        public delegate void LogAppendDelegate(Color color, string text);
        //ID,实例ID,地区,主机名,主机系统,状态,私网IP,公网IP,安全组,实例配置,创建时间,到期时间
        private void addItemToListView(
            int count,
            string InstanceId,
            string regionId,
            string HostName,
            string OSType,
            string Status,
            string InnerIpAddress,
            string PublicIpAddress,
            string SecurityGroupId,
            string srvOptins,
            string InstanceType,
            string CreationTime,
            string ExpiredTime,
            string cloudAssistantStatus
            )
        {

            ListViewItem lvi = new ListViewItem(count.ToString());
            lvi.SubItems.Add(InstanceId);
            lvi.SubItems.Add(regionId);
            lvi.SubItems.Add(HostName);
            lvi.SubItems.Add(OSType);
            lvi.SubItems.Add(Status);
            lvi.SubItems.Add(InnerIpAddress);
            lvi.SubItems.Add(PublicIpAddress);
            lvi.SubItems.Add(SecurityGroupId);
            lvi.SubItems.Add(srvOptins);
            lvi.SubItems.Add(InstanceType);
            lvi.SubItems.Add(CreationTime);
            lvi.SubItems.Add(ExpiredTime);
            lvi.SubItems.Add(cloudAssistantStatus);
            this.srv_lvw.Invoke(new DelegateAddItem(addItem), lvi);
        }
        public void LogAppend(Color color, string text)
        {
            if (this.txt_log.Text.Length > 10000)
            {
                this.txt_log.Clear();
            }
            this.txt_log.SelectionColor = color;
            this.txt_log.HideSelection = false;
            this.txt_log.AppendText(text + Environment.NewLine);
        }
        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.txt_log.Invoke(la, Color.Red, "[" + DateTime.Now + "] " + text);
        }
        /// <summary> 
        /// 显示警告信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.txt_log.Invoke(la, Color.Violet, "[" + DateTime.Now + "] " + text);
        }
        /// <summary> 
        /// 显示一般信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.txt_log.Invoke(la, Color.Black, "[" + DateTime.Now + "] " + text);
        }
        /// <summary> 
        /// 显示正确信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogInfo(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.txt_log.Invoke(la, Color.BlueViolet, "[" + DateTime.Now + "] " + text);
        }
        public void LogSuccess(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            this.txt_log.Invoke(la, Color.Green, "[" + DateTime.Now + "] " + text);
        }
        delegate void DelegateAddItem(ListViewItem lvi);
        private void addItem(ListViewItem lvi)
        {

            this.srv_lvw.Items.Add(lvi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogMessage("Welcome");
        }
        private void ExecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            functions func = new functions();
            func.InstanceId = this.srv_lvw.SelectedItems[0].SubItems[1].Text;
            func.RegionId = this.srv_lvw.SelectedItems[0].SubItems[2].Text;
            func.AK_ID = AK_ID;
            func.AK_SK = AK_SK;
            func.SrvName = this.srv_lvw.SelectedItems[0].SubItems[3].Text;
            func.PublicIP = this.srv_lvw.SelectedItems[0].SubItems[7].Text;
            func.OS = this.srv_lvw.SelectedItems[0].SubItems[4].Text;
            switch (this.srv_lvw.SelectedItems[0].SubItems[13].Text)
            {
                case "×":
                    fCloudAssistantStatus = "false";
                    break;
                case "√":
                    fCloudAssistantStatus = "true";
                    break;
                default:
                    fCloudAssistantStatus = "Unknow";
                    break;
            }
            func.cloudAssistantStatus = fCloudAssistantStatus;
            func.StartPosition = FormStartPosition.CenterScreen;
            func.ShowDialog(this);
        }
        public static string DescribeCloudAssistantStatus(AlibabaCloud.SDK.Ecs20140526.Client client, string instanceId, string regionId)
        {
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeCloudAssistantStatusRequest req = new AlibabaCloud.SDK.Ecs20140526.Models.DescribeCloudAssistantStatusRequest();
            // 所在的地域ID
            req.RegionId = regionId;
            // 实例ID列表
            req.InstanceId = new List<string>
            {
                instanceId
            };
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeCloudAssistantStatusResponse resp = client.DescribeCloudAssistantStatus(req);
            AlibabaCloud.SDK.Ecs20140526.Models.DescribeCloudAssistantStatusResponseBody.DescribeCloudAssistantStatusResponseBodyInstanceCloudAssistantStatusSet.DescribeCloudAssistantStatusResponseBodyInstanceCloudAssistantStatusSetInstanceCloudAssistantStatus status = resp.Body.InstanceCloudAssistantStatusSet.InstanceCloudAssistantStatus[0];
            return status.CloudAssistantStatus;
        }

        private void CopyLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.srv_lvw.SelectedItems.Count == 0)
            {
                return;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                sb.Append("----");
                sb.Append(this.srv_lvw.SelectedItems[0].SubItems[i].Text);
            }
            Clipboard.SetText(sb.Remove(0, 4).ToString());
            MessageBox.Show("复制成功！");
        }
    }
}
