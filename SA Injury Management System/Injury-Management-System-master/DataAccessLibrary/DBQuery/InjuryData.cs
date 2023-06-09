using DataAccessLibrary.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class InjuryData : IInjuryData
    {
        private readonly ISQLDataAccess _db;

        public InjuryData(ISQLDataAccess db)
        {
            _db = db;
        }

        //do an excel sheet generation here
        public ExcelPackage CreateAndPopulateExcelFile()
        {
            var package = new ExcelPackage();

            package.Workbook.Properties.Title = "Injury Management System Data";
            package.Workbook.Properties.Author = "Injury Management Automated Data Sorting";
            package.Workbook.Properties.Subject = "Injury Data";
            package.Workbook.Properties.Keywords = "Injury, Data";

            var worksheet = package.Workbook.Worksheets.Add("First sheet goes here");

            return null;

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
