using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLibrary
{
    public interface IInjuryData
    {
        Task<List<UniqueIdentifiers_Model>> GetGeneralInjuryInfo();
        Task<List<NatureOfInjury_Model>> GetNatureOfInjuryInfo();
        Task<List<InputValues_Model>> GetInputValues();
        Task<List<AllInjuryInfo_Model>> GetAllInfo();
        Task<List<UniqueIdentifiers_Model>> GetUniqueIdentifiersRow(String id);
        Task<List<NatureOfInjury_Model>> GetNatureOfInjuryRow(String id);
        Task<List<LocationAssociatedWithInjury_Model>> GetLAWIRow(String id);
        Task<List<AdditionalInjuryInformation_Model>> GetAIIRow(String id);
        Task InsertUniqueIdentifiers(UniqueIdentifiers_Model unid);
        Task InsertNatureOfInjury(NatureOfInjury_Model noim, string uuid);
        Task InsertLocationAssociatedWithInjury(LocationAssociatedWithInjury_Model lawi, string uuid);
        Task InsertAdditionalInjuryInformation(AdditionalInjuryInformation_Model aii, string uuid);
        Task<FileResult> CreateAndPopulateExcelFile();
    }
}