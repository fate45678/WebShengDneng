<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webPlanCycleTENCENTFFC.aspx.cs" Inherits="ShenDnengWeb.webPlanCycleTENCENTFFC" %>

<!DOCTYPE html>

<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
      <script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
    <link href="bootstarp/dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/dashboard/">
    <!-- Custom styles for this template -->
    <link href="dashboard.css" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" >
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" rel="stylesheet" >
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" ></script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../assets/js/ie10-viewport-bug-workaround.js"></script>
  </head>
  <body>
      <form id="form1" runat="server">
    <nav class="navbar navbar-toggleable-md navbar-inverse fixed-top bg-inverse">
        <%--        <button class="navbar-toggler navbar-toggler-right hidden-lg-up" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>--%><%--<a class="navbar-brand" href="#">Dashboard</a>--%>
        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            <%--            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="#">Settings</a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="#">Profile</a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="#">Help</a>
                </li>
            </ul>
           <form class="form-inline mt-2 mt-md-0">
                <input class="form-control mr-sm-2" type="text" placeholder="Search">
                <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
            </form>--%>
        </div>
    </nav>
  <div class="container-fluid">
      <div class="row">
          <nav class="col-sm-3 col-md-2 hidden-xs-down bg-faded sidebar">
              <ul class="nav nav-pills flex-column">
                <li class="nav-item">
                  <a class="nav-link active" href="webPlanCycleTENCENTFFC.aspx">神灯周期计划前三<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="webPlanCycle.aspx">神灯周期计划前三2</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="webPlanCycleTENCENTFFCmidthree.aspx">神灯周期计划中三</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="webPlanCycleTENCENTFFCbackthree.aspx">神灯周期计划后三</a>
                </li>
                <li class="nav-item">
                    <asp:GridView ID="grvIgnore" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grvIgnore_PageIndexChanging" Width="195px">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </li>
              </ul>
          </nav>
          <main class="col-sm-9 pt-3">
              <div>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </div>
            <h1>神灯周期计划 - 腾讯奇趣彩</h1>
             每期注數:<asp:Label ID="lbBets" runat="server" Text="0注"></asp:Label>
              ，共:<asp:Label ID="lblBetsMoney" runat="server" Text="0"></asp:Label>元
              ，本计划周期中奖率: <asp:Label ID="lblPlanWinOpp" runat="server" Text="0"></asp:Label>% ，<asp:Label ID="lbWinCount" runat="server" Text=""></asp:Label>
          ，<asp:Label ID="lbFailCount" runat="server" Text=""></asp:Label><br />
            目前下注:<asp:Label ID="lblCurrentBetsCycle" runat="server" Text="0%"></asp:Label>周期
              ，共下注<asp:Label ID="lblSumBetsCycle" runat="server" Text="0"></asp:Label>期
              <br />
              总投注额:<asp:Label ID="lblSumBetsMoney" runat="server" Text="0"></asp:Label>元
              ，奖金:<asp:Label ID="lblWinMoney" runat="server" Text="0"></asp:Label>元
              ，盈亏<asp:Label ID="lblProfit" runat="server" Text="0"></asp:Label>元<br />
              <br />
               <asp:Label ID="lblPlanCycleSelected" runat="server" Text="第01周期" Visible="False"></asp:Label><asp:DropDownList ID="cbPlanCycleSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbPlanCycleSelect_SelectedIndexChanged"></asp:DropDownList>
              <br />
          <asp:TextBox ID="txtPlanCycle" runat="server" Height="256px" Width="1174px" TextMode="MultiLine"></asp:TextBox>
          <br />
                            <br />
              <asp:TextBox ID="txtGameNum" runat="server" Visible="False"></asp:TextBox>&nbsp;<asp:DropDownList ID="cbMoney" runat="server" AutoPostBack="True" Visible="False">
                  <asp:ListItem Value="2">2元</asp:ListItem>
                  <asp:ListItem Value="0.2">2角</asp:ListItem>
                  <asp:ListItem Value="0.02">2分</asp:ListItem>
                  <asp:ListItem Value="0.002">2厘</asp:ListItem>
          </asp:DropDownList>
              <asp:TextBox ID="txtTimes" runat="server" Visible="False"></asp:TextBox>&nbsp;<asp:CheckBox ID="ckRegularCycle" runat="server" Text="規律周期" Checked="True" Visible="False" />
              <asp:CheckBox ID="ckWinToNextCycle" runat="server" Text="中奖即进入下一周期" Visible="False" />
              <br />
              <asp:DropDownList ID="cbGameKind" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbGameKind_SelectedIndexChanged" Visible="False">
                  <asp:ListItem Value="FrontThree">前三</asp:ListItem>
                  <asp:ListItem Value="MidThree">中三</asp:ListItem>
                  <asp:ListItem Value="BackThree">后三</asp:ListItem>
          </asp:DropDownList>
              <asp:DropDownList ID="cbGameDirect" runat="server" AutoPostBack="True" Visible="False">
                  <asp:ListItem Value="Single">单式</asp:ListItem>
          </asp:DropDownList>
              <asp:DropDownList ID="cbGamePlus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbGamePlus_SelectedIndexChanged" Visible="False">
                  <asp:ListItem Value="300+">300+</asp:ListItem>
                  <asp:ListItem Value="400+">400+</asp:ListItem>
                  <asp:ListItem Value="500+">500+</asp:ListItem>
          </asp:DropDownList>
              <asp:DropDownList ID="cbGamePlan" runat="server" AutoPostBack="True" Visible="False">
                  <asp:ListItem>风暴计划</asp:ListItem>
                  <asp:ListItem>雷光计划</asp:ListItem>
                  <asp:ListItem>烈是计划</asp:ListItem>
          </asp:DropDownList>
              <asp:DropDownList ID="cbGameCycle" runat="server" AutoPostBack="True" Visible="False">
                  <asp:ListItem Value="1">一期一周</asp:ListItem>
          </asp:DropDownList>
              &nbsp;&nbsp;
              <asp:Button ID="btnViewResult" runat="server" Text="观看" Width="93px" OnClick="btnViewResult_Click" Visible="False" />
              &nbsp;
              <asp:Button ID="Button2" runat="server" Text="刷新" Width="93px" OnClick="btnViewResult_Click" />
                             <asp:GridView ID="grvResult" runat="server" OnRowDataBound="grvResult_RowDataBound1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" Height="362px" OnPageIndexChanging="grvResult_PageIndexChanging" Width="830px">
                                 <AlternatingRowStyle BackColor="#DCDCDC" />
                                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                 <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                 <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                 <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                 <SortedDescendingHeaderStyle BackColor="#000065" />
          </asp:GridView>

          <br />
          </main>
      </div>
  </div>
      </form>
  </body>
</html>