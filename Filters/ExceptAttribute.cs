using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EstChe.Models;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace EstChe.Filters
{
    public class ExceptAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void OnException(ExceptionContext filterContext)
        {

            if (!filterContext.ExceptionHandled)
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"
                };
            log.Info(filterContext.Exception.Message);

            //IWorkbook workbook = new XSSFWorkbook();
            //ISheet sheet = workbook.CreateSheet("my exceptions");


            //IRow row = sheet.CreateRow(sheet.TopRow+1);

            //ICell cell = row.CreateCell(0);
            //cell.SetCellValue(filterContext.Exception.Message);

            //ICell cell1 = row.CreateCell(1);
            //cell1.SetCellValue(filterContext.Exception.StackTrace);

            //ICell cell2 = row.CreateCell(2);
            //cell2.SetCellValue(log.Info(filterContext.Exception.ToString()));

            //ICell cell3 = row.CreateCell(3);
            //cell2.SetCellValue(filterContext.Exception.Source);

            //ICell cell4 = row.CreateCell(4);
            //cell3.SetCellValue(DateTime.Now);

            //sheet.AutoSizeColumn(0);

            //using (FileStream stream = new FileStream("D:/00/EstChe/outfile.xlsx", FileMode.Create, FileAccess.Write))
            //{
            //    workbook.Write(stream);
            //}


            string path = @"D:\00\EstChe";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream fstream = new FileStream(@"D:\00\EstChe\ote.txt", FileMode.OpenOrCreate))
            {
               
                byte[] array = System.Text.Encoding.Default.GetBytes(filterContext.Exception.Message +"        "+ filterContext.Exception.StackTrace+"            "+
                   filterContext.Exception.Source+"                " + DateTime.Now);
                
                fstream.Write(array, 0, array.Length);
            }

            //ЧЕ ЗА ХУЙНЯ, БД НЕ ПОДКЛЮЧАЕТСЯ, ЛОГИ ПОХОЖИ НА СТЕК ТРЕЙС, ЗАПИСЫВАЮТСЯ ОТДЕЛЬНО ВТФФФФФФФ








            //ExceptInfo exInf = new ExceptInfo()
            //{
            //    ExceptName = filterContext.Exception.Message,
            //    Url = filterContext.Exception.Source,
            //    StackTrace = filterContext.Exception.StackTrace
            //};

            //using (ExceptContext db=new ExceptContext())
            //{
            //    db.ExceptInfos.Add(exInf);
            //    db.SaveChanges();
            //}


            filterContext.ExceptionHandled = true;
        }
    }
}