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
            if (repairs == null)
                throw new NullReferenceException();

            var commissionStartRow = 16;
            var materialsStartRow = 19;
            var endRowStart = 23;

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
                    materialsStartRow += 2;
                    endRowStart += 2;
                }

                sheet.InsertRow(materialsStartRow, repairs.Count() + 1);
                var index = 1;

                foreach (var itemRepair in repairs)
                {
                    sheet.Row(materialsStartRow).Style.Font.SetFromFont(new Font("Times New Roman", 12));
                    sheet.Row(materialsStartRow).Height = 40;

                    var cells = new List<ExcelRange>
                    {
                        sheet.Cells[materialsStartRow, 1, materialsStartRow, 2],
                        sheet.Cells[materialsStartRow, 3, materialsStartRow, 6],
                        sheet.Cells[materialsStartRow, 7, materialsStartRow, 7],
                        sheet.Cells[materialsStartRow, 8, materialsStartRow, 10],
                        sheet.Cells[materialsStartRow, 11, materialsStartRow, 11],
                        sheet.Cells[materialsStartRow, 12, materialsStartRow, 14],
                        sheet.Cells[materialsStartRow, 15, materialsStartRow, 18],
                        sheet.Cells[materialsStartRow, 19, materialsStartRow, 20]
                    };

                    foreach (var itemCell in cells)
                    {
                        itemCell.Merge = true;
                        itemCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        itemCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        itemCell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        itemCell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        itemCell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        itemCell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        itemCell.Style.WrapText = true;
                    }

                    cells[0].Value = index;
                    cells[1].Value = itemRepair.Detail;
                    cells[2].Value = itemRepair.Unit;
                    cells[3].Value = itemRepair.Party;
                    cells[4].Value = 1.00m;
                    cells[5].Value = itemRepair.Price;
                    cells[6].Value = itemRepair.Price;
                    cells[7].Value = itemRepair.Reason;

                    cells[4].Style.Numberformat.Format = "0.00";
                    cells[5].Style.Numberformat.Format = "0.00";
                    cells[6].Style.Numberformat.Format = "0.00";

                    index++;
                    materialsStartRow++;
                    endRowStart++;
                }

                //summary
                sheet.Row(materialsStartRow).Style.Font.SetFromFont(new Font("Times New Roman", 12));
                sheet.Row(materialsStartRow).Height = 40;

                var tempList = new List<ExcelRange>
                {
                    sheet.Cells[materialsStartRow, 1, materialsStartRow, 6],
                    sheet.Cells[materialsStartRow, 7, materialsStartRow, 7],
                    sheet.Cells[materialsStartRow, 8, materialsStartRow, 10],
                    sheet.Cells[materialsStartRow, 11, materialsStartRow, 11],
                    sheet.Cells[materialsStartRow, 12, materialsStartRow, 14],
                    sheet.Cells[materialsStartRow, 15, materialsStartRow, 18],
                    sheet.Cells[materialsStartRow, 19, materialsStartRow, 20]
                };

                foreach (var itemCell in tempList)
                {
                    itemCell.Merge = true;
                    itemCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    itemCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    itemCell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    itemCell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    itemCell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    itemCell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    itemCell.Style.WrapText = true;
                }

                tempList[0].Style.Font.Bold = true;
                tempList[0].Value = "Итого";
                tempList[1].Value = "X";
                tempList[3].FormulaR1C1 = $"SUM(R[-{index - 1}]C:R[-1]C)";
                tempList[4].Value = "X";
                tempList[5].FormulaR1C1 = $"SUM(R[-{index - 1}]C:R[-1]C[3])";
                tempList[6].Value = "X";

                tempList[3].Style.Numberformat.Format = "0.00";
                tempList[5].Style.Numberformat.Format = "0.00";

                endRowStart++;
                //end summary

                sheet.Cells[endRowStart, 4].Value = currentState.Commission.Chairman.Place;
                sheet.Cells[endRowStart, 14].Value = currentState.Commission.Chairman.Name;
                endRowStart += 3;

                foreach (var item in currentState.Commission.Members)
                {
                    sheet.Row(endRowStart).Style.Font.SetFromFont(new Font("Arial", 11));
                    sheet.Row(endRowStart).Height = 20;

                    sheet.Row(endRowStart + 1).Height = 10;
                    sheet.Row(endRowStart + 1).Style.Font.SetFromFont(new Font("Arial", 7));

                    sheet.Row(endRowStart + 2).Height = 10;

                    sheet.Cells[endRowStart, 4, endRowStart, 6].Merge = true;
                    sheet.Cells[endRowStart + 1, 4, endRowStart + 1, 6].Merge = true;
                    sheet.Cells[endRowStart, 14, endRowStart, 18].Merge = true;
                    sheet.Cells[endRowStart + 1, 14, endRowStart + 1, 18].Merge = true;
                    sheet.Cells[endRowStart, 10, endRowStart, 11].Merge = true;
                    sheet.Cells[endRowStart + 1, 10, endRowStart + 1, 11].Merge = true;

                    sheet.Cells[endRowStart, 4].Value = item.Place;
                    sheet.Cells[endRowStart + 1, 4].Value = "(должность)";
                    sheet.Cells[endRowStart, 4, endRowStart, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[endRowStart, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[endRowStart + 1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    sheet.Cells[endRowStart + 1, 10].Value = "(подпись)";
                    sheet.Cells[endRowStart, 10, endRowStart, 11].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[endRowStart, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[endRowStart + 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    sheet.Cells[endRowStart, 14].Value = item.Name;
                    sheet.Cells[endRowStart + 1, 14].Value = "(И.О.Фамилия)";
                    sheet.Cells[endRowStart, 14, endRowStart, 18].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[endRowStart, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[endRowStart + 1, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    endRowStart += 3;
                }

                endRowStart -= currentState.Commission.Members.Length * 3;
                sheet.Cells[endRowStart, 1, endRowStart, 3].Style.Font.SetFromFont(new Font("Arial", 9));
                sheet.Cells[endRowStart, 1, endRowStart, 3].Style.Font.Bold = true;
                sheet.Cells[endRowStart, 1, endRowStart, 3].Merge = true;
                sheet.Cells[endRowStart, 1, endRowStart, 3].Value = "Члены коммиссии:";
                sheet.Cells[endRowStart, 1, endRowStart, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

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
