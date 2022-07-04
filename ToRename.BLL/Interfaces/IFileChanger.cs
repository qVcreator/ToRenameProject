using ToRename.BLL.OutputModels;

namespace ToRename.BLL.Interfaces
{
    public interface IFileChanger
    {
        public void Rewrite(string path, ActionAllInfoOutputModel[] actions);
    }
}
