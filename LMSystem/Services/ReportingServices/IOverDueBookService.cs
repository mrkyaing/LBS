using LMSystem.Models.ViewModels;

namespace LMSystem.Services.ReportingServices
{
    public interface IOverDueBookService
    {
        IList<OverDueBookViewModel>OverDueBooks(string FromDate,string ToDate,string Bookid);

    }
}
