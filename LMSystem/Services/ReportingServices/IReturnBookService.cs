using LMSystem.Models.ViewModels;

namespace LMSystem.Services.ReportingServices
{
    public interface IReturnBookService
    {IList<ReturnBookViewModel>ReturnBook(string FromDate,string ToDate, string Bookid);
    }
}
