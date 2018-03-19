using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S3_WebApplication.Models;

namespace S3_WebApplication.Controllers
{
    public class SyllabusController : Controller
    {
        LABTestDBEntities db = new LABTestDBEntities();

        tblSyllabu Syllabus = new tblSyllabu();
        private tblSyllabusLanguage syllabusLanguage;


        public ActionResult SyllabusList()
        {
            //load dropdowns

            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");

            //ends


            List<ViewList> viewLists = new List<ViewList>();

            ViewList aviewList = new ViewList();


            var allList = (from syl in db.tblSyllabus
                           join tr in db.tblTrades on syl.colTradeId equals tr.colTradeId
                           join le in db.tblLevels on syl.colLevelId equals le.colLevelId
                           join sylan in db.tblSyllabusLanguages on syl.colSyllabusId equals sylan.colSyllabusId
                           join lan in db.tblLanguages on sylan.colLanguageId equals lan.colLanguageId
                           select new
                           {
                               Id = syl.colSyllabusId,
                               SyllabusName = syl.colSyllabusName,
                               TradeName = tr.colTradeName,
                               LevelName = le.colLevelName,
                               SylDoc = syl.colSyllabusDocUrl,
                               TestDoc = syl.colTestPlanUrl,
                               Language = lan.colLanguageShortName
                           }).ToList();


            int temp = 0;
            int done = 0;


            foreach (var i in allList)
            {
                aviewList = new ViewList();
                if (i.Id == temp)
                {
                    aviewList = viewLists.Where(x => x.Id == done).Select(x => x).First();
                    var s = aviewList.Language;
                    aviewList.Language = s + ", " + i.Language;
                }
                else
                {
                    aviewList.Id = i.Id;
                    aviewList.SyllabusName = i.SyllabusName;
                    aviewList.TradeName = i.TradeName;
                    aviewList.LevelName = i.LevelName;
                    aviewList.SylDoc = i.SylDoc;
                    aviewList.TestDoc = i.TestDoc;
                    aviewList.Language = i.Language;

                    viewLists.Add(aviewList);

                    done = i.Id;
                }


                temp = i.Id;
            }


            ViewBag.AllList = viewLists;


            return View();
        }


        public ActionResult SearchedSyllabusList()
        {
            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");


            List<ViewList> viewLists = new List<ViewList>();

            ViewList aviewList = new ViewList();


            var allList = (from syl in db.tblSyllabus
                           join tr in db.tblTrades on syl.colTradeId equals tr.colTradeId
                           join le in db.tblLevels on syl.colLevelId equals le.colLevelId
                           join sylan in db.tblSyllabusLanguages on syl.colSyllabusId equals sylan.colSyllabusId
                           join lan in db.tblLanguages on sylan.colLanguageId equals lan.colLanguageId
                           select new
                           {
                               Id = syl.colSyllabusId,
                               SyllabusName = syl.colSyllabusName,
                               TradeName = tr.colTradeName,
                               LevelName = le.colLevelName,
                               SylDoc = syl.colSyllabusDocUrl,
                               TestDoc = syl.colTestPlanUrl,
                               Language = lan.colLanguageShortName
                           }).ToList();


            int temp = 0;
            int done = 0;


            foreach (var i in allList)
            {
                aviewList = new ViewList();
                if (i.Id == temp)
                {
                    aviewList = viewLists.Where(x => x.Id == done).Select(x => x).First();
                    var s = aviewList.Language;
                    aviewList.Language = s + ", " + i.Language;
                }
                else
                {
                    aviewList.Id = i.Id;
                    aviewList.SyllabusName = i.SyllabusName;
                    aviewList.TradeName = i.TradeName;
                    aviewList.LevelName = i.LevelName;
                    aviewList.SylDoc = i.SylDoc;
                    aviewList.TestDoc = i.TestDoc;
                    aviewList.Language = i.Language;

                    viewLists.Add(aviewList);

                    done = i.Id;
                }


                temp = i.Id;
            }


            ViewBag.AllList = viewLists;


            return View();
        }

        [HttpPost]
        public ActionResult SearchedSyllabusList(int? trade, int? level)
        {
            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");

            List<ViewList> viewLists = new List<ViewList>();

            ViewList aviewList = new ViewList();


            var allList = (from syl in db.tblSyllabus
                           where syl.colTradeId == trade && syl.colLevelId == level
                           join tr in db.tblTrades on syl.colTradeId equals tr.colTradeId
                           join le in db.tblLevels on syl.colLevelId equals le.colLevelId
                           join sylan in db.tblSyllabusLanguages on syl.colSyllabusId equals sylan.colSyllabusId
                           join lan in db.tblLanguages on sylan.colLanguageId equals lan.colLanguageId
                           select new
                           {
                               Id = syl.colSyllabusId,
                               SyllabusName = syl.colSyllabusName,
                               TradeName = tr.colTradeName,
                               LevelName = le.colLevelName,
                               SylDoc = syl.colSyllabusDocUrl,
                               TestDoc = syl.colTestPlanUrl,
                               Language = lan.colLanguageShortName
                           }).ToList();


            int temp = 0;
            int done = 0;


            foreach (var i in allList)
            {
                aviewList = new ViewList();
                if (i.Id == temp)
                {
                    aviewList = viewLists.Where(x => x.Id == done).Select(x => x).First();
                    var s = aviewList.Language;
                    aviewList.Language = s + ", " + i.Language;
                }
                else
                {
                    aviewList.Id = i.Id;
                    aviewList.SyllabusName = i.SyllabusName;
                    aviewList.TradeName = i.TradeName;
                    aviewList.LevelName = i.LevelName;
                    aviewList.SylDoc = i.SylDoc;
                    aviewList.TestDoc = i.TestDoc;
                    aviewList.Language = i.Language;

                    viewLists.Add(aviewList);

                    done = i.Id;
                }


                temp = i.Id;
            }


            ViewBag.AllList = viewLists;

            return View();
        }

        public FileResult Download(string filePath)
        {
            var FileVirtualPath = filePath;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

        public ActionResult Edit(int id)
        {

            tblSyllabu syllabus = db.tblSyllabus.Find(id);

            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName", syllabus.colTradeId);

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName", syllabus.colLevelId);

            ViewBag.LanguageList = new SelectList(db.tblLanguages, "colLanguageId", "colLanguageName");

            var languageSelectedList = db.tblSyllabusLanguages.Where(x => x.colSyllabusId == id).Select(x => x.colLanguageId).ToList();

            ViewBag.SelectedLanguage = languageSelectedList;

            Session["Id"] = id;

            return View(syllabus);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, HttpPostedFileBase sylFile, HttpPostedFileBase testPlanFile)
        {
            int id = Convert.ToInt16(Session["Id"].ToString());

            Syllabus = db.tblSyllabus.Where(x => x.colSyllabusId == id).Select(x => x).First();

            tblSyllabu syllabus = db.tblSyllabus.Find(id);

            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName", syllabus.colTradeId);

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName", syllabus.colLevelId);

            ViewBag.LanguageList = new SelectList(db.tblLanguages, "colLanguageId", "colLanguageName");

            var languageSelectedList = db.tblSyllabusLanguages.Where(x => x.colSyllabusId == id).Select(x => x.colLanguageId).ToList();

            ViewBag.SelectedLanguage = languageSelectedList;





            //form collection starts

            var trade = formCollection["Trade"];

            var level = formCollection["Level"];

            var language = formCollection["Item"];

            string[] languageList = language.Split(',');

            var syllabusName = formCollection["SyllabusName"];

            var developmentOfficer = formCollection["DevelopmentOfficer"];

            var manager = formCollection["Manager"];

            var activeDate = formCollection["ActiveDate"];

            if (sylFile != null)
            {
                var ext = Path.GetExtension(sylFile.FileName);

                if ((ext == ".pdf" || ext == ".csv" || ext == ".PDF" || ext == ".CSV"))
                {
                    string path1 = Path.Combine(Server.MapPath("/UploadedFiles"), Path.GetFileName(sylFile.FileName));
                    sylFile.SaveAs(path1);
                    string file1 = "~/UploadedFiles/" + Path.GetFileName(sylFile.FileName);

                    Syllabus.colSyllabusDocUrl = file1;
                }
                else
                {
                    ViewBag.Message = 0;
                    //                    return RedirectToAction("Edit");
                    return View(syllabus);
                }
            }
            if (testPlanFile != null)
            {
                var ext2 = Path.GetExtension(testPlanFile.FileName);

                if (ext2 == ".pdf" || ext2 == ".csv" || ext2 == ".PDF" || ext2 == ".CSV")
                {
                    string path2 = Path.Combine(Server.MapPath("/UploadedFiles"), Path.GetFileName(testPlanFile.FileName));
                    testPlanFile.SaveAs(path2);
                    string file2 = "~/UploadedFiles/" + Path.GetFileName(testPlanFile.FileName);

                    Syllabus.colTestPlanUrl = file2;
                }
                else
                {


                    ViewBag.Message = 0;
                    //                    return RedirectToAction("Edit");

                    return View(syllabus);
                }
            }








            //update into syllabus



            Syllabus.colTradeId = Convert.ToInt16(trade);
            Syllabus.colLevelId = Convert.ToInt16(level);
            Syllabus.colSyllabusName = syllabusName;
            Syllabus.colDevelopmentOfficer = developmentOfficer;
            Syllabus.colManager = manager;
            Syllabus.colActiveDt = Convert.ToDateTime(activeDate);
            //            Syllabus.colSyllabusDocUrl = file1;
            //            Syllabus.colTestPlanUrl = file2;

            db.SaveChanges();

            //ends


            //deleting previous data for language list

            var languageDeleteList = db.tblSyllabusLanguages.Where(x => x.colSyllabusId == id).Select(x => x).ToList();

            for (int i = 0; i < languageDeleteList.Count; i++)
            {
                tblSyllabusLanguage tblsyllabu = db.tblSyllabusLanguages.Where(x => x.colSyllabusId == id).Select(x => x).First();
                db.tblSyllabusLanguages.Remove(tblsyllabu);
                db.SaveChanges();
            }

            //deleting ends



            // language insert list

            //            var syllabusId = db.tblSyllabus.Select(x => x.colSyllabusId).ToList().Last();
            for (int i = 0; i < languageList.Count(); i++)
            {
                syllabusLanguage = new tblSyllabusLanguage();

                int languageId = Convert.ToInt16(languageList[i]);

                syllabusLanguage.colSyllabusId = id;
                syllabusLanguage.colLanguageId = languageId;

                db.tblSyllabusLanguages.Add(syllabusLanguage);
                db.SaveChanges();

            }
            //ends
            return RedirectToAction("SearchedSyllabusList");


            //            return View();
        }










        //Get List by trade, level

        public JsonResult GetSchedule(int? trade, int? level)
        {
            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");

            List<ViewList> viewLists = new List<ViewList>();

            ViewList aviewList = new ViewList();


            var allList = (from syl in db.tblSyllabus
                           where syl.colTradeId == trade && syl.colLevelId == level
                           join tr in db.tblTrades on syl.colTradeId equals tr.colTradeId
                           join le in db.tblLevels on syl.colLevelId equals le.colLevelId
                           join sylan in db.tblSyllabusLanguages on syl.colSyllabusId equals sylan.colSyllabusId
                           join lan in db.tblLanguages on sylan.colLanguageId equals lan.colLanguageId
                           select new
                           {
                               Id = syl.colSyllabusId,
                               SyllabusName = syl.colSyllabusName,
                               TradeName = tr.colTradeName,
                               LevelName = le.colLevelName,
                               SylDoc = syl.colSyllabusDocUrl,
                               TestDoc = syl.colTestPlanUrl,
                               Language = lan.colLanguageShortName
                           }).ToList();


            int temp = 0;
            int done = 0;


            foreach (var i in allList)
            {
                aviewList = new ViewList();
                if (i.Id == temp)
                {
                    aviewList = viewLists.Where(x => x.Id == done).Select(x => x).First();
                    var s = aviewList.Language;
                    aviewList.Language = s + ", " + i.Language;
                }
                else
                {
                    aviewList.Id = i.Id;
                    aviewList.SyllabusName = i.SyllabusName;
                    aviewList.TradeName = i.TradeName;
                    aviewList.LevelName = i.LevelName;
                    aviewList.SylDoc = i.SylDoc;
                    aviewList.TestDoc = i.TestDoc;
                    aviewList.Language = i.Language;

                    viewLists.Add(aviewList);

                    done = i.Id;
                }


                temp = i.Id;
            }


            ViewBag.AllList = viewLists;

            return Json(viewLists, JsonRequestBehavior.AllowGet);
        }



        //All List
        public JsonResult JsonAllList()
        {
            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");


            List<ViewList> viewLists = new List<ViewList>();

            ViewList aviewList = new ViewList();


            var allList = (from syl in db.tblSyllabus
                           join tr in db.tblTrades on syl.colTradeId equals tr.colTradeId
                           join le in db.tblLevels on syl.colLevelId equals le.colLevelId
                           join sylan in db.tblSyllabusLanguages on syl.colSyllabusId equals sylan.colSyllabusId
                           join lan in db.tblLanguages on sylan.colLanguageId equals lan.colLanguageId
                           select new
                           {
                               Id = syl.colSyllabusId,
                               SyllabusName = syl.colSyllabusName,
                               TradeName = tr.colTradeName,
                               LevelName = le.colLevelName,
                               SylDoc = syl.colSyllabusDocUrl,
                               TestDoc = syl.colTestPlanUrl,
                               Language = lan.colLanguageShortName
                           }).ToList();


            int temp = 0;
            int done = 0;


            foreach (var i in allList)
            {
                aviewList = new ViewList();
                if (i.Id == temp)
                {
                    aviewList = viewLists.Where(x => x.Id == done).Select(x => x).First();
                    var s = aviewList.Language;
                    aviewList.Language = s + ", " + i.Language;
                }
                else
                {
                    aviewList.Id = i.Id;
                    aviewList.SyllabusName = i.SyllabusName;
                    aviewList.TradeName = i.TradeName;
                    aviewList.LevelName = i.LevelName;
                    aviewList.SylDoc = i.SylDoc;
                    aviewList.TestDoc = i.TestDoc;
                    aviewList.Language = i.Language;

                    viewLists.Add(aviewList);

                    done = i.Id;
                }


                temp = i.Id;
            }


            ViewBag.AllList = viewLists;


            return Json(viewLists, JsonRequestBehavior.AllowGet);
        }

        //End
        public JsonResult TradeJsonResult()
        {
            var tradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");
            return Json(tradeList, JsonRequestBehavior.AllowGet);
        }
        //        public JsonResult TradeJsonResult(int id)
        //        {
        //            var tradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName");
        //            return Json(tradeList, JsonRequestBehavior.AllowGet);
        //        }
        public JsonResult LevelJsonResult()
        {
            var levelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName");

            return Json(levelList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LanguageJsonResult()
        {
            var languageList = new SelectList(db.tblLanguages, "colLanguageId", "colLanguageName");

            return Json(languageList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateJsonResult(int trade, int level, string language, string syllabusName, string sylFile, string testPlan, string developmentOfficer, string manager, string activeDate)
        {

            string[] languageList = language.Split(',');

            string path1 = Path.Combine(Server.MapPath("/UploadedFiles"), Path.GetFileName(sylFile));
            //            s1.SaveAs(path1);
            string file1 = "~/UploadedFiles/" + Path.GetFileName(sylFile);
            //
            string path2 = Path.Combine(Server.MapPath("/UploadedFiles"), Path.GetFileName(testPlan));
            //            t2.SaveAs(path2);
            string file2 = "~/UploadedFiles/" + Path.GetFileName(testPlan);

            Syllabus.colTradeId = Convert.ToInt16(trade);
            Syllabus.colLevelId = Convert.ToInt16(level);
            Syllabus.colSyllabusName = syllabusName;
            Syllabus.colDevelopmentOfficer = developmentOfficer;
            Syllabus.colManager = manager;
            Syllabus.colActiveDt = Convert.ToDateTime(activeDate);
            Syllabus.colSyllabusDocUrl = file1;
            Syllabus.colTestPlanUrl = file2;

            db.tblSyllabus.Add(Syllabus);
            db.SaveChanges();


            var syllabusId = db.tblSyllabus.Select(x => x.colSyllabusId).ToList().Last();
            for (int i = 0; i < languageList.Count(); i++)
            {
                syllabusLanguage = new tblSyllabusLanguage();

                int languageId = Convert.ToInt16(languageList[i]);

                syllabusLanguage.colSyllabusId = syllabusId;
                syllabusLanguage.colLanguageId = languageId;

                db.tblSyllabusLanguages.Add(syllabusLanguage);
                db.SaveChanges();

            }

            var msg = "Done";

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EditJsonResult(int id)
        {

            tblSyllabu syllabus = db.tblSyllabus.Find(id);

            ViewBag.TradeList = new SelectList(db.tblTrades, "colTradeId", "colTradeName", syllabus.colTradeId);

            ViewBag.LevelList = new SelectList(db.tblLevels, "colLevelId", "colLevelName", syllabus.colLevelId);

            ViewBag.LanguageList = new SelectList(db.tblLanguages, "colLanguageId", "colLanguageName");

            var languageSelectedList = db.tblSyllabusLanguages.Where(x => x.colSyllabusId == id).Select(x => x.colLanguageId).ToList();

            ViewBag.SelectedLanguage = languageSelectedList;

            Session["Id"] = id;

            return Json(syllabus, JsonRequestBehavior.AllowGet);
        }

    }
}