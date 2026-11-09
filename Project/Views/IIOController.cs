namespace Controllers
{
    //Chức năng xuất dữ liệu của controller ra tệp CSV.
    public interface IIOController
    {
        void ExportCsv(string filePath);
    }
}
