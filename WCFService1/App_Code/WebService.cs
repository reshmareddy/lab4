﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string queryTable(string name)
    {

        //Declare Connection by passing the connection string from the web config file
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        //Open the connection
        conn.Open();

        string age = "";
        string name2 = "";
        string company = "";
        string position = "";
        SqlCommand cmd = new SqlCommand("Select * From testTable where name='" + name + "'", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            age = age + ";" + reader["age"];
            name2 = name2 + ";" + reader["name"].ToString();
            company = company + ";" + reader["company"].ToString();
            position = position + ";" + reader["position"].ToString();
        }
        reader.Close();
        //close the connection
        conn.Close();

        return "info: " + age + "," + name2 + "," + company + "," + position;

    }

    [WebMethod]
    public string insertTable(string name, string age, string company, string position)
    {
        //Declare Connection by passing the connection string from the web config file
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        //Open the connection
        conn.Open();

        //Declare the sql command
        SqlCommand cmd = new SqlCommand
            ("Insert into testTable(name,age,company,position)values('" + name + "','" + age + "','" + company + "','" + position + "')", conn);

        //Execute the insert query
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        //close the connection
        conn.Close();

        return "Success insert";

    }

    [WebMethod]
    public string deleteTable(string name)
    {
        //Declare Connection by passing the connection string from the web config file
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

        //Open the connection
        conn.Open();

        //Declare the sql command
        SqlCommand cmd = new SqlCommand("Delete From testTable Where name= '" + name + "'", conn);

        //Execute the insert query
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        //close the connection
        conn.Close();

        return "Success delete";
    }
}
