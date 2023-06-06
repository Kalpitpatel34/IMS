using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLibrary
{
    public class InjuryData : Controller, IInjuryData
    {
        private readonly ISQLDataAccess _db;
        private readonly IConfiguration _config;

        public InjuryData(ISQLDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }


        //do an excel sheet generation here
        public async Task<FileResult>  CreateAndPopulateExcelFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage package = new ExcelPackage();

            package.Workbook.Properties.Title = "Injury Management System Data";
            package.Workbook.Properties.Author = "Injury Management Automated Data Sorting";
            package.Workbook.Properties.Subject = "Injury Data";
            package.Workbook.Properties.Keywords = "Injury, Data";

            var workSheet = package.Workbook.Worksheets.Add("Data Table");

            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            string columnString = _config.GetSection("ExcelColumns").Value;
            var columns = columnString.Split(',');

            foreach(var column in columns.Select((value, i) => (value, i)))
            {
                workSheet.Cells[1, column.i + 1].Value = column.value;
                workSheet.Cells[1, column.i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[1, column.i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[1, column.i + 1].Style.Fill.BackgroundColor.SetColor(Color.Beige);
                workSheet.Column(column.i + 1).AutoFit();
            }

            int recordIndex = 2;

            List<AllInjuryInfo_Model> dataTable = await GetAllInfo();

            foreach (AllInjuryInfo_Model article in dataTable)
            {
                workSheet.Cells[recordIndex, 1].Value = article.ID;
                workSheet.Cells[recordIndex, 2].Value = article.Name;
                workSheet.Cells[recordIndex, 3].Value = article.DOB;
                workSheet.Cells[recordIndex, 3].Style.Numberformat.Format = "mm/dd/yyyy hh:mm:ss AM/PM";
                workSheet.Cells[recordIndex, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[recordIndex, 3].AutoFitColumns();
                workSheet.Cells[recordIndex, 4].Value = article.Sex;
                workSheet.Cells[recordIndex, 5].Value = article.Date_of_Injury;
                workSheet.Cells[recordIndex, 5].Style.Numberformat.Format = "mm/dd/yyyy hh:mm:ss AM/PM";
                workSheet.Cells[recordIndex, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[recordIndex, 5].AutoFitColumns();
                workSheet.Cells[recordIndex, 6].Value = article.PlaceWhereInjuryOccured;
                workSheet.Cells[recordIndex, 7].Value = article.SportOrRecreationalActivity;
                workSheet.Cells[recordIndex, 8].Value = article.AreaOfInjury;
                workSheet.Cells[recordIndex, 9].Value = article.MechanismOfInjury;
                workSheet.Cells[recordIndex, 10].Value = article.NatureOfActivity;
                workSheet.Cells[recordIndex, 11].Value = article.NatureOfInjury;
                workSheet.Cells[recordIndex, 12].Value = article.SeverityOfInjury;
                workSheet.Cells[recordIndex, 13].Value = article.TypeOfInjury;
                workSheet.Cells[recordIndex, 14].Value = article.GroundSurface;
                workSheet.Cells[recordIndex, 15].Value = article.TimeOfInjury;
                workSheet.Cells[recordIndex, 16].Value = article.DataEnteredBy;
                recordIndex++;
            }

            string p_strPath = _config.GetSection("ExcelDownloadPath").Value;

            if (System.IO.File.Exists(p_strPath))
                System.IO.File.Delete(p_strPath);

            FileStream objFileStrm = System.IO.File.Create(p_strPath);
            objFileStrm.Close(); 

            System.IO.File.WriteAllBytes(p_strPath, package.GetAsByteArray());
            package.Dispose();

            string path = _config.GetSection("ExcelDownloadPath").Value;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);


            //Send the File to Download.
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DataTable.xlsx");

            //Plan is to pull data from the database and make sure that implementation is flexible. Meaning, in case in the future more
            // tables or columns get added, you should be able to easily adjust. 
            // It's highly suggested that you create helper methods that would be responsible for populating worksheets and their columns 
        }

        public Task<List<UniqueIdentifiers_Model>> GetUniqueIdentifiersRow(String id)
        {
            string sql = "Select * from dbo.UniqueIdentifiers Where dbo.UniqueIdentifiers.Id = " + id;

            return _db.LoadData<UniqueIdentifiers_Model, dynamic>(sql, new { });
        }

        public Task<List<NatureOfInjury_Model>> GetNatureOfInjuryRow(String id)
        {
            string sql = "Select * from dbo.NatureOfInjury Where dbo.NatureOfInjury.Id = " + id;

            return _db.LoadData<NatureOfInjury_Model, dynamic>(sql, new { });
        }

        public Task<List<LocationAssociatedWithInjury_Model>> GetLAWIRow(String id)
        {
            string sql = "Select * from dbo.LocationAssociatedWithInjury Where dbo.LocationAssociatedWithInjury.Id = " + id;

            return _db.LoadData<LocationAssociatedWithInjury_Model, dynamic>(sql, new { });
        }

        public Task<List<SupplementaryInjuryMechanism_Model>> GetSIMRow(String id)
        {
            string sql = "Select * from dbo.SupplementaryInjuryMechanism Where dbo.SupplementaryInjuryMechanism.Id = " + id;

            return _db.LoadData<SupplementaryInjuryMechanism_Model, dynamic>(sql, new { });
        }

        public Task<List<AdditionalInjuryInformation_Model>> GetAIIRow(String id)
        {
            string sql = "Select * from dbo.AdditionalInjuryInformation Where dbo.AdditionalInjuryInformation.Id = " + id;

            return _db.LoadData<AdditionalInjuryInformation_Model, dynamic>(sql, new { });
        }

        //Select Method for future scaling in case display of data is needed
        public Task<List<UniqueIdentifiers_Model>> GetGeneralInjuryInfo()
        {
            //select method
            //string sql = "Select uid.*, noi.* from dbo.UniqueIdentifiers as uid, dbo.NatureOfInjury as noi where uid.id = noi.id";

            string sql = "Select uid.* from dbo.UniqueIdentifiers as uid";

            return _db.LoadData<UniqueIdentifiers_Model, dynamic>(sql, new { });
        }

        public Task<List<NatureOfInjury_Model>> GetNatureOfInjuryInfo()
        {
            string sql = "Select noi.* from dbo.NatureOfInjury as noi";

            return _db.LoadData<NatureOfInjury_Model, dynamic>(sql, new { });
        }

        public Task<List<AllInjuryInfo_Model>> GetAllInfo()
        {
            string sql = "Select top 50 * from dbo.NatureOfInjury as noi inner join UniqueIdentifiers as uid on uid.Id = noi.Id left join AdditionalInjuryInformation as adi on adi.Id = noi.Id inner join LocationAssociatedWithInjury as lai on lai.Id = noi.Id";

            return _db.LoadData<AllInjuryInfo_Model, dynamic>(sql, new { });
        }

        public Task<List<InputValues_Model>> GetInputValues()
        {
            string sql = "Select iv.* from dbo.InputValues as iv";

            return _db.LoadData<InputValues_Model, dynamic>(sql, new { });
        }

        public Task InsertUniqueIdentifiers(UniqueIdentifiers_Model unid)
        {
            string sql = @"insert into dbo.UniqueIdentifiers (Name, DOB, Sex, Date_of_Injury, uuid)
                            values (@Name, @DOB, @Sex, @Date_of_Injury, @UUID);";

            return _db.SaveData(sql, unid);
        }

        public Task InsertNatureOfInjury(NatureOfInjury_Model noim, string uuid)
        {
            string strUUID = "\'" + uuid + "\'";

            string sql = @"insert into dbo.NatureOfInjury (Id, NatureOfActivity, NatureOfInjury, MechanismOfInjury, AreaOfInjury)
                            values ((Select Id From UniqueIdentifiers AS ui where ui.uuid = " + strUUID + "), @NatureOfActivity, @NatureOfInjury, @MechanismOfInjury, @AreaOfInjury);";
            return _db.SaveData(sql, noim);
        }

        public Task InsertLocationAssociatedWithInjury(LocationAssociatedWithInjury_Model lawi, string uuid)
        {
            string strUUID = "\'" + uuid + "\'";

            string sql = @"insert into dbo.LocationAssociatedWithInjury (Id, PlaceWhereInjuryOccured, SportOrRecreationalActivity)
                            values ((Select Id from UniqueIdentifiers AS ui where ui.uuid = " + strUUID + "), @PlaceWhereInjuryOccured, @SportOrRecreationalActivity);";
            return _db.SaveData(sql, lawi);
        }

        public Task InsertAdditionalInjuryInformation(AdditionalInjuryInformation_Model aii, string uuid)
        {
            string strUUID = "\'" + uuid + "\'";

            string sql = @"insert into dbo.AdditionalInjuryInformation (Id, TypeOfInjury, TimeOfInjury, GroundSurface, SeverityOfInjury, DataEnteredBy)
                            values ((Select Id from UniqueIdentifiers AS ui where ui.uuid = " + strUUID + "), @TypeOfInjury, @TimeOfInjury, @GroundSurface, @SeverityOfInjury, @DataEnteredBy);";
            return _db.SaveData(sql, aii);
        }
    }
}
