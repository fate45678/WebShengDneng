using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShenDnengWeb
{
    public partial class webPlanCycleTENCENTFFCmidthree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = HistroyNumber();
            //dt.DefaultView.Sort = "Issue desc";
            //dt.Columns["Issue"].ColumnName = "期号";
            //dt.Columns["Number"].ColumnName = "号码";
            //grvHistory.DataSource = dt;
            //grvHistory.DataBind();
            if (!IsPostBack)
            {
                CountAndShow();
                grvIgnore.DataSource = SelectIgnore();
                grvIgnore.DataBind();
            }
        }

        protected void btnViewResult_Click(object sender, EventArgs e)
        {
            try
            {
                //抓圖片
                //loadUrlPicture();

                if (txtGameNum.Text.Trim() == "请输入奖金号" || Int32.Parse(txtGameNum.Text) < 1700 || Int32.Parse(txtGameNum.Text) > 1956)
                {
                    ////MessageBox.Show("只能输入1700 ~ 1956的数字");
                    Response.Write("<script>alert('只能输入1700 ~ 1956的数字');</script>");
                    txtGameNum.Focus();
                    return;
                }

                //ConnectDbGetHistoryNumber(GameLotteryName);
                //UpdateHistory();
                //pnlShowPlan.Visible = false;
                if (txtGameNum.Text == "" || txtGameNum.Text == "请输入奖金号" ||
                    txtTimes.Text == "" || txtTimes.Text == "请输入倍数" ||
                    (ckRegularCycle.Checked == false && ckWinToNextCycle.Checked == false) ||
                    cbGamePlus.SelectedItem == null ||
                    cbGamePlan.SelectedItem == null)
                {
                    ////MessageBox.Show("所有欄位都必須輸入");
                    return;
                }

                CountAndShow();

                //放到背景
                //DataTable dtGodList = getDbGodList();

                //string[] buttomNameArr;
                //int row = 0;
                //tblGod.Controls.Clear();
                ////if(dtGodList)
                //foreach (DataRow dr in dtGodList.Rows)
                //{
                //    Control control = new Button();
                //    buttomNameArr = dr["g_buttomName"].ToString().Split(',');
                //    control.Text = buttomNameArr[0] + buttomNameArr[1] + buttomNameArr[2] + buttomNameArr[3] + buttomNameArr[4] + "\r\n中獎率" + dr["g_buttomRate"].ToString() + "%";
                //    control.Size = new System.Drawing.Size(206, 50);
                //    control.Name = dr["g_buttomName"].ToString();
                //    control.ForeColor = Color.Black;
                //    control.Padding = new Padding(5);
                //    control.Dock = DockStyle.Fill;
                //    control.Click += dynamicBt_Click;
                //    this.tblGod.Controls.Add(control, 0, row);
                //    row++;
                //}
                //frm_LoadingControl.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "');</script>");
                return;
            }
        }

        protected void cbGamePlus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> GameCycleDic = new Dictionary<int, string>();

            switch (cbGamePlus.SelectedValue.Substring(0, 1))
            {

                case "3":
                    cbGameCycle.Items.Clear();
                    GameCycleDic.Add(3, "三期一周");
                    GameCycleDic.Add(2, "二期一周");
                    GameCycleDic.Add(1, "一期一周");
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    GameCycleDic.Add(2, "二期一周");
                    GameCycleDic.Add(1, "一期一周");
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    GameCycleDic.Add(2, "二期一周");
                    GameCycleDic.Add(1, "一期一周");
                    break;
            }

            cbGameCycle.DataSource = GameCycleDic;
            cbGameCycle.DataValueField = "Key";
            cbGameCycle.DataTextField = "Value";
            cbGameCycle.DataBind();
            cbGameCycle.SelectedIndex = 0;

        }

        protected void cbGameKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 重庆时时彩
            switch (cbGameKind.SelectedItem.ToString())
            {
                case "五星":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("星组合");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("30000+");
                    cbGamePlus.Items.Add("40000+");
                    cbGamePlus.Items.Add("50000+");
                    cbGamePlus.SelectedIndex = 0;
                    //玉神计划 幻影计划 神灯计划    
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("英雄计划");
                    //cbGamePlan.Items.Add("传奇计划");
                    //cbGamePlan.Items.Add("神话计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "四星":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("四星组合");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("3000+");
                    cbGamePlus.Items.Add("4000+");
                    cbGamePlus.Items.Add("5000+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("史诗计划");
                    //cbGamePlan.Items.Add("传说计划");
                    //cbGamePlan.Items.Add("精良计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "前三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("组合");
                    //cbGameDirect.Items.Add("和值");
                    //cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("风暴计划");
                    //cbGamePlan.Items.Add("雷光计划");
                    //cbGamePlan.Items.Add("烈火计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "中三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("中三组合");
                    //cbGameDirect.Items.Add("和值");
                    //cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("索尔计划");
                    //cbGamePlan.Items.Add("奥丁计划");
                    //cbGamePlan.Items.Add("洛基计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "后三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //.Items.Add("后三组合");
                    //cbGameDirect.Items.Add("和值");
                    //cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("战神计划");
                    //cbGamePlan.Items.Add("女武神计划");
                    //cbGamePlan.Items.Add("英灵计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "前二":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("和值");
                    //cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("30+");
                    cbGamePlus.Items.Add("40+");
                    cbGamePlus.Items.Add("50+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("神通计划");
                    //cbGamePlan.Items.Add("玉佛计划");
                    //cbGamePlan.Items.Add("大帝计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "后二":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    //cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("和值");
                    //cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("30+");
                    cbGamePlus.Items.Add("40+");
                    cbGamePlus.Items.Add("50+");
                    cbGamePlus.SelectedIndex = 0;
                    cbGamePlan.Items.Clear();
                    //cbGamePlan.Items.Add("神通计划");
                    //cbGamePlan.Items.Add("玉佛计划");
                    //cbGamePlan.Items.Add("大帝计划");
                    //cbGamePlan.SelectedIndex = 0;
                    break;
                case "定位胆":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("万");
                    cbGameDirect.Items.Add("千");
                    cbGameDirect.Items.Add("百");
                    cbGameDirect.Items.Add("十");
                    cbGameDirect.Items.Add("个");
                    //todo: 定位胆的處理
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    break;
                default:
                    break;
            }

            cbGamePlus_SelectedIndexChanged(sender, e);
            //切換計畫名稱
            DataTable dt = getPlanName(cbGameKind.SelectedItem.ToString());

            cbGamePlan.DataSource = dt;
            cbGamePlan.DataTextField = "GamePlan_name";
            cbGamePlan.DataBind();
            #endregion
        }

        private void CountAndShow()
        {
            //大表
            DataTable dt = new DataTable();
            dt.Columns.Add("期號");
            dt.Columns.Add("週期");
            dt.Columns.Add("號碼");
            dt.Columns.Add("中獎期");
            dt.Columns.Add("中或掛");
            dt.Columns.Add("id", typeof(int));
            DataRow dr = dt.NewRow();

            int cycle_2 = 1;
            int cycle_3 = 1; //比對開獎的周期數
            int sumBets = 0, LastBets = 0; //總投注數 //最後計算
            int sumWin = 0, sumFail = 0; //中奖次數

            int Index = cbGamePlan.SelectedIndex;
            string GameCycle = cbGameCycle.Text;

            DataTable dtTmp = HistroyNumber();
            var str_json = JsonConvert.SerializeObject(dtTmp, Formatting.Indented);
            JArray jArrHistoryNumber = (JArray)JsonConvert.DeserializeObject(str_json);

            //抓取比對的投注數量
            JArray NowAnalyzeNumberArr = ConnectDbGetRandomNumber(cbGamePlus.SelectedItem.ToString(), Index, GameCycle, jArrHistoryNumber);

            //用來更換randomNumber的
            int hisArr = NowAnalyzeNumberArr.Count;

            //要改到外層
            //pnlShowPlan.Visible = true;
            var item = cbGameCycle.Items[cbGameCycle.SelectedIndex];

            //紀錄最大連續沒中的
            DataTable dtFailCount = new DataTable();
            dtFailCount.Columns.Add("MaxCount", typeof(int));
            DataRow drFailCount = dtFailCount.NewRow();

            #region 重庆时时彩

            if (cbGameDirect.Text == "复式")
            {

            }
            else if (cbGameDirect.Text == "Single" || cbGameDirect.Text == "单式")
            {

                #region 驗證是否中奖
                Label lbl_1;
                //ComboBox cb_1;
                Label lbl_2;
                Label lbl_3;
                //flowLayoutPanel1.Controls.Clear();

                bool isWin = false; //中了沒
                int periodtWin = 0; //第幾期中
                string[] temp = { "", "", "" }; //存放combobox的值

                var checkcycle_2 = jArrHistoryNumber.Count % Convert.ToInt16(item.Value);
                if (checkcycle_2 == 0)
                    cycle_2 = jArrHistoryNumber.Count / Convert.ToInt16(item.Value);
                else
                    cycle_2 = (jArrHistoryNumber.Count / Convert.ToInt16(item.Value)) + 1;

                lblPlanCycleSelected.Text = "第" + cycle_2.ToString("00") + "周期";
                int countCycle = 1;

                for (int i = 0; i < jArrHistoryNumber.Count; i++) //從歷史結果開始比
                {
                    //reset
                    isWin = false;
                    periodtWin = 0;
                    temp[0] = "";
                    temp[1] = "";
                    temp[2] = "";

                    lbl_1 = new Label();
                    lbl_1.Text = "第" + countCycle + "周期";
                    dr["id"] = countCycle;
                    dr["週期"] = "第" + countCycle + "周期";
                    countCycle++;

                    //lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    //lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                    //lbl_1.Size = new System.Drawing.Size(72, 25);

                    //int NumberArrCount = numHistory.Count();

                    for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                    {
                        if (i >= jArrHistoryNumber.Count) break;

                        string strMatch = "";
                        dr["期號"] = jArrHistoryNumber[i]["Issue"].ToString();
                        switch (cbGameKind.SelectedItem.ToString())
                        {
                            case "五星":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                break;
                            case "四星":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                break;
                            case "前三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                break;
                            case "中三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                break;
                            case "后三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                break;
                            case "前二":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                break;
                            case "后二":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                break;
                        }
                        if (isWin == false) //還沒中
                        {
                            ///////////////cycle_2 - 1
                            if (ckWinToNextCycle.Checked == true && hisArr == 0)
                                hisArr = NowAnalyzeNumberArr.Count;
                            string numberCheck = NowAnalyzeNumberArr[hisArr - 1].ToString();
                            if (numberCheck.IndexOf(strMatch) > -1) //中
                            {
                                drFailCount["MaxCount"] = sumFail;
                                dtFailCount.Rows.Add(drFailCount);
                                drFailCount = dtFailCount.NewRow();

                                sumFail = 0;
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                isWin = true;

                                if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                {
                                    i++;
                                    sumBets++;
                                    periodtWin = j + 1;
                                    break;
                                }
                            }
                            else //挂
                            {
                                sumFail++;
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                            }
                            sumBets++;
                            periodtWin = j + 1;

                        }
                        else //前面已中奖
                        {
                            temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                            //cycle_2++;
                        }
                        i++;

                    }

                    cycle_2--;
                    i--;
                    cycle_3++;
                    hisArr--;

                    dr["號碼"] = temp[0];// + " / " + temp[1] + " / " + temp[2] + "    ";

                    //cb_1 = new ComboBox();
                    //for (int k = 0; k < 3; k++)
                    //{
                    //    if (temp[k] != "")
                    //        cb_1.Items.Add(temp[k]);
                    //}
                    //cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                    //cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                    //cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    //cb_1.ForeColor = System.Drawing.Color.Black;
                    //cb_1.FormattingEnabled = true;
                    //cb_1.Margin = new System.Windows.Forms.Padding(0);
                    //cb_1.Size = new System.Drawing.Size(128, 26);
                    //cb_1.SelectedIndex = 0;
                    //cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);
                    //cb_1.DropDownStyle = ComboBoxStyle.DropDownList;

                    //lbl_2 = new Label();
                    //lbl_2.Text = periodtWin.ToString();
                    //lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    //lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                    //lbl_2.Size = new System.Drawing.Size(53, 25);
                    //lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    lbl_3 = new Label();
                    if (isWin == true)
                    {
                        lbl_3.Text = "中";
                        lbl_3.ForeColor = System.Drawing.Color.Red;
                        dr["中或掛"] = "中";
                        sumWin++;
                    }
                    else
                    {
                        lbl_3.Text = "挂";
                        dr["中或掛"] = "挂";
                        lbl_3.ForeColor = System.Drawing.Color.Black;
                    }
                    //lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    //lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                    //lbl_3.Size = new System.Drawing.Size(60, 25);
                    //lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    //flowLayoutPanel1.Controls.Add(lbl_1);
                    //flowLayoutPanel1.Controls.Add(cb_1);
                    //flowLayoutPanel1.Controls.Add(lbl_2);
                    //flowLayoutPanel1.Controls.Add(lbl_3);
                    LastBets += Convert.ToInt32(periodtWin);
                    dr["中獎期"] = periodtWin.ToString();
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                }


                if (ckRegularCycle.Checked == true) //规律周期
                {


                }
                else //中奖即进入下一周期
                {

                }
                #endregion

                #region 計算
                txtTimes.Text = "1";
                txtGameNum.Text = "1956";
                lbBets.Text = NowAnalyzeNumberArr[NowAnalyzeNumberArr.Count - 1].ToString().Split(',').Count().ToString();
                //每期注數 共?元
                lblBetsMoney.Text = (Convert.ToDecimal(lbBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString("0.0");
                //目前下注?周期
                lblCurrentBetsCycle.Text = (cycle_3 - 1).ToString();
                //共下注?期
                lblSumBetsCycle.Text = LastBets.ToString();
                //總投注額?元
                lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString("0.0");
                //獎金?元
                lblWinMoney.Text = ((Convert.ToDouble(sumWin) * (Convert.ToDouble(txtGameNum.Text)) * 100 * 0.01 * Convert.ToDouble(txtTimes.Text))).ToString("0.0");
                //盈虧?元
                lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString("0.0");
                //中奖率
                double WinOpp = (sumWin * 100 / Convert.ToDouble(lblSumBetsCycle.Text));
                lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                DataView dv = new DataView(dt);
                dv.RowFilter = "中或掛 = '中'";
                var test = dv.ToTable();
                //dt
                DataView dvFail = new DataView(dtFailCount);
                dvFail.Sort = "MaxCount desc";
                dtFailCount = dvFail.ToTable();
                string FailCount = dtFailCount.Rows[0]["MaxCount"].ToString();

                lbWinCount.Text = "中" + test.Rows.Count + "次";
                lbBets.Text = lbBets.Text + "注";
                lbFailCount.Text = "最大連續沒中" + FailCount + "期";
                dt.DefaultView.Sort = "id desc";
                dt.Columns.Remove("id");
                dt.Columns.Remove("週期");
                dt.Columns.Remove("中獎期");
                grvResult.DataSource = dt;
                grvResult.DataBind();
                #endregion
            }

            if (cbGameKind.Text == "定位胆")
            {

            }

            #endregion

        }

        //抓隨機號碼
        private JArray ConnectDbGetRandomNumber(string type, int PlanName, string GameCycle, JArray jArrHistoryNumber)
        {
            //重慶時時彩DB
            string GameDb = "ForTENCENTFFC";
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";
            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = abc; Password=123456";
            con = new SqlConnection(connetionString);
            string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");

            JArray ja = new JArray();

            #region 騰訊官方彩
            if (GameCycle == "1")
            {
                if (PlanName == 0)
                {
                    con.Open();
                    string Sqlstr = @"SELECT top(1440) number AS Number,insertDate FROM RandomNumberForTENCENTFFCwithIgnoremidthree 
--WHERE CONVERT(VARCHAR(25), insertDate, 126) LIKE '2018-12-17%'
--insertDate = '2018-12-17 10:38:22.457'
order by insertDate desc ";
                    //string aaaa = string.Format(Sqlstr, date, type, GameDb);
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else if (PlanName == 1)
                {
                    con.Open();
                    string Sqlstr = @"SELECT number AS Number FROM RandomNumber{2} WHERE date = '20180720' AND type = '{1}'";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else
                {
                    con.Open();
                    string Sqlstr = @"SELECT number AS Number FROM RandomNumber{2} WHERE date = '20180720' AND type = '{1}'";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                con.Close();

            }
            else if (GameCycle == "二期一周")
            {
                if (PlanName == 0)
                {
                    con.Open();
                    string Sqlstr = @"SELECT top(720) number AS Number FROM RandomNumber{2} WHERE date = '20180720' AND type = '{1}' ";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else if (PlanName == 1)
                {
                    con.Open();
                    string Sqlstr = @"SELECT [number] AS Number FROM 
(
SELECT ROW_NUMBER() OVER(ORDER BY [number]) NUM,
* FROM [RandomNumber{2}]
WHERE date = '20180720' AND type = '{1}'
) A
WHERE NUM >720 AND NUM <1441";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else
                {
                    con.Open();
                    string Sqlstr = @"SELECT top(720) number AS Number FROM RandomNumber{2} WHERE date = '20180720' AND type = '{1}'";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                con.Close();
            }
            else
            {
                //todo 修改每種不同的號碼
                if (PlanName == 0)
                {
                    con.Open();//RandomNumberForTENCENTFFCwithIgnoreFrontThree
                    string Sqlstr = @"SELECT top(480) number AS Number,insertDate FROM RandomNumberForTENCENTFFCwithIgnoreMidThree 
--WHERE CONVERT(VARCHAR(25), insertDate, 126) LIKE '2018-12-17%'
--insertDate = '2018-12-17 10:38:22.457'
order by insertDate desc";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else if (PlanName == 1)
                {
                    con.Open();
                    string Sqlstr = @"SELECT [number] AS Number FROM 
(
SELECT ROW_NUMBER() OVER(ORDER BY [number]) NUM,
* FROM [RandomNumber{2}]
WHERE date = '20180720' AND type = '{1}'
) A
WHERE NUM >480 AND NUM <961";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json);
                }
                else
                {
                    con.Open();
                    string Sqlstr = @"SELECT [number] AS Number FROM 
(
SELECT ROW_NUMBER() OVER(ORDER BY [number]) NUM,
* FROM [RandomNumber{2}]
WHERE date = '20180720' AND type = '{1}'
) A
WHERE NUM >960 AND NUM <1441";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type, GameDb), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    ja = (JArray)JsonConvert.DeserializeObject(str_json); ;
                }
                con.Close();
            }


            #endregion

            #region 顯示可看的週期

            int cycle_1 = 1; //列出計畫號碼的周期數
            string cycleName = ""; //第幾周期
            string cycelNumber = "";
            int cycleCount = 1;

            //第幾周期的dropdownlist
            //Dictionary<string, string> PlanCycleSelectDic = new Dictionary<string, string>();

            DataTable dtPlanCycleSelect = new DataTable();
            dtPlanCycleSelect.Columns.Add("id", typeof(int));
            dtPlanCycleSelect.Columns.Add("Number");
            dtPlanCycleSelect.Columns.Add("Name");
            DataRow dr = dtPlanCycleSelect.NewRow();

            var item = cbGameCycle.Items[cbGameCycle.SelectedIndex];

            cbPlanCycleSelect.Items.Clear();
            var checkcycle_1 = jArrHistoryNumber.Count % Convert.ToInt16(item.Value);
            if (checkcycle_1 == 0)
                cycle_1 = jArrHistoryNumber.Count / Convert.ToInt16(item.Value);
            else
                cycle_1 = (jArrHistoryNumber.Count / Convert.ToInt16(item.Value)) + 1;

            int RandonNumberCount = 0;
            for (int i = 0; i < jArrHistoryNumber.Count; i++)
            {
                cycleName = "第" + cycleCount + "周期";
                //var jadesc = jArrHistoryNumber.OrderByDescending(x => x["Issue"]);
                //var jaArr = jArrHistoryNumber.OrderByDescending(x => x["Issue"]).ToArray();
                string cycleDetail = "";
                for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                {
                    if (i >= jArrHistoryNumber.Count)
                        break;
                    cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                    if (j != Convert.ToInt16(item.Value) - 1)
                        i++;
                }

                cycelNumber = ja[ja.Count - RandonNumberCount - 1]["Number"].ToString();
                RandonNumberCount++;
                dr["Number"] = cycelNumber;
                dr["Name"] = cycleDetail;
                dr["id"] = cycleCount;
                dtPlanCycleSelect.Rows.Add(dr);
                dr = dtPlanCycleSelect.NewRow();
                //PlanCycleSelectDic.Add(cycleName + "," + cycleDetail, cycelNumber);
                cycle_1--;
                cycleCount++;
                //i++;

                dr = dtPlanCycleSelect.NewRow();
            }
            dtPlanCycleSelect.DefaultView.Sort = "id DESC";
            cbPlanCycleSelect.DataSource = dtPlanCycleSelect;
            cbPlanCycleSelect.DataTextField = "Name";
            cbPlanCycleSelect.DataValueField = "Number";
            cbPlanCycleSelect.DataBind();
            // cbPlanCycleSelect.SelectedIndex = 0;

            txtPlanCycle.Text = ja[0]["Number"].ToString();
            #endregion

            return ja;
        }

        private DataTable HistroyNumber()
        {
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";

            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = abc; Password=123456";
            con = new SqlConnection(connetionString);
            string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            string Sqlstr = "";
            string response = "";
            try
            {
                con.Open();
                Sqlstr = @"Select issue AS Issue, number AS Number from [lottery].dbo.TENCENTFFC_HistoryNumber Where issue LIKE '" + date + "%' order by issue";
                SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, User), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void cbPlanCycleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlanCycle.Text = cbPlanCycleSelect.SelectedValue;
            int ItemCount = cbPlanCycleSelect.Items.Count;
            lblPlanCycleSelected.Text = "第" + (ItemCount - 1) + "周期";
        }

        private DataTable getPlanName(string typeName)
        {
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";

            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = abc; Password=123456";
            con = new SqlConnection(connetionString);
            //string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            string Sqlstr = "";
            string response = "";
            try
            {
                con.Open();
                Sqlstr = @"SELECT GamePlan_name FROM [lottery].[dbo].[GamePlan] WHERE GamePlan_type = '" + typeName + "' ";
                SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, User), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void grvResult_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

            GridViewRow row = e.Row;
            //找到所在单元格，索引从0开始
            if (row.Cells.Count > 1)
            {
                if (row.Cells[2].Text == "中")
                {
                    row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    row.Cells[1].ForeColor = System.Drawing.Color.Red;
                    row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    //row.Cells[3].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnQQFFC_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(@"~\webPlanCycle.aspx");
        }

        protected void btnTENCENTFFC_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(@"~\webPlanCycleTENCENTFFC.aspx");
        }

        protected void grvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvResult.PageIndex = e.NewPageIndex;

            CountAndShow();
        }

        private DataTable SelectIgnore()
        {
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";

            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = abc; Password=123456";
            con = new SqlConnection(connetionString);
            //string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            string Sqlstr = "";
            try
            {
                con.Open();
                Sqlstr = @"
SELECT TENCENTFFC_ignorenumber AS 當前最大遺漏號碼 FROM [lottery].[dbo].[TENCENTFFC_MidThree_Count] 
WHERE [TENCENTFFC_ignoreCount] = 1500 
order by [TENCENTFFC_ignorenumber] ";
                SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, User), con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void grvIgnore_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvIgnore.PageIndex = e.NewPageIndex;

            grvIgnore.DataSource = SelectIgnore();
            grvIgnore.DataBind();
        }
    }
}