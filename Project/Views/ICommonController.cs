using System.Collections.Generic;

namespace Controllers
{

    //  đọc dữ liệu dùng chung cho một controller.
    public interface ICommonController<T>
    {
        List<T> GetAll();
    }
}
