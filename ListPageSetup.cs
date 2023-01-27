using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.PlottingServices;
namespace Autocad_obgect_id
{

    public class ListPageSetup
    {
        // пока неизвестная х-ня
        // Lists the available page setups
        [CommandMethod("F_ListPageSetup")]
        public static void ListPageSetup_Void()
        {
            // Get the current document and database
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                DBDictionary plSettings = acTrans.GetObject(acCurDb.PlotSettingsDictionaryId,
                                                            OpenMode.ForRead) as DBDictionary;

                acDoc.Editor.WriteMessage("\nPage Setups: ");

                // List each named page setup
                foreach (DBDictionaryEntry item in plSettings)
                {
                    acDoc.Editor.WriteMessage("\n  " + item.Key);
                }

                // Abort the changes to the database
               // acTrans.Abort();
               acTrans.Commit();
            }
        }
    }
}
