﻿using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MVCProjem.Models;
using MVCProjem.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCProjem.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCProjemContext _dbcontext;
        public HomeController(MVCProjemContext config)
        {
            this._dbcontext = config;
        }

        public IActionResult Index()
        {


            //string connectString = _dbcontext.GetConnectionString("DefaultConnection");
            //SqlConnection sql = new SqlConnection(connectString);
            //sql.Open();
            ////SqlCommand cmdName = new SqlCommand("select ad from ogrenci", sql);
            ////SqlCommand cmdSurname = new SqlCommand("select soyad from ogrenci", sql);
            ////var name = (string)cmdName.ExecuteScalar();
            ////var surname = (string)cmdSurname.ExecuteScalar();
            ////ViewData["ad"] = name;
            ////ViewData["soyad"] = surname;
            //sql.Close();
            //ViewData["Ad"] = "Gençay Yıldız";

            return View();

            //return RedirectToAction("Ogrenciler", "Home");//return View();return View();
        }

        [HttpPost]
        public IActionResult Update(OgrenciModel ogrenciModel)
        {

            var ogrenci = _dbcontext.Ogrenciler.AsNoTracking().FirstOrDefault(q => q.ogrno == ogrenciModel.ogrno);
            if (ogrenci != null)
            {
                ogrenci.ad = ogrenciModel.ad;
                ogrenci.soyad = ogrenciModel.soyad;
                ogrenci.dtarih = ogrenciModel.dtarih;
                ogrenci.cinsiyet = ogrenciModel.cinsiyet;
                ogrenci.sinif = ogrenciModel.sinif;
                ogrenci.puan = ogrenciModel.puan;
            }
            _dbcontext.Ogrenciler.Update(ogrenci);
            _dbcontext.SaveChanges();

            var temp = _dbcontext.Ogrenciler.Where(q => q.ad.Contains(ogrenciModel.ad)).Take(10).ToList();

            //if (ogrenciModel.ogrno == null || string.IsNullOrEmpty(ogrenciModel.ad) || string.IsNullOrEmpty(ogrenciModel.soyad))
            //{
            //    return BadRequest();
            //}
            //string ad = ogrenciModel.ad;
            //string soyad = ogrenciModel.soyad;
            //int ogrno = ogrenciModel.ogrno;
            //string connectString = _dbcontext.GetConnectionString("DefaultConnection");
            //SqlConnection sql = new SqlConnection(connectString);
            //sql.Open();
            //string sorgum = "update Ogrenciler set ad='" + ad.ToString() + "', soyad='" + soyad.ToString() + "'  where ogrno =" + ogrno + "";
            //SqlCommand command = new SqlCommand(sorgum, sql);
            //command.ExecuteNonQuery();
            ////SqlDataAdapter adptr = new SqlDataAdapter(sorgum, sql);
            //sql.Close();
            return RedirectToAction("Ogrenciler", "Home");//Ogrenciler();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        /*Ogrencilerin DB den çelildiği alan*/
        public IActionResult Ogrenciler()
        {

            // öğrenci listesinden 5 öğrenci çekelim
            List<OgrenciModel> ogrenciModels = _dbcontext.Ogrenciler.Take(5).ToList();
            //return View(objList);
            /*
            string connectString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sql = new SqlConnection(connectString);
            sql.Open();
            //SqlCommand cmdName = new SqlCommand("select ad from ogrenci", sql);
            //SqlCommand cmdSurname = new SqlCommand("select soyad from ogrenci", sql);
            //var name = (string)cmdName.ExecuteScalar();
            //var surname = (string)cmdSurname.ExecuteScalar();
            //ViewData["ad"] = name;
            //ViewData["soyad"] = surname;
            string sorgum = "select top 10 * from Ogrenciler order by ogrno desc";
            SqlDataAdapter adptr = new SqlDataAdapter(sorgum, sql);
            DataTable dt = new DataTable(sorgum);
            adptr.Fill(dt);
            List<OgrenciModel> ogrenciModels = new List<OgrenciModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OgrenciModel deger = new OgrenciModel
                {
                    //Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                    ogrno = Convert.ToInt32(dt.Rows[i]["ogrno"].ToString()),
                    ad = dt.Rows[i]["ad"].ToString(),
                    soyad = dt.Rows[i]["soyad"].ToString(),
                    dtarih = Convert.ToDateTime(dt.Rows[i]["dtarih"]),
                    cinsiyet = dt.Rows[i]["cinsiyet"].ToString(),
                    sinif = dt.Rows[i]["sinif"].ToString(),
                    puan = Convert.ToInt32(dt.Rows[i]["puan"])
                };
                ogrenciModels.Add(deger);
            }
            sql.Close();
            */
            return View(ogrenciModels);
        }

        /*Bu alan silme işlemi yapar*/
        public IActionResult Delete(OgrenciModel ogrenciModel)
        {
            _dbcontext.Ogrenciler.Remove(ogrenciModel);
            _dbcontext.SaveChanges();

            //string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //SqlConnection sql = new SqlConnection(connectionString);
            //sql.Open();
            //string sorgu = "delete from Ogrenciler where ogrno = "+ogrenciModel.ogrno+"";
            //SqlCommand cmd = new SqlCommand(sorgu,sql);
            //cmd.ExecuteNonQuery();
            //sql.Close();
            return RedirectToAction("Ogrenciler", "Home");//return View();
        }
        
        public IActionResult Create(OgrenciModel ogrenciModel)
        {

            _dbcontext.Ogrenciler.Add(ogrenciModel);
            _dbcontext.SaveChanges();
            #region
            //klasik yöntem
            //string t = Convert.ToDateTime(ogrenciModel.dtarih).ToString("dd.MM.yyyy");
            //string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //SqlConnection sql = new SqlConnection(connectionString);
            //sql.Open();

            //string sorgu = "insert into  Ogrenciler(ad,soyad,dtarih,cinsiyet,sinif,puan) values(" +
            //"'"+ogrenciModel.ad.ToString()+ "','" + ogrenciModel.soyad.ToString() + "' ,'" + ogrenciModel.dtarih+ "'  , '" + ogrenciModel.cinsiyet.ToString() + "', '" + ogrenciModel.sinif.ToString()+ 
            //"'," +ogrenciModel.puan+")";

            // SqlCommand cmd = new SqlCommand(sorgu,sql);
            // cmd.ExecuteNonQuery();
            // sql.Close();

            //SqlConnection sql = new SqlConnection();

            //MVCProjemContext context = new MVCProjemContext();
            //context.Ogrenciler.Add(ogrenciModel);
            //context.SaveChanges();
            #endregion
            return RedirectToAction("Ogrenciler", "Home");//return View();
        }

        int count;
        public IActionResult Search(OgrenciModel ogrenciModel)
        {
            List<OgrenciModel> list = _dbcontext.Ogrenciler.Where(x => (x.ad+ " "+x.soyad).Contains(ogrenciModel.ad)).ToList();
            count = list.Count();
            //ViewData["say"] = count;
            //ViewBag.FirstName = "Yusuf";
            //ViewBag.LastName = "SEZER";
            //ViewData["Ad"] = "Gençay Yıldız";
            TempData["Ad"] = "Gençay Yıldız";
            TempData["say"] = count;


            return RedirectToAction("Ogrenciler", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}