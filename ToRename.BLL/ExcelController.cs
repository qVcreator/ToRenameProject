using Microsoft.Office.Interop.Excel;
using ToRename.BLL.Interfaces;
using ToRename.BLL.OutputModels;

namespace ToRename.BLL
{
    public class ExcelController : IFileChanger
    {
        Application excelApp = new Application();            

        public void Rewrite(string path, ActionAllInfoOutputModel[] actions)
        {
            Workbook xlWorkbook = excelApp.Workbooks.Open(path);
            var xlWorksheets = xlWorkbook.Sheets;

            foreach (_Worksheet sheet in xlWorksheets)
            {
                foreach (var action in actions)
                {
                    sheet.Cells.Replace($"{action.From}", $"{action.To}", XlLookAt.xlPart, XlSearchOrder.xlByColumns, MatchCase: false, SearchFormat: false, ReplaceFormat: false);
                }
            }

            excelApp.Visible = true;
        }
    }
}
