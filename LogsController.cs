using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace CreativityJungle
{
    public partial class Log
    {
        [Key]
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }

    public class LogsController : Controller
    {
        string connstring = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: Logs
        public ActionResult Index()
        {
            List<Log> logs = new List<Log>();

            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                SqlCommand cmdGetLogs = new SqlCommand("Select * from log", conn);
                SqlDataReader rdrLogs = cmdGetLogs.ExecuteReader();

                while (rdrLogs.Read())
                {
                    // Create a AuthorModel object
                    Log log = new Log()
                    {
                        ID = (int)rdrLogs["ID"],
                        Date = (DateTime)rdrLogs["Date"],
                        Thread = (string)rdrLogs["Thread"],
                        Level = (string)rdrLogs["Level"],
                        Logger = (string)rdrLogs["Logger"],
                        Message = (string)rdrLogs["Message"],
                        Exception = (string)rdrLogs["Exception"]
                    };
                    logs.Add(log);
                }
                rdrLogs.Close();
                conn.Close();
            }
            return View(logs);
        }

        // Methods for use with jQuery AJAX calls

        // Delete via AJAX
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                SqlCommand cmdGetLogs = new SqlCommand("delete from log where id = " + id, conn);
                cmdGetLogs.ExecuteNonQuery();
                conn.Close();
            }

            var message = string.Format("Log record deleted from the database!");
            return Json(new
            {
                id = id,
                message = message
            });
        }

        // Get PartialView of Details for AJAX display
        [HttpGet]
        public PartialViewResult LogDetails(int id)
        {
            Log log = null;

            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                SqlCommand cmdGetLogs = new SqlCommand("Select * from log where id = " + id, conn);
                SqlDataReader rdrLog = cmdGetLogs.ExecuteReader();

                while (rdrLog.Read())
                {
                    // Create a AuthorModel object
                    log = new Log()
                    {
                        Date = (DateTime)rdrLog["Date"],
                        Thread = (string)rdrLog["Thread"],
                        Level = (string)rdrLog["Level"],
                        Logger = (string)rdrLog["Logger"],
                        Message = (string)rdrLog["Message"],
                        Exception = (string)rdrLog["Exception"]
                    };
                }
                rdrLog.Close();
                conn.Close();
            }
            return PartialView(log);
        }
    }
}
