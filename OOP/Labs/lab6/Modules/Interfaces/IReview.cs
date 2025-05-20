using KNP_Library.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.Interfaces
{
    interface IReview<T,K> : IDisposable
    {
        List<T> GetAllReviews();
        List<T> GetReviewsByBookId(int bookid);
        List<T> GetReviewsByUserId(int userid);
        T? GetReviewById(int id);
        bool AddReview(T review,K book);
        bool DeleteReviewById(int id);
    }
}
