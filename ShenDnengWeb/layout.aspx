<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="layout.aspx.cs" Inherits="ShenDnengWeb.layout" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
    <link href="bootstarp/dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/dashboard/">
    <!-- Custom styles for this template -->
    <link href="dashboard.css" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" >
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" rel="stylesheet" >
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" ></script>
  </head>
  <body>
    <nav class="navbar navbar-toggleable-md navbar-inverse fixed-top bg-inverse">
        <button class="navbar-toggler navbar-toggler-right hidden-lg-up" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <%--<a class="navbar-brand" href="#">Dashboard</a>--%>
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
                  <a class="nav-link active" href="#">神灯周期计划<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">代理计划</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">计划上传</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">缩水工具</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">趋势分析</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">走势图</a>
                </li>
              </ul>
          </nav>
      </div>
  </div>
  </body>
</html>
