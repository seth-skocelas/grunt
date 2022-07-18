using Grunt.Models.HaloInfinite;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Grunt.Zeta
{
    public static class ExcelCreator
    {
        public static void WriteAllPlayersSkillResultValue(Dictionary<string, List<PlayerSkillResultValue>> dict, Dictionary<string, List<CoreStats>> coreDict, Dictionary<string, List<string>> matchIds)
        {
            using (var workbook = new XLWorkbook())
            {
                foreach (KeyValuePair<string, List<PlayerSkillResultValue>> entry in dict)
                {
                    var worksheet = workbook.Worksheets.Add(entry.Key);
                    worksheet.Cell("A1").Value = "MatchID";
                    worksheet.Cell("B1").Value = "Kills - Actual";
                    worksheet.Cell("C1").Value = "Deaths - Actual";
                    worksheet.Cell("D1").Value = "Kills - Expected";
                    worksheet.Cell("E1").Value = "Deaths - Expected";
                    worksheet.Cell("F1").Value = "Kills - Std Dev";
                    worksheet.Cell("G1").Value = "Deaths - Std Dev";
                    worksheet.Cell("H1").Value = "PreMatchCSR";
                    worksheet.Cell("I1").Value = "PostMatchCSR";
                    worksheet.Cell("J1").Value = "CSR Change";
                    worksheet.Cell("K1").Value = "Damage Dealt";
                    worksheet.Cell("L1").Value = "Damage Taken";

                    var cores = coreDict[entry.Key];
                    var i = 2;
                    foreach (var p in entry.Value)
                    {
                        var core = cores[i - 2];
                        var result = p.Value[0].Result;
                        worksheet.Cell($"A{i}").Value = $"{matchIds[entry.Key][i - 2]}";
                        worksheet.Cell($"B{i}").Value = $"{result.StatPerformances.Kills.Count}";
                        worksheet.Cell($"C{i}").Value = $"{result.StatPerformances.Deaths.Count}";
                        worksheet.Cell($"D{i}").Value = $"{result.StatPerformances.Kills.Expected}";
                        worksheet.Cell($"E{i}").Value = $"{result.StatPerformances.Deaths.Expected}";
                        worksheet.Cell($"F{i}").Value = $"{result.StatPerformances.Kills.StdDev}";
                        worksheet.Cell($"G{i}").Value = $"{result.StatPerformances.Deaths.StdDev}";
                        worksheet.Cell($"H{i}").Value = $"{result.RankRecap.PreMatchCsr.Value}";
                        worksheet.Cell($"I{i}").Value = $"{result.RankRecap.PostMatchCsr.Value}";
                        worksheet.Cell($"J{i}").Value = $"{result.RankRecap.PostMatchCsr.Value - result.RankRecap.PreMatchCsr.Value}";
                        worksheet.Cell($"K{i}").Value = $"{core.DamageDealt}";
                        worksheet.Cell($"L{i}").Value = $"{core.DamageTaken}";
                        i += 1;
                    }
                    worksheet.Columns().AdjustToContents();
                }
                workbook.SaveAs("Report Card.xlsx");
            }
        }
    }
}
