using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RepairsManager.WriteOffModule.Models;

namespace RepairsManager.WriteOffModule.Services
{
    public class StateRepository
    {
        public static byte[] GetWorkOffCertificate(IEnumerable<Repair> repairs, DateTime createDate)
        {
            var currentState = State;

            var templateFileInfo = new FileInfo(@"WorkOffTemplate.xlsx");
            using (var eP = new ExcelPackage(templateFileInfo))
            {
                var sheet = eP.Workbook.Worksheets.First();
                sheet.Cells[2, 2].Value = currentState.Organization;
                sheet.Cells[4, 2].Value = currentState.Department;
                sheet.Cells[3, 20].Value = currentState.Director;
                sheet.Cells[5, 20].Value = createDate.AddMonths(1).Year + " г.";
                sheet.Cells[7, 11].Value = $"{createDate.Month}/{createDate.Year}";
                sheet.Cells[11, 7].Value = currentState.Commission.Number;
                sheet.Cells[11, 11].Value = currentState.Commission.CreateDate.ToString("dd.MM.yyyy") + " г.";
                sheet.Cells[13, 5].Value = currentState.Commission.Chairman.Place;
                sheet.Cells[13, 12].Value = currentState.Commission.Chairman.Name;

                var commissionStartRow = 16;
                sheet.InsertRow(commissionStartRow, currentState.Commission.Members.Length * 2);

                foreach (var item in currentState.Commission.Members)
                {
                    sheet.Row(commissionStartRow).Style.Font.SetFromFont(new Font("Times New Roman", 12));
                    sheet.Row(commissionStartRow).Height = 20;
                    sheet.Row(commissionStartRow + 1).Height = 10;

                    sheet.Cells[commissionStartRow, 5, commissionStartRow, 10].Merge = true;
                    sheet.Cells[commissionStartRow, 12, commissionStartRow, 20].Merge = true;

                    sheet.Cells[commissionStartRow, 5].Value = item.Place;
                    sheet.Cells[commissionStartRow, 5, commissionStartRow, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[commissionStartRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    sheet.Cells[commissionStartRow, 12].Value = item.Name;
                    sheet.Cells[commissionStartRow, 12, commissionStartRow, 20].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[commissionStartRow, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    commissionStartRow += 2;
                }

                return eP.GetAsByteArray();
            }
        }

        public static State State
        {
            get
            {
                var data = File.ReadAllText("state.json", Encoding.UTF8);
                return JObject.Parse(data).ToObject<State>();
            }
            set
            {
                var obj = JObject.FromObject(value);
                var data = obj.ToString(Formatting.Indented);
                File.WriteAllText("state.json", data, Encoding.UTF8);
            }
        }
    }
}
